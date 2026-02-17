namespace PR1
{
    partial class Form1
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
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtPhi = new System.Windows.Forms.TextBox();
            this.txtE = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtEncrypted = new System.Windows.Forms.TextBox();
            this.txtDecrypted = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtP
            this.txtP.Location = new System.Drawing.Point(120, 20);
            this.txtP.Size = new System.Drawing.Size(200, 23);

            // txtQ
            this.txtQ.Location = new System.Drawing.Point(120, 50);
            this.txtQ.Size = new System.Drawing.Size(200, 23);

            // txtN
            this.txtN.Location = new System.Drawing.Point(120, 80);
            this.txtN.Size = new System.Drawing.Size(200, 23);

            // txtPhi
            this.txtPhi.Location = new System.Drawing.Point(120, 110);
            this.txtPhi.Size = new System.Drawing.Size(200, 23);

            // txtE
            this.txtE.Location = new System.Drawing.Point(120, 140);
            this.txtE.Size = new System.Drawing.Size(200, 23);

            // txtD
            this.txtD.Location = new System.Drawing.Point(120, 170);
            this.txtD.Size = new System.Drawing.Size(200, 23);

            // txtMessage
            this.txtMessage.Location = new System.Drawing.Point(20, 220);
            this.txtMessage.Multiline = true;
            this.txtMessage.Size = new System.Drawing.Size(500, 60);

            // txtEncrypted
            this.txtEncrypted.Location = new System.Drawing.Point(20, 300);
            this.txtEncrypted.Multiline = true;
            this.txtEncrypted.Size = new System.Drawing.Size(500, 60);

            // txtDecrypted
            this.txtDecrypted.Location = new System.Drawing.Point(20, 380);
            this.txtDecrypted.Multiline = true;
            this.txtDecrypted.Size = new System.Drawing.Size(500, 60);

            // btnGenerate
            this.btnGenerate.Location = new System.Drawing.Point(350, 20);
            this.btnGenerate.Size = new System.Drawing.Size(170, 40);
            this.btnGenerate.Text = "Генерация ключей";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            // btnEncrypt
            this.btnEncrypt.Location = new System.Drawing.Point(20, 450);
            this.btnEncrypt.Size = new System.Drawing.Size(150, 40);
            this.btnEncrypt.Text = "Шифрование";
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);

            // btnDecrypt
            this.btnDecrypt.Location = new System.Drawing.Point(200, 450);
            this.btnDecrypt.Size = new System.Drawing.Size(150, 40);
            this.btnDecrypt.Text = "Расшифровка";
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);

            // Labels
            AddLabel("p:", 20, 20);
            AddLabel("q:", 20, 50);
            AddLabel("n:", 20, 80);
            AddLabel("φ(n):", 20, 110);
            AddLabel("e:", 20, 140);
            AddLabel("d:", 20, 170);
            AddLabel("Сообщение:", 20, 200);
            AddLabel("Зашифрованное:", 20, 280);
            AddLabel("Расшифрованное:", 20, 360);

            // Form1
            this.ClientSize = new System.Drawing.Size(560, 520);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.txtQ);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.txtPhi);
            this.Controls.Add(this.txtE);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtEncrypted);
            this.Controls.Add(this.txtDecrypted);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnDecrypt);
            this.Text = "RSA Demo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void AddLabel(string text, int x, int y)
        {
            System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
            lbl.Text = text;
            lbl.Location = new System.Drawing.Point(x, y + 3);
            lbl.AutoSize = true;
            this.Controls.Add(lbl);
        }

        #endregion

        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtPhi;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtEncrypted;
        private System.Windows.Forms.TextBox txtDecrypted;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
    }


}
