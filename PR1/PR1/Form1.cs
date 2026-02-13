using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PR1
{
    public partial class Form1 : Form
    {
        private BigInteger p, q, n, phi, e, d;
        private RSACryptoServiceProvider rsaProvider;
        private const int KEY_SIZE = 2048; // Размер ключа в битах

        public Form1()
        {
            InitializeComponent();
            InitializeRSA();
        }

        private void InitializeRSA()
        {
            // Используем стандартную криптографию .NET
            rsaProvider = new RSACryptoServiceProvider(KEY_SIZE);
            UpdateKeyDisplay();
        }

        private void UpdateKeyDisplay()
        {
            try
            {
                // Параметры RSA
                var parameters = rsaProvider.ExportParameters(true);

                // Открытый ключ (Modulus и Exponent)
                txtPublicKey.Text = $"Modulus (n): {BitConverter.ToString(parameters.Modulus).Replace("-", "")}\r\n\r\n" +
                                   $"Public Exponent (e): {BitConverter.ToString(parameters.Exponent).Replace("-", "")}";

                // Закрытый ключ (Modulus и D)
                if (parameters.D != null)
                {
                    txtPrivateKey.Text = $"Modulus (n): {BitConverter.ToString(parameters.Modulus).Replace("-", "")}\r\n\r\n" +
                                        $"Private Exponent (d): {BitConverter.ToString(parameters.D).Replace("-", "")}\r\n\r\n" +
                                        $"P: {BitConverter.ToString(parameters.P).Replace("-", "")}\r\n\r\n" +
                                        $"Q: {BitConverter.ToString(parameters.Q).Replace("-", "")}";
                }

                lblKeySize.Text = $"Размер ключа: {KEY_SIZE} бит";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении ключей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Шифрование сообщения
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string plainText = txtInput.Text.Trim();
                if (string.IsNullOrEmpty(plainText))
                {
                    MessageBox.Show("Введите сообщение для шифрования", "Предупреждение",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Конвертируем текст в байты
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

                // Шифруем
                byte[] encryptedBytes = rsaProvider.Encrypt(plainBytes, true);

                // Конвертируем в Base64 для отображения
                txtEncrypted.Text = Convert.ToBase64String(encryptedBytes);

                // Показываем также в HEX формате
                txtEncryptedHex.Text = BitConverter.ToString(encryptedBytes).Replace("-", " ");

                lblEncryptionStatus.Text = "✓ Сообщение успешно зашифровано!";
                lblEncryptionStatus.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при шифровании: {ex.Message}\n\n" +
                    "Возможно, сообщение слишком длинное для данного размера ключа.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                lblEncryptionStatus.Text = "✗ Ошибка шифрования";
                lblEncryptionStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Дешифрование сообщения
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string encryptedText = txtEncrypted.Text.Trim();
                if (string.IsNullOrEmpty(encryptedText))
                {
                    MessageBox.Show("Нет зашифрованного сообщения для дешифрования",
                        "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Конвертируем из Base64 в байты
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

                // Дешифруем
                byte[] decryptedBytes = rsaProvider.Decrypt(encryptedBytes, true);

                // Конвертируем обратно в текст
                txtDecrypted.Text = Encoding.UTF8.GetString(decryptedBytes);

                // Проверка: соответствует ли дешифрованный текст исходному?
                if (txtDecrypted.Text == txtInput.Text)
                {
                    lblDecryptionStatus.Text = "✓ Дешифрование успешно! D(E(m)) = m ✓";
                    lblDecryptionStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblDecryptionStatus.Text = "⚠ Дешифровано, но не совпадает с исходным";
                    lblDecryptionStatus.ForeColor = System.Drawing.Color.Orange;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат зашифрованных данных. Убедитесь, что это корректная Base64 строка.",
                    "Ошибка формата", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при дешифровании: {ex.Message}\n\n" +
                    "Возможно, используется неправильный закрытый ключ.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                lblDecryptionStatus.Text = "✗ Ошибка дешифрования";
                lblDecryptionStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Генерация новых ключей
        private void btnGenerateKeys_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем новый провайдер с новыми ключами
                rsaProvider = new RSACryptoServiceProvider(KEY_SIZE);
                UpdateKeyDisplay();

                // Очищаем поля
                txtInput.Clear();
                txtEncrypted.Clear();
                txtEncryptedHex.Clear();
                txtDecrypted.Clear();

                lblEncryptionStatus.Text = "Готов к работе";
                lblEncryptionStatus.ForeColor = System.Drawing.Color.Black;
                lblDecryptionStatus.Text = "Готов к работе";
                lblDecryptionStatus.ForeColor = System.Drawing.Color.Black;

                MessageBox.Show("Новая пара ключей RSA успешно сгенерирована!",
                    "Генерация ключей", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при генерации ключей: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Копировать открытый ключ в буфер обмена
        private void btnCopyPublicKey_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPublicKey.Text))
            {
                Clipboard.SetText(txtPublicKey.Text);
                MessageBox.Show("Открытый ключ скопирован в буфер обмена",
                    "Копирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Копировать закрытый ключ в буфер обмена
        private void btnCopyPrivateKey_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrivateKey.Text))
            {
                Clipboard.SetText(txtPrivateKey.Text);
                MessageBox.Show("Закрытый ключ скопирован в буфер обмена",
                    "Копирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Копировать шифротекст
        private void btnCopyEncrypted_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEncrypted.Text))
            {
                Clipboard.SetText(txtEncrypted.Text);
                MessageBox.Show("Зашифрованное сообщение скопировано в буфер обмена",
                    "Копирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Очистить все поля
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            txtInput.Clear();
            txtEncrypted.Clear();
            txtEncryptedHex.Clear();
            txtDecrypted.Clear();

            lblEncryptionStatus.Text = "Готов к работе";
            lblEncryptionStatus.ForeColor = System.Drawing.Color.Black;
            lblDecryptionStatus.Text = "Готов к работе";
            lblDecryptionStatus.ForeColor = System.Drawing.Color.Black;
        }

        // Сохранить ключи в файл
        private void btnSaveKeys_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "XML файлы (*.xml)|*.xml|Все файлы (*.*)|*.*";
                saveDialog.DefaultExt = "xml";
                saveDialog.FileName = "RSAKeys.xml";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlString = rsaProvider.ToXmlString(true);
                    System.IO.File.WriteAllText(saveDialog.FileName, xmlString);
                    MessageBox.Show($"Ключи сохранены в файл:\n{saveDialog.FileName}",
                        "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении ключей: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузить ключи из файла
        private void btnLoadKeys_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "XML файлы (*.xml)|*.xml|Все файлы (*.*)|*.*";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlString = System.IO.File.ReadAllText(openDialog.FileName);
                    rsaProvider.FromXmlString(xmlString);
                    UpdateKeyDisplay();
                    MessageBox.Show($"Ключи загружены из файла:\n{openDialog.FileName}",
                        "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке ключей: {ex.Message}\n\n" +
                    "Убедитесь, что файл содержит корректные RSA ключи.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}