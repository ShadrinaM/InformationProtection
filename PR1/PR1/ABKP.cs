using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace PR1
{
    public partial class ABKP : Form
    {
        private BigInteger[] A;           // закрытая сверхвозрастающая последовательность
        private BigInteger p;             // модуль
        private BigInteger t;             // множитель
        private BigInteger t_inv;         // обратный множитель
        private BigInteger[] W;           // открытый ключ
        private int n;                    // длина последовательности (бит на блок)
        private int bitsPerChar = 16;     // для Unicode символов (русские буквы)

        public ABKP()
        {
            InitializeComponent();
            n = 16; // 16 бит на символ для Unicode
            numericUpDownN.Value = n;
        }

        // ========== Генерация сверхвозрастающей последовательности ==========
        private void btnGenerateSeq_Click(object sender, EventArgs e)
        {
            n = (int)numericUpDownN.Value;
            A = GenerateSuperIncreasing(n);
            txtSeq.Text = string.Join(", ", A);
            lblStatus.Text = "Сверхвозрастающая последовательность сгенерирована.";
            btnGenerateKeys.Enabled = true;
        }

        private BigInteger[] GenerateSuperIncreasing(int length)
        {
            Random rnd = new Random();
            BigInteger[] seq = new BigInteger[length];
            seq[0] = rnd.Next(1, 10);
            BigInteger sum = seq[0];
            for (int i = 1; i < length; i++)
            {
                // Следующий элемент > суммы всех предыдущих
                seq[i] = sum + rnd.Next(1, 20);
                sum += seq[i];
            }
            return seq;
        }

        // ========== Генерация ключей ==========
        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            if (A == null)
            {
                MessageBox.Show("Сначала сгенерируйте сверхвозрастающую последовательность.", "Ошибка");
                return;
            }

            BigInteger sumA = 0;
            foreach (var a in A) sumA += a;

            // Выбираем модуль p > sumA
            p = NextPrime(sumA + 1);

            Random rnd = new Random();
            do
            {
                t = rnd.Next(2, (int)(p > int.MaxValue ? int.MaxValue : (long)p) - 1);
            } while (BigInteger.GreatestCommonDivisor(t, p) != 1);

            t_inv = ModInverse(t, p);

            W = new BigInteger[n];
            for (int i = 0; i < n; i++)
            {
                W[i] = (A[i] * t) % p;
            }

            txtPrivateKey.Text = $"A = [{string.Join(", ", A)}]\r\np = {p}\r\nt = {t}\r\nt⁻¹ = {t_inv}";
            txtPublicKey.Text = string.Join(", ", W);
            lblStatus.Text = "Ключи сгенерированы.";
            btnEncrypt.Enabled = true;
        }

        // ========== Преобразование текста в битовую строку (16 бит на символ) ==========
        private string TextToBits(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                // Получаем код символа как 16-битное число
                int code = (int)c;
                string bits = Convert.ToString(code, 2).PadLeft(bitsPerChar, '0');
                sb.Append(bits);
            }
            return sb.ToString();
        }

        // ========== Преобразование битовой строки в текст (16 бит на символ) ==========
        private string BitsToText(string bits)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i + bitsPerChar <= bits.Length; i += bitsPerChar)
            {
                string bitsBlock = bits.Substring(i, bitsPerChar);
                int code = Convert.ToInt32(bitsBlock, 2);
                sb.Append((char)code);
            }
            return sb.ToString();
        }

        // ========== Шифрование ==========
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (W == null)
            {
                MessageBox.Show("Сначала сгенерируйте ключи.", "Ошибка");
                return;
            }

            string message = txtMessage.Text;
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Введите сообщение для шифрования.", "Ошибка");
                return;
            }

            // Преобразуем сообщение в битовую строку (bitsPerChar бит на символ)
            string bits = TextToBits(message);

            // Дополняем до кратности n (длина блока шифрования = n)
            int pad = (n - (bits.Length % n)) % n;
            string originalBits = bits;
            bits = bits.PadRight(bits.Length + pad, '0');

            // Разбиваем на блоки и шифруем
            StringBuilder cipherBuilder = new StringBuilder();
            for (int i = 0; i < bits.Length; i += n)
            {
                string block = bits.Substring(i, n);
                BigInteger sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (block[j] == '1')
                        sum += W[j];
                }
                cipherBuilder.Append(sum.ToString());
                if (i + n < bits.Length) cipherBuilder.Append(' ');
            }

            txtCipher.Text = cipherBuilder.ToString();
            lblStatus.Text = $"Сообщение зашифровано. Исходные биты ({originalBits.Length}): {originalBits}";
            btnDecrypt.Enabled = true;
        }

        // ========== Дешифрование ==========
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (A == null || p == 0 || t_inv == 0)
            {
                MessageBox.Show("Сначала сгенерируйте ключи.", "Ошибка");
                return;
            }

            string cipherText = txtCipher.Text.Trim();
            if (string.IsNullOrEmpty(cipherText))
            {
                MessageBox.Show("Введите шифртекст (числа через пробел).", "Ошибка");
                return;
            }

            string[] parts = cipherText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder recoveredBits = new StringBuilder();

            foreach (string part in parts)
            {
                BigInteger c = BigInteger.Parse(part);
                // Снимаем маскировку
                BigInteger c_prime = (c * t_inv) % p;

                // Жадный алгоритм для восстановления битов
                bool[] bits = new bool[n];
                BigInteger remaining = c_prime;
                for (int i = n - 1; i >= 0; i--)
                {
                    if (remaining >= A[i])
                    {
                        bits[i] = true;
                        remaining -= A[i];
                    }
                    else
                    {
                        bits[i] = false;
                    }
                }

                // Проверяем, что остаток обнулился
                if (remaining != 0)
                {
                    lblStatus.Text = $"Ошибка: остаток {remaining} не обнулился! Возможно, неверные ключи.";
                    return;
                }

                // Добавляем биты в строку (от старшего к младшему)
                for (int i = 0; i < n; i++)
                {
                    recoveredBits.Append(bits[i] ? '1' : '0');
                }
            }

            string bitsStr = recoveredBits.ToString();

            // Убираем лишние нули в конце (добавленные при дополнении)
            // Находим последний значащий бит (где начинается последний полный символ)
            // Для этого нужно определить, сколько символов было в исходном сообщении
            // Простой способ: убираем нули в конце, пока длина не станет кратной bitsPerChar
            while (bitsStr.Length % bitsPerChar != 0 && bitsStr.Length > 0)
            {
                bitsStr = bitsStr.Substring(0, bitsStr.Length - 1);
            }

            string recoveredText = BitsToText(bitsStr);
            txtDecrypted.Text = recoveredText;
            lblStatus.Text = $"Шифртекст расшифрован. Восстановлено бит: {bitsStr.Length}";
        }

        // ========== Вспомогательные методы ==========

        // Проверка простоты числа
        private bool IsPrime(BigInteger num)
        {
            if (num < 2) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            BigInteger limit = (BigInteger)Math.Sqrt((double)num);
            for (BigInteger i = 3; i <= limit; i += 2)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        // Поиск следующего простого числа >= start
        private BigInteger NextPrime(BigInteger start)
        {
            if (start <= 2) return 2;
            if (start % 2 == 0) start++;
            while (!IsPrime(start)) start += 2;
            return start;
        }

        // Расширенный алгоритм Евклида для нахождения обратного элемента
        private BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m, t, q;
            BigInteger x0 = 0, x1 = 1;

            if (m == 1) return 0;

            while (a > 1)
            {
                q = a / m;
                t = m;
                m = a % m;
                a = t;
                t = x0;
                x0 = x1 - q * x0;
                x1 = t;
            }

            if (x1 < 0) x1 += m0;
            return x1;
        }
    }
}