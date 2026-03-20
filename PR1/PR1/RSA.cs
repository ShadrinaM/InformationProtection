using System;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace PR1
{
    public partial class RSA : Form
    {
        BigInteger p, q, n, phi, publicExponent, d;

        public RSA()
        {
            InitializeComponent();
        }

        // Генерация ключей
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            p = GeneratePrime(rnd);
            q = GeneratePrime(rnd);

            n = p * q;
            phi = (p - 1) * (q - 1);

            publicExponent = 65537;
            if (BigInteger.GreatestCommonDivisor(publicExponent, phi) != 1)
            {
                publicExponent = 3;
            }

            d = ModInverse(publicExponent, phi);

            txtP.Text = p.ToString();
            txtQ.Text = q.ToString();
            txtN.Text = n.ToString();
            txtPhi.Text = phi.ToString();
            txtE.Text = publicExponent.ToString();
            txtD.Text = d.ToString();
        }

        // Шифрование
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            StringBuilder encrypted = new StringBuilder();

            foreach (char c in message)
            {
                BigInteger m = new BigInteger((int)c);
                BigInteger cipher = BigInteger.ModPow(m, publicExponent, n);
                encrypted.Append(cipher.ToString() + " ");
            }

            txtEncrypted.Text = encrypted.ToString();
        }

        // Расшифровка
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            string[] parts = txtEncrypted.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder decrypted = new StringBuilder();

            foreach (string part in parts)
            {
                BigInteger cipher = BigInteger.Parse(part);
                BigInteger m = BigInteger.ModPow(cipher, d, n);
                decrypted.Append((char)(int)m);
            }

            txtDecrypted.Text = decrypted.ToString();
        }

        // Генерация простого числа
        private BigInteger GeneratePrime(Random rnd)
        {
            while (true)
            {
                int number = rnd.Next(100, 500);
                if (IsPrime(number))
                    return number;
            }
        }

        // Проверка на простоту
        private bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0)
                    return false;
            return true;
        }

        // Нахождение обратного элемента (расширенный алгоритм Евклида)
        private BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m, t, q;
            BigInteger x0 = 0, x1 = 1;

            if (m == 1)
                return 0;

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

            if (x1 < 0)
                x1 += m0;

            return x1;
        }
    }

}