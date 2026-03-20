using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace PR1
{
    public partial class MVKR : Form
    {
        private BigInteger[] A;           // закрытая мультипликативная сверхвозрастающая последовательность
        private BigInteger p;             // модуль
        private BigInteger t;             // множитель
        private BigInteger t_inv;         // обратный множитель
        private BigInteger[] W;           // открытый ключ
        private int n;                    // длина последовательности (бит на блок)
        private int bitsPerChar = 16;     // для Unicode символов (русские буквы)

        public MVKR()
        {
            InitializeComponent();
            n = 8; // 8 бит на блок для мультипликативного варианта
            numericUpDownN.Value = n;
        }

        // ========== Генерация мультипликативной сверхвозрастающей последовательности ==========
        private void btnGenerateSeq_Click(object sender, EventArgs e)
        {
            n = (int)numericUpDownN.Value;
            A = GenerateMultiplicativeSuperIncreasing(n);
            txtSeq.Text = string.Join(", ", A);
            lblStatus.Text = "Мультипликативная сверхвозрастающая последовательность сгенерирована.";
            btnGenerateKeys.Enabled = true;
        }

        private BigInteger[] GenerateMultiplicativeSuperIncreasing(int length)
        {
            Random rnd = new Random();
            BigInteger[] seq = new BigInteger[length];

            // Первый элемент: небольшое простое число
            seq[0] = rnd.Next(2, 10);
            BigInteger product = seq[0];

            for (int i = 1; i < length; i++)
            {
                // Каждый следующий элемент > произведения всех предыдущих
                seq[i] = product + rnd.Next(1, 20);
                product *= seq[i];
            }
            return seq;
        }

        // ========== Генерация ключей ==========
        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            if (A == null)
            {
                MessageBox.Show("Сначала сгенерируйте мультипликативную сверхвозрастающую последовательность.", "Ошибка");
                return;
            }

            // Вычисляем произведение всех элементов последовательности
            BigInteger productA = 1;
            foreach (var a in A) productA *= a;

            // Выбираем модуль p > productA
            p = NextPrime(productA + 1);

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

        // ========== Преобразование текста в битовую строку ==========
        private string TextToBits(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                int code = (int)c;
                string bits = Convert.ToString(code, 2).PadLeft(bitsPerChar, '0');
                sb.Append(bits);
            }
            return sb.ToString();
        }

        // ========== Преобразование битовой строки в текст ==========
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

        // ========== Вычисление веса Хэмминга ==========
        private int HammingWeight(string bits)
        {
            int weight = 0;
            foreach (char c in bits)
            {
                if (c == '1') weight++;
            }
            return weight;
        }

        // ========== Шифрование (мультипликативное) ==========
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

            // Преобразуем сообщение в битовую строку
            string bits = TextToBits(message);

            // Дополняем до кратности n
            int pad = (n - (bits.Length % n)) % n;
            string originalBits = bits;
            bits = bits.PadRight(bits.Length + pad, '0');

            // Разбиваем на блоки и шифруем (мультипликативно)
            StringBuilder cipherBuilder = new StringBuilder();
            for (int i = 0; i < bits.Length; i += n)
            {
                string block = bits.Substring(i, n);
                BigInteger product = 1;
                for (int j = 0; j < n; j++)
                {
                    if (block[j] == '1')
                        product = (product * W[j]) % p;
                }
                cipherBuilder.Append(product.ToString());
                if (i + n < bits.Length) cipherBuilder.Append(' ');
            }

            txtCipher.Text = cipherBuilder.ToString();
            lblStatus.Text = $"Сообщение зашифровано (мультипликативно). Бит: {originalBits.Length}";
            btnDecrypt.Enabled = true;
        }

        // ========== Дешифрование (мультипликативное) ==========
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

                // Восстанавливаем битовый блок, соответствующий этому шифртексту
                // Нам нужно определить, сколько битов в блоке было установлено
                // Для этого используем жадный алгоритм с делимостью

                // Сначала нужно вычислить c' = c * (t⁻¹)^H(b) mod p
                // Но H(b) нам неизвестен! В классическом мультипликативном рюкзаке
                // нужно перебирать возможные веса Хэмминга или использовать другой подход.
                // Простейший способ: восстанавливаем биты, используя закрытую последовательность A
                // и свойство мультипликативной сверхвозрастающей последовательности.

                // Перебираем возможные веса Хэмминга от 0 до n
                bool found = false;
                BigInteger[] recoveredBlock = null;
                int foundWeight = -1;

                for (int h = 0; h <= n; h++)
                {
                    // Вычисляем t⁻¹ в степени h
                    BigInteger t_inv_pow = BigInteger.ModPow(t_inv, h, p);
                    BigInteger c_prime = (c * t_inv_pow) % p;

                    // Жадный алгоритм для мультипликативного случая
                    bool[] bits = new bool[n];
                    BigInteger remaining = c_prime;
                    bool valid = true;

                    for (int i = n - 1; i >= 0; i--)
                    {
                        if (remaining % A[i] == 0)
                        {
                            bits[i] = true;
                            remaining /= A[i];
                        }
                        else
                        {
                            bits[i] = false;
                        }
                    }

                    // Проверяем, что остаток обнулился и количество единиц соответствует h
                    if (remaining == 1)
                    {
                        int actualWeight = 0;
                        foreach (bool bit in bits) if (bit) actualWeight++;

                        if (actualWeight == h)
                        {
                            found = true;
                            foundWeight = h;
                            // Сохраняем восстановленные биты
                            recoveredBlock = new BigInteger[n];
                            for (int j = 0; j < n; j++)
                            {
                                recoveredBlock[j] = bits[j] ? 1 : 0;
                            }
                            break;
                        }
                    }
                }

                if (!found)
                {
                    lblStatus.Text = "Ошибка: не удалось восстановить биты. Возможно, неверные ключи.";
                    return;
                }

                // Добавляем восстановленные биты
                for (int i = 0; i < n; i++)
                {
                    recoveredBits.Append(recoveredBlock[i] == 1 ? '1' : '0');
                }
            }

            string bitsStr = recoveredBits.ToString();

            // Убираем лишние нули в конце
            while (bitsStr.Length % bitsPerChar != 0 && bitsStr.Length > 0)
            {
                bitsStr = bitsStr.Substring(0, bitsStr.Length - 1);
            }

            string recoveredText = BitsToText(bitsStr);
            txtDecrypted.Text = recoveredText;
            lblStatus.Text = $"Шифртекст расшифрован (мультипликативно). Восстановлено бит: {bitsStr.Length}";
        }

        // ========== Вспомогательные методы ==========

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

        private BigInteger NextPrime(BigInteger start)
        {
            if (start <= 2) return 2;
            if (start % 2 == 0) start++;
            while (!IsPrime(start)) start += 2;
            return start;
        }

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