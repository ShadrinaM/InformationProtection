using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace PR1
{
    public partial class GAKP : Form
    {
        private BigInteger[] A;           // закрытая сверхвозрастающая последовательность
        private BigInteger p;             // модуль
        private BigInteger t;             // множитель
        private BigInteger t_inv;         // обратный множитель
        private BigInteger[] W;           // открытый ключ
        private int n;                    // длина последовательности
        private int B;                    // основание системы счисления

        public GAKP()
        {
            InitializeComponent();
            n = 4;
            B = 10;
            numericUpDownN.Value = n;
            numericUpDownB.Value = B;
        }

        // ========== Генерация сверхвозрастающей последовательности для GAKP ==========
        private void btnGenerateSeq_Click(object sender, EventArgs e)
        {
            n = (int)numericUpDownN.Value;
            B = (int)numericUpDownB.Value;

            A = GenerateSuperIncreasingForGAKP(n, B);
            txtSeq.Text = string.Join(", ", A);
            lblStatus.Text = $"Сверхвозрастающая последовательность (B={B}) сгенерирована.";
            btnGenerateKeys.Enabled = true;
        }

        private BigInteger[] GenerateSuperIncreasingForGAKP(int length, int baseB)
        {
            Random rnd = new Random();
            BigInteger[] seq = new BigInteger[length];

            // Первый элемент
            seq[0] = rnd.Next(1, 10);
            BigInteger sum = seq[0];

            for (int i = 1; i < length; i++)
            {
                // a_k > (B-1) * сумма всех предыдущих
                BigInteger minValue = (baseB - 1) * sum + 1;
                seq[i] = minValue + rnd.Next(0, 20);
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

            // Вычисляем (B-1) * сумму всех элементов A
            BigInteger sumA = 0;
            foreach (var a in A) sumA += a;
            BigInteger threshold = (B - 1) * sumA;

            // Выбираем модуль p > threshold
            p = NextPrime(threshold + 1);

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

            txtPrivateKey.Text = $"A = [{string.Join(", ", A)}]\r\np = {p}\r\nt = {t}\r\nt⁻¹ = {t_inv}\r\nB = {B}";
            txtPublicKey.Text = string.Join(", ", W);
            lblStatus.Text = "Ключи сгенерированы.";
            btnEncrypt.Enabled = true;
        }

        // ========== Преобразование текста в массив цифр по основанию B ==========
        private int[] TextToDigits(string text)
        {
            // Для каждого символа получаем его код и преобразуем в цифры по основанию B
            int totalDigits = n; // Используем n цифр на блок
            int[] digits = new int[totalDigits];

            // Преобразуем строку в число, рассматривая каждый символ как цифру в системе 256
            BigInteger number = 0;
            for (int i = 0; i < text.Length && i < n; i++)
            {
                number = number * 256 + text[i];
            }

            // Если число слишком большое, ограничиваем его максимальным значением для n цифр в системе B
            BigInteger maxValue = BigInteger.Pow(B, n) - 1;
            if (number > maxValue)
            {
                number = maxValue;
            }

            // Преобразуем число в цифры по основанию B
            for (int i = n - 1; i >= 0; i--)
            {
                digits[i] = (int)(number % B);
                number /= B;
            }

            return digits;
        }

        // ========== Преобразование цифр обратно в текст ==========
        private string DigitsToText(int[] digits)
        {
            // Восстанавливаем число из цифр в системе B
            BigInteger number = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                number = number * B + digits[i];
            }

            // Преобразуем число обратно в строку (коды символов в системе 256)
            if (number == 0)
                return "";

            StringBuilder result = new StringBuilder();
            while (number > 0)
            {
                result.Insert(0, (char)(int)(number % 256));
                number /= 256;
            }

            return result.ToString();
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

            // Проверяем длину сообщения
            int maxChars = (int)(Math.Log((double)BigInteger.Pow(B, n)) / Math.Log(256));
            if (message.Length > maxChars)
            {
                MessageBox.Show($"Сообщение слишком длинное. Максимальная длина: {maxChars} символов для n={n}, B={B}", "Предупреждение");
                return;
            }

            // Преобразуем сообщение в цифры по основанию B
            int[] digits = TextToDigits(message);

            // Вычисляем шифртекст как взвешенную сумму
            BigInteger sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += digits[i] * W[i];
            }
            sum %= p;

            txtCipher.Text = sum.ToString();

            // Для отладки показываем цифры
            lblStatus.Text = $"Сообщение зашифровано. Цифры: [{string.Join(", ", digits)}]";
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
                MessageBox.Show("Введите шифртекст (число).", "Ошибка");
                return;
            }

            BigInteger c = BigInteger.Parse(cipherText);

            // Снимаем маскировку
            BigInteger c_prime = (c * t_inv) % p;

            // Жадный алгоритм для восстановления цифр
            int[] digits = new int[n];
            BigInteger remaining = c_prime;

            for (int i = n - 1; i >= 0; i--)
            {
                // Вычисляем цифру: d_i = min(floor(c' / a_i), B-1)
                BigInteger digitValue = remaining / A[i];
                if (digitValue > B - 1)
                {
                    digits[i] = B - 1;
                }
                else
                {
                    digits[i] = (int)digitValue;
                }
                remaining -= digits[i] * A[i];
            }

            // Проверяем, что остаток обнулился
            if (remaining != 0)
            {
                lblStatus.Text = $"Ошибка: остаток {remaining} не обнулился! Возможно, сообщение было слишком большим или ключи неверны.";
                return;
            }

            // Восстанавливаем текст из цифр
            string recoveredText = DigitsToText(digits);
            txtDecrypted.Text = recoveredText;

            lblStatus.Text = $"Шифртекст расшифрован. Цифры: [{string.Join(", ", digits)}]";
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