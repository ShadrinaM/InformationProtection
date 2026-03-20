using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace PR1
{
    public partial class GMKP : Form
    {
        private BigInteger[] A;           // закрытая мультипликативная сверхвозрастающая последовательность
        private BigInteger p;             // модуль
        private BigInteger t;             // множитель (секретный)
        private BigInteger t_inv;         // обратный множитель
        private BigInteger[] W;           // открытый ключ
        private int n;                    // длина последовательности
        private int B;                    // основание системы счисления

        public GMKP()
        {
            InitializeComponent();
            n = 4;
            B = 5;
            numericUpDownN.Value = n;
            numericUpDownB.Value = B;
        }

        // ========== Генерация мультипликативной сверхвозрастающей последовательности ==========
        private void btnGenerateSeq_Click(object sender, EventArgs e)
        {
            n = (int)numericUpDownN.Value;
            B = (int)numericUpDownB.Value;

            A = GenerateMultiplicativeSuperIncreasingForGMKP(n, B);
            txtSeq.Text = string.Join(", ", A);
            lblStatus.Text = $"Мультипликативная сверхвозрастающая последовательность (B={B}) сгенерирована.";
            btnGenerateKeys.Enabled = true;
        }

        private BigInteger[] GenerateMultiplicativeSuperIncreasingForGMKP(int length, int baseB)
        {
            Random rnd = new Random();
            BigInteger[] seq = new BigInteger[length];

            // Первый элемент
            seq[0] = rnd.Next(2, 10);
            BigInteger product = 1;

            for (int i = 1; i < length; i++)
            {
                // a_k > ∏(a_i^(B-1)) для i от 1 до k-1
                // Вычисляем произведение всех предыдущих элементов в степени (B-1)
                BigInteger previousProduct = 1;
                for (int j = 0; j < i; j++)
                {
                    previousProduct *= BigInteger.Pow(seq[j], baseB - 1);
                }

                // a_k должно быть больше previousProduct
                seq[i] = previousProduct + rnd.Next(1, 20);
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

            // Вычисляем произведение всех элементов A в степени (B-1)
            BigInteger productA = 1;
            for (int i = 0; i < n; i++)
            {
                productA *= BigInteger.Pow(A[i], B - 1);
            }

            // Выбираем модуль p > productA
            p = NextPrime(productA + 1);

            Random rnd = new Random();
            do
            {
                t = rnd.Next(2, (int)(p > int.MaxValue ? int.MaxValue : (long)p) - 1);
            } while (BigInteger.GreatestCommonDivisor(t, p) != 1);

            t_inv = ModInverse(t, p);

            // Генерация открытого ключа: w_i = a_i^t mod p
            W = new BigInteger[n];
            for (int i = 0; i < n; i++)
            {
                W[i] = BigInteger.ModPow(A[i], t, p);
            }

            txtPrivateKey.Text = $"A = [{string.Join(", ", A)}]\r\np = {p}\r\nt = {t}\r\nt⁻¹ = {t_inv}\r\nB = {B}";
            txtPublicKey.Text = string.Join(", ", W);
            lblStatus.Text = "Ключи сгенерированы.";
            btnEncrypt.Enabled = true;
        }

        // ========== Преобразование текста в массив цифр по основанию B ==========
        private int[] TextToDigits(string text)
        {
            int[] digits = new int[n];

            // Преобразуем строку в число, рассматривая каждый символ как цифру в системе 256
            BigInteger number = 0;
            for (int i = 0; i < text.Length && i < n; i++)
            {
                number = number * 256 + text[i];
            }

            // Если число слишком большое, ограничиваем его максимальным значением для n цифр в системе B
            BigInteger maxValue = 1;
            for (int i = 0; i < n; i++)
            {
                maxValue *= B;
            }
            maxValue -= 1;

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

        // ========== Шифрование (мультипликативное обобщённое) ==========
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

            // Вычисляем максимальную длину сообщения
            BigInteger maxNumber = 1;
            for (int i = 0; i < n; i++)
            {
                maxNumber *= B;
            }
            maxNumber -= 1;

            int maxChars = 0;
            BigInteger temp = maxNumber;
            while (temp > 0)
            {
                maxChars++;
                temp /= 256;
            }

            if (message.Length > maxChars)
            {
                MessageBox.Show($"Сообщение слишком длинное. Максимальная длина: {maxChars} символов для n={n}, B={B}", "Предупреждение");
                return;
            }

            // Преобразуем сообщение в цифры по основанию B
            int[] digits = TextToDigits(message);

            // Вычисляем шифртекст как произведение w_i^d_i mod p
            BigInteger product = 1;
            for (int i = 0; i < n; i++)
            {
                product = (product * BigInteger.ModPow(W[i], digits[i], p)) % p;
            }

            txtCipher.Text = product.ToString();

            // Для отладки показываем цифры
            lblStatus.Text = $"Сообщение зашифровано. Цифры: [{string.Join(", ", digits)}]";
            btnDecrypt.Enabled = true;
        }

        // ========== Дешифрование (мультипликативное обобщённое) ==========
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

            // Снимаем маскировку: c' = c^(t_inv) mod p
            BigInteger c_prime = BigInteger.ModPow(c, t_inv, p);

            // Жадный алгоритм для восстановления цифр
            int[] digits = new int[n];
            BigInteger remaining = c_prime;

            for (int i = n - 1; i >= 0; i--)
            {
                // Находим максимальную степень d_i такую, что A[i]^d_i делит remaining
                // и d_i <= B-1
                digits[i] = 0;
                for (int d = B - 1; d >= 0; d--)
                {
                    BigInteger power = BigInteger.Pow(A[i], d);
                    if (remaining % power == 0 && d >= digits[i])
                    {
                        digits[i] = d;
                        break;
                    }
                }

                // Делим remaining на A[i]^digits[i]
                remaining /= BigInteger.Pow(A[i], digits[i]);
            }

            // Проверяем, что остаток обнулился (должен быть 1)
            if (remaining != 1)
            {
                lblStatus.Text = $"Ошибка: остаток {remaining} не равен 1! Возможно, сообщение было слишком большим или ключи неверны.";
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