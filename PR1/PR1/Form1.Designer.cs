namespace PR1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.TextBox txtEncrypted;
        private System.Windows.Forms.TextBox txtEncryptedHex;
        private System.Windows.Forms.TextBox txtDecrypted;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnGenerateKeys;
        private System.Windows.Forms.Button btnCopyPublicKey;
        private System.Windows.Forms.Button btnCopyPrivateKey;
        private System.Windows.Forms.Button btnCopyEncrypted;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnSaveKeys;
        private System.Windows.Forms.Button btnLoadKeys;
        private System.Windows.Forms.Label lblKeySize;
        private System.Windows.Forms.Label lblEncryptionStatus;
        private System.Windows.Forms.Label lblDecryptionStatus;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.GroupBox grpKeys;
        private System.Windows.Forms.GroupBox grpEncryption;
        private System.Windows.Forms.GroupBox grpDecryption;
        private System.Windows.Forms.GroupBox grpActions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtPublicKey = new System.Windows.Forms.TextBox();
            this.txtPrivateKey = new System.Windows.Forms.TextBox();
            this.txtEncrypted = new System.Windows.Forms.TextBox();
            this.txtEncryptedHex = new System.Windows.Forms.TextBox();
            this.txtDecrypted = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnGenerateKeys = new System.Windows.Forms.Button();
            this.btnCopyPublicKey = new System.Windows.Forms.Button();
            this.btnCopyPrivateKey = new System.Windows.Forms.Button();
            this.btnCopyEncrypted = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnSaveKeys = new System.Windows.Forms.Button();
            this.btnLoadKeys = new System.Windows.Forms.Button();
            this.lblKeySize = new System.Windows.Forms.Label();
            this.lblEncryptionStatus = new System.Windows.Forms.Label();
            this.lblDecryptionStatus = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.grpKeys = new System.Windows.Forms.GroupBox();
            this.grpEncryption = new System.Windows.Forms.GroupBox();
            this.grpDecryption = new System.Windows.Forms.GroupBox();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.grpInput.SuspendLayout();
            this.grpKeys.SuspendLayout();
            this.grpEncryption.SuspendLayout();
            this.grpDecryption.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();

            // Form1
            this.ClientSize = new System.Drawing.Size(1000, 900);
            this.Text = "RSA Криптосистема (Модель Осипяна В.О.)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;

            // grpInput
            this.grpInput.Text = "1. Исходное сообщение (M)";
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Size = new System.Drawing.Size(976, 100);
            this.grpInput.BackColor = System.Drawing.Color.AliceBlue;

            // txtInput
            this.txtInput.Location = new System.Drawing.Point(6, 25);
            this.txtInput.Size = new System.Drawing.Size(964, 25);
            this.txtInput.Multiline = true;
            this.txtInput.Height = 60;
            this.txtInput.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtInput.Text = "Введите сообщение для шифрования...";

            // grpKeys
            this.grpKeys.Text = "2. Ключи RSA";
            this.grpKeys.Location = new System.Drawing.Point(12, 118);
            this.grpKeys.Size = new System.Drawing.Size(976, 250);
            this.grpKeys.BackColor = System.Drawing.Color.LightGoldenrodYellow;

            // lblKeySize
            this.lblKeySize.Text = "Размер ключа: 2048 бит";
            this.lblKeySize.Location = new System.Drawing.Point(6, 20);
            this.lblKeySize.Size = new System.Drawing.Size(300, 25);
            this.lblKeySize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // txtPublicKey
            this.txtPublicKey.Location = new System.Drawing.Point(6, 50);
            this.txtPublicKey.Size = new System.Drawing.Size(475, 180);
            this.txtPublicKey.Multiline = true;
            this.txtPublicKey.ReadOnly = true;
            this.txtPublicKey.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtPublicKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPublicKey.BackColor = System.Drawing.Color.White;
            this.txtPublicKey.Text = "Открытый ключ будет сгенерирован автоматически";

            // txtPrivateKey
            this.txtPrivateKey.Location = new System.Drawing.Point(495, 50);
            this.txtPrivateKey.Size = new System.Drawing.Size(475, 180);
            this.txtPrivateKey.Multiline = true;
            this.txtPrivateKey.ReadOnly = true;
            this.txtPrivateKey.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtPrivateKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrivateKey.BackColor = System.Drawing.Color.LightYellow;
            this.txtPrivateKey.Text = "Закрытый ключ будет сгенерирован автоматически";

            // btnCopyPublicKey
            this.btnCopyPublicKey.Text = "📋 Копировать открытый ключ";
            this.btnCopyPublicKey.Location = new System.Drawing.Point(6, 235);
            this.btnCopyPublicKey.Size = new System.Drawing.Size(200, 30);
            this.btnCopyPublicKey.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCopyPublicKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyPublicKey.Click += new System.EventHandler(this.btnCopyPublicKey_Click);

            // btnCopyPrivateKey
            this.btnCopyPrivateKey.Text = "🔐 Копировать закрытый ключ";
            this.btnCopyPrivateKey.Location = new System.Drawing.Point(212, 235);
            this.btnCopyPrivateKey.Size = new System.Drawing.Size(200, 30);
            this.btnCopyPrivateKey.BackColor = System.Drawing.Color.LightSalmon;
            this.btnCopyPrivateKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyPrivateKey.Click += new System.EventHandler(this.btnCopyPrivateKey_Click);

            // grpEncryption
            this.grpEncryption.Text = "3. Прямое преобразование E(m) -> Шифрование";
            this.grpEncryption.Location = new System.Drawing.Point(12, 374);
            this.grpEncryption.Size = new System.Drawing.Size(976, 180);
            this.grpEncryption.BackColor = System.Drawing.Color.LightCyan;

            // btnEncrypt
            this.btnEncrypt.Text = "🔒 ЗАШИФРОВАТЬ (E(m))";
            this.btnEncrypt.Location = new System.Drawing.Point(6, 20);
            this.btnEncrypt.Size = new System.Drawing.Size(200, 40);
            this.btnEncrypt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEncrypt.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEncrypt.ForeColor = System.Drawing.Color.White;
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);

            // txtEncrypted
            this.txtEncrypted.Location = new System.Drawing.Point(6, 70);
            this.txtEncrypted.Size = new System.Drawing.Size(964, 45);
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.ReadOnly = true;
            this.txtEncrypted.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtEncrypted.BackColor = System.Drawing.Color.White;
            this.txtEncrypted.Text = "Зашифрованное сообщение (Base64)";

            // txtEncryptedHex
            this.txtEncryptedHex.Location = new System.Drawing.Point(6, 120);
            this.txtEncryptedHex.Size = new System.Drawing.Size(964, 45);
            this.txtEncryptedHex.Multiline = true;
            this.txtEncryptedHex.ReadOnly = true;
            this.txtEncryptedHex.Font = new System.Drawing.Font("Consolas", 8F);
            this.txtEncryptedHex.BackColor = System.Drawing.Color.LightGray;
            this.txtEncryptedHex.Text = "Зашифрованное сообщение (HEX)";

            // btnCopyEncrypted
            this.btnCopyEncrypted.Text = "📋 Копировать шифротекст";
            this.btnCopyEncrypted.Location = new System.Drawing.Point(212, 20);
            this.btnCopyEncrypted.Size = new System.Drawing.Size(180, 40);
            this.btnCopyEncrypted.BackColor = System.Drawing.Color.LightBlue;
            this.btnCopyEncrypted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyEncrypted.Click += new System.EventHandler(this.btnCopyEncrypted_Click);

            // lblEncryptionStatus
            this.lblEncryptionStatus.Text = "Готов к работе";
            this.lblEncryptionStatus.Location = new System.Drawing.Point(400, 30);
            this.lblEncryptionStatus.Size = new System.Drawing.Size(300, 25);
            this.lblEncryptionStatus.Font = new System.Drawing.Font("Segoe UI", 9F);

            // grpDecryption
            this.grpDecryption.Text = "4. Обратное преобразование D(c) -> Дешифрование";
            this.grpDecryption.Location = new System.Drawing.Point(12, 560);
            this.grpDecryption.Size = new System.Drawing.Size(976, 150);
            this.grpDecryption.BackColor = System.Drawing.Color.MistyRose;

            // btnDecrypt
            this.btnDecrypt.Text = "🔓 ДЕШИФРОВАТЬ (D(c))";
            this.btnDecrypt.Location = new System.Drawing.Point(6, 25);
            this.btnDecrypt.Size = new System.Drawing.Size(200, 40);
            this.btnDecrypt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDecrypt.BackColor = System.Drawing.Color.ForestGreen;
            this.btnDecrypt.ForeColor = System.Drawing.Color.White;
            this.btnDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);

            // txtDecrypted
            this.txtDecrypted.Location = new System.Drawing.Point(6, 75);
            this.txtDecrypted.Size = new System.Drawing.Size(964, 60);
            this.txtDecrypted.Multiline = true;
            this.txtDecrypted.ReadOnly = true;
            this.txtDecrypted.Font = new System.Drawing.Font("Consolas", 11F);
            this.txtDecrypted.BackColor = System.Drawing.Color.LightYellow;
            this.txtDecrypted.Text = "Расшифрованное сообщение";

            // lblDecryptionStatus
            this.lblDecryptionStatus.Text = "Готов к работе";
            this.lblDecryptionStatus.Location = new System.Drawing.Point(212, 35);
            this.lblDecryptionStatus.Size = new System.Drawing.Size(400, 25);
            this.lblDecryptionStatus.Font = new System.Drawing.Font("Segoe UI", 9F);

            // grpActions
            this.grpActions.Text = "5. Управление";
            this.grpActions.Location = new System.Drawing.Point(12, 716);
            this.grpActions.Size = new System.Drawing.Size(976, 70);
            this.grpActions.BackColor = System.Drawing.Color.Lavender;

            // btnGenerateKeys
            this.btnGenerateKeys.Text = "🔄 Генерировать новые ключи";
            this.btnGenerateKeys.Location = new System.Drawing.Point(6, 25);
            this.btnGenerateKeys.Size = new System.Drawing.Size(200, 35);
            this.btnGenerateKeys.BackColor = System.Drawing.Color.Orange;
            this.btnGenerateKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateKeys.Click += new System.EventHandler(this.btnGenerateKeys_Click);

            // btnSaveKeys
            this.btnSaveKeys.Text = "💾 Сохранить ключи";
            this.btnSaveKeys.Location = new System.Drawing.Point(212, 25);
            this.btnSaveKeys.Size = new System.Drawing.Size(150, 35);
            this.btnSaveKeys.BackColor = System.Drawing.Color.LightGreen;
            this.btnSaveKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveKeys.Click += new System.EventHandler(this.btnSaveKeys_Click);

            // btnLoadKeys
            this.btnLoadKeys.Text = "📂 Загрузить ключи";
            this.btnLoadKeys.Location = new System.Drawing.Point(368, 25);
            this.btnLoadKeys.Size = new System.Drawing.Size(150, 35);
            this.btnLoadKeys.BackColor = System.Drawing.Color.LightBlue;
            this.btnLoadKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadKeys.Click += new System.EventHandler(this.btnLoadKeys_Click);

            // btnClearAll
            this.btnClearAll.Text = "🧹 Очистить всё";
            this.btnClearAll.Location = new System.Drawing.Point(524, 25);
            this.btnClearAll.Size = new System.Drawing.Size(150, 35);
            this.btnClearAll.BackColor = System.Drawing.Color.LightGray;
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);

            // Form1
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.grpKeys);
            this.Controls.Add(this.grpEncryption);
            this.Controls.Add(this.grpDecryption);
            this.Controls.Add(this.grpActions);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpKeys.ResumeLayout(false);
            this.grpKeys.PerformLayout();
            this.grpEncryption.ResumeLayout(false);
            this.grpEncryption.PerformLayout();
            this.grpDecryption.ResumeLayout(false);
            this.grpDecryption.PerformLayout();
            this.grpActions.ResumeLayout(false);
            this.grpActions.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
