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
        private BigInteger t;             // множитель (секретная экспонента)
        private BigInteger t_inv;         // обратный множитель (обратная экспонента по модулю p)
        private BigInteger[] W;           // открытый ключ
        private int n;                    // длина последовательности
        private int B;                    // основание системы счисления

        public GMKP()
        {
            InitializeComponent();
            n = 4;
            B = 10;
            numericUpDownN.Value = n;
            numericUpDownB.Value = B;
        }

        // ========== Генерация мультипликативной сверхвозрастающей последовательности для GMKP ==========
        private void btnGenerateSeq_Click(object sender, EventArgs e)
        {
            n = (int)numericUpDownN.Value;
            B = (int)numericUpDownB.Value;

            A = GenerateMultiplicativeSuperIncreasing(n, B);
            txtSeq.Text = string.Join(", ", A);
            lblStatus.Text = $"Мультипликативная сверхвозрастающая последовательность (B={B}) сгенерирована.";
            btnGenerateKeys.Enabled = true;
        }

        /// <summary>
        /// Генерация мультипликативной сверхвозрастающей последовательности:
        /// a_k > ∏_{i=1}^{k-1} a_i^(B-1)
        /// </summary>
        private BigInteger[] GenerateMultiplicativeSuperIncreasing(int length, int baseB)
        {
            Random rnd = new Random();
            BigInteger[] seq = new BigInteger[length];

            // Первый элемент (минимальное значение от 2 до 10)
            seq[0] = rnd.Next(2, 10);
            BigInteger product = 1;

            for (int i = 1; i < length; i++)
            {
                // Вычисляем произведение предыдущих элементов в степени (B-1)
                BigInteger productPower = 1;
                for (int j = 0; j < i; j++)
                {
                    productPower *= BigInteger.Pow(seq[j], baseB - 1);
                }

                // a_i должно быть больше productPower
                BigInteger minValue = productPower + 1;
                // Добавляем случайную величину для увеличения разнообразия
                seq[i] = minValue + rnd.Next(0, 20);
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

            // Вычисляем ∏_{i=1}^{n} a_i^(B-1)
            BigInteger productPower = 1;
            for (int i = 0; i < n; i++)
            {
                productPower *= BigInteger.Pow(A[i], B - 1);
            }

            // Выбираем модуль p > productPower
            p = NextPrime(productPower + 1);

            Random rnd = new Random();
            do
            {
                t = rnd.Next(2, (int)(p > int.MaxValue ? int.MaxValue : (long)p) - 1);
            } while (BigInteger.GreatestCommonDivisor(t, p) != 1);

            t_inv = ModInverse(t, p);

            // Вычисляем открытый ключ: w_i = a_i^t mod p
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

            // Вычисляем шифртекст: c = ∏ w_i^d_i mod p
            BigInteger product = 1;
            for (int i = 0; i < n; i++)
            {
                product = (product * BigInteger.ModPow(W[i], digits[i], p)) % p;
            }

            txtCipher.Text = product.ToString();

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

            // Снимаем маскировку: c' = c^(t^-1) mod p
            BigInteger c_prime = BigInteger.ModPow(c, t_inv, p);

            // Жадный алгоритм для восстановления цифр
            int[] digits = new int[n];
            BigInteger remaining = c_prime;

            for (int i = n - 1; i >= 0; i--)
            {
                // Находим максимальную степень d_i такую, что a_i^d_i делит remaining
                // и d_i <= B-1
                digits[i] = 0;
                BigInteger power = 1;

                for (int exp = 1; exp <= B - 1; exp++)
                {
                    power *= A[i];
                    if (remaining % power == 0)
                    {
                        digits[i] = exp;
                    }
                    else
                    {
                        break;
                    }
                }

                // Делим remaining на a_i^d_i
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

        // ========== Вспомогательные методы ==========

        private bool IsPrime(BigInteger num)
        {
            if (num < 2) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            // Используем пробное деление только до sqrt(num)
            // Для больших чисел используем BigInteger для вычисления sqrt
            BigInteger sqrtNum = Sqrt(num);

            for (BigInteger i = 3; i <= sqrtNum; i += 2)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Вычисление целочисленного квадратного корня из BigInteger
        /// </summary>
        private BigInteger Sqrt(BigInteger n)
        {
            if (n == 0) return 0;
            if (n < 0) throw new ArgumentException("Cannot compute square root of negative number");

            BigInteger low = 1;
            BigInteger high = n;
            BigInteger mid;

            while (high - low > 1)
            {
                mid = (low + high) / 2;
                BigInteger midSquared = mid * mid;

                if (midSquared == n)
                    return mid;
                else if (midSquared < n)
                    low = mid;
                else
                    high = mid;
            }

            // Проверяем, какой из двух кандидатов ближе
            if (high * high <= n)
                return high;
            else
                return low;
        }

        private BigInteger NextPrime(BigInteger start)
        {
            if (start <= 2) return 2;
            if (start % 2 == 0) start++;

            // Ограничиваем максимальное количество попыток, чтобы избежать бесконечного цикла
            int maxAttempts = 100000;
            int attempts = 0;

            while (!IsPrime(start) && attempts < maxAttempts)
            {
                start += 2;
                attempts++;
            }

            if (attempts >= maxAttempts)
            {
                // Если не нашли простое число за разумное количество попыток,
                // используем простой метод проверки с большим шагом
                while (!IsPrime(start))
                {
                    start += 2;
                }
            }

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