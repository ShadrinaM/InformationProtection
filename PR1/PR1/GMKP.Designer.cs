namespace PR1
{
    partial class GMKP
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            numericUpDownN = new NumericUpDown();
            numericUpDownB = new NumericUpDown();
            btnGenerateSeq = new Button();
            txtSeq = new TextBox();
            btnGenerateKeys = new Button();
            txtPublicKey = new TextBox();
            txtPrivateKey = new TextBox();
            txtMessage = new TextBox();
            btnEncrypt = new Button();
            txtCipher = new TextBox();
            btnDecrypt = new Button();
            txtDecrypted = new TextBox();
            lblStatus = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownN
            // 
            numericUpDownN.Location = new Point(180, 20);
            numericUpDownN.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numericUpDownN.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDownN.Name = "numericUpDownN";
            numericUpDownN.Size = new Size(120, 23);
            numericUpDownN.TabIndex = 0;
            numericUpDownN.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // numericUpDownB
            // 
            numericUpDownB.Location = new Point(180, 50);
            numericUpDownB.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownB.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDownB.Name = "numericUpDownB";
            numericUpDownB.Size = new Size(120, 23);
            numericUpDownB.TabIndex = 1;
            numericUpDownB.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnGenerateSeq
            // 
            btnGenerateSeq.Location = new Point(320, 20);
            btnGenerateSeq.Name = "btnGenerateSeq";
            btnGenerateSeq.Size = new Size(180, 27);
            btnGenerateSeq.TabIndex = 2;
            btnGenerateSeq.Text = "Сгенерировать последовательность";
            btnGenerateSeq.UseVisualStyleBackColor = true;
            btnGenerateSeq.Click += btnGenerateSeq_Click;
            // 
            // txtSeq
            // 
            txtSeq.Location = new Point(180, 85);
            txtSeq.Name = "txtSeq";
            txtSeq.ReadOnly = true;
            txtSeq.Size = new Size(440, 23);
            txtSeq.TabIndex = 3;
            // 
            // btnGenerateKeys
            // 
            btnGenerateKeys.Enabled = false;
            btnGenerateKeys.Location = new Point(320, 120);
            btnGenerateKeys.Name = "btnGenerateKeys";
            btnGenerateKeys.Size = new Size(180, 27);
            btnGenerateKeys.TabIndex = 4;
            btnGenerateKeys.Text = "Сгенерировать ключи";
            btnGenerateKeys.UseVisualStyleBackColor = true;
            btnGenerateKeys.Click += btnGenerateKeys_Click;
            // 
            // txtPublicKey
            // 
            txtPublicKey.Location = new Point(180, 155);
            txtPublicKey.Multiline = true;
            txtPublicKey.Name = "txtPublicKey";
            txtPublicKey.ReadOnly = true;
            txtPublicKey.ScrollBars = ScrollBars.Vertical;
            txtPublicKey.Size = new Size(440, 50);
            txtPublicKey.TabIndex = 5;
            // 
            // txtPrivateKey
            // 
            txtPrivateKey.Location = new Point(180, 215);
            txtPrivateKey.Multiline = true;
            txtPrivateKey.Name = "txtPrivateKey";
            txtPrivateKey.ReadOnly = true;
            txtPrivateKey.ScrollBars = ScrollBars.Vertical;
            txtPrivateKey.Size = new Size(440, 80);
            txtPrivateKey.TabIndex = 6;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(180, 305);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(440, 60);
            txtMessage.TabIndex = 7;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Enabled = false;
            btnEncrypt.Location = new Point(20, 395);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(150, 40);
            btnEncrypt.TabIndex = 8;
            btnEncrypt.Text = "Зашифровать";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // txtCipher
            // 
            txtCipher.Location = new Point(180, 375);
            txtCipher.Multiline = true;
            txtCipher.Name = "txtCipher";
            txtCipher.ReadOnly = true;
            txtCipher.Size = new Size(440, 60);
            txtCipher.TabIndex = 9;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Enabled = false;
            btnDecrypt.Location = new Point(20, 465);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(150, 40);
            btnDecrypt.TabIndex = 10;
            btnDecrypt.Text = "Расшифровать";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // txtDecrypted
            // 
            txtDecrypted.Location = new Point(180, 445);
            txtDecrypted.Multiline = true;
            txtDecrypted.Name = "txtDecrypted";
            txtDecrypted.ReadOnly = true;
            txtDecrypted.Size = new Size(440, 60);
            txtDecrypted.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(20, 520);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 22);
            label1.Name = "label1";
            label1.Size = new Size(147, 15);
            label1.TabIndex = 13;
            label1.Text = "Длина последовательности:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 88);
            label2.Name = "label2";
            label2.Size = new Size(304, 15);
            label2.TabIndex = 14;
            label2.Text = "Мультипликативная сверхвозрастающая (A):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 155);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 15;
            label3.Text = "Открытый ключ (W):";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 215);
            label4.Name = "label4";
            label4.Size = new Size(159, 15);
            label4.TabIndex = 16;
            label4.Text = "Закрытый ключ (A, p, t, t⁻¹):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 305);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 17;
            label5.Text = "Сообщение:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 375);
            label6.Name = "label6";
            label6.Size = new Size(164, 15);
            label6.TabIndex = 18;
            label6.Text = "Шифртекст (произведение):";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 448);
            label7.Name = "label7";
            label7.Size = new Size(176, 15);
            label7.TabIndex = 19;
            label7.Text = "Расшифрованное сообщение:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 52);
            label8.Name = "label8";
            label8.Size = new Size(96, 15);
            label8.TabIndex = 20;
            label8.Text = "Основание (B):";
            // 
            // GMKP
            // 
            ClientSize = new Size(660, 550);
            Controls.Add(numericUpDownN);
            Controls.Add(numericUpDownB);
            Controls.Add(btnGenerateSeq);
            Controls.Add(txtSeq);
            Controls.Add(btnGenerateKeys);
            Controls.Add(txtPublicKey);
            Controls.Add(txtPrivateKey);
            Controls.Add(txtMessage);
            Controls.Add(btnEncrypt);
            Controls.Add(txtCipher);
            Controls.Add(btnDecrypt);
            Controls.Add(txtDecrypted);
            Controls.Add(lblStatus);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Name = "GMKP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Алгоритм обобщённого мультипликативного рюкзака (GMKP)";
            ((System.ComponentModel.ISupportInitialize)numericUpDownN).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownN;
        private System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.Button btnGenerateSeq;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.Button btnGenerateKeys;
        private System.Windows.Forms.TextBox txtPublicKey;
        private System.Windows.Forms.TextBox txtPrivateKey;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtCipher;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtDecrypted;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}