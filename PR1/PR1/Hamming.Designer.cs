namespace PR1
{
    partial class Hamming
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления формы
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblBit1;
        private System.Windows.Forms.TextBox txtBit1;
        private System.Windows.Forms.Label lblBit2;
        private System.Windows.Forms.TextBox txtBit2;
        private System.Windows.Forms.Label lblBit3;
        private System.Windows.Forms.TextBox txtBit3;
        private System.Windows.Forms.Label lblBit4;
        private System.Windows.Forms.TextBox txtBit4;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnExample;

        private System.Windows.Forms.GroupBox grpCodeWord;
        private System.Windows.Forms.Label lblCodeWordTitle;
        private System.Windows.Forms.Label lblCodeWord;
        private System.Windows.Forms.Label lblCodeWordWithPositions;

        private System.Windows.Forms.GroupBox grpError;
        private System.Windows.Forms.Label lblErrorPosition;
        private System.Windows.Forms.TextBox txtErrorPosition;
        private System.Windows.Forms.Button btnInjectError;

        private System.Windows.Forms.GroupBox grpDecode;
        private System.Windows.Forms.Label lblSyndrome;
        private System.Windows.Forms.Label lblErrorPositionResult;
        private System.Windows.Forms.Label lblDecodedBits;
        private System.Windows.Forms.TextBox txtDecodedBit1;
        private System.Windows.Forms.TextBox txtDecodedBit2;
        private System.Windows.Forms.TextBox txtDecodedBit3;
        private System.Windows.Forms.TextBox txtDecodedBit4;
        private System.Windows.Forms.Label lblNumericValue;
        private System.Windows.Forms.Label lblLetter;
        private System.Windows.Forms.Button btnDecode;

        private System.Windows.Forms.Button btnClear;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.lblBit1 = new System.Windows.Forms.Label();
            this.txtBit1 = new System.Windows.Forms.TextBox();
            this.lblBit2 = new System.Windows.Forms.Label();
            this.txtBit2 = new System.Windows.Forms.TextBox();
            this.lblBit3 = new System.Windows.Forms.Label();
            this.txtBit3 = new System.Windows.Forms.TextBox();
            this.lblBit4 = new System.Windows.Forms.Label();
            this.txtBit4 = new System.Windows.Forms.TextBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.btnExample = new System.Windows.Forms.Button();
            this.grpCodeWord = new System.Windows.Forms.GroupBox();
            this.lblCodeWordTitle = new System.Windows.Forms.Label();
            this.lblCodeWord = new System.Windows.Forms.Label();
            this.lblCodeWordWithPositions = new System.Windows.Forms.Label();
            this.grpError = new System.Windows.Forms.GroupBox();
            this.lblErrorPosition = new System.Windows.Forms.Label();
            this.txtErrorPosition = new System.Windows.Forms.TextBox();
            this.btnInjectError = new System.Windows.Forms.Button();
            this.grpDecode = new System.Windows.Forms.GroupBox();
            this.lblSyndrome = new System.Windows.Forms.Label();
            this.lblErrorPositionResult = new System.Windows.Forms.Label();
            this.lblDecodedBits = new System.Windows.Forms.Label();
            this.txtDecodedBit1 = new System.Windows.Forms.TextBox();
            this.txtDecodedBit2 = new System.Windows.Forms.TextBox();
            this.txtDecodedBit3 = new System.Windows.Forms.TextBox();
            this.txtDecodedBit4 = new System.Windows.Forms.TextBox();
            this.lblNumericValue = new System.Windows.Forms.Label();
            this.lblLetter = new System.Windows.Forms.Label();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.grpInput.SuspendLayout();
            this.grpCodeWord.SuspendLayout();
            this.grpError.SuspendLayout();
            this.grpDecode.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(200, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Код Хэмминга (7,4) с исправлением ошибок";

            // grpInput
            this.grpInput.Controls.Add(this.lblBit1);
            this.grpInput.Controls.Add(this.txtBit1);
            this.grpInput.Controls.Add(this.lblBit2);
            this.grpInput.Controls.Add(this.txtBit2);
            this.grpInput.Controls.Add(this.lblBit3);
            this.grpInput.Controls.Add(this.txtBit3);
            this.grpInput.Controls.Add(this.lblBit4);
            this.grpInput.Controls.Add(this.txtBit4);
            this.grpInput.Controls.Add(this.btnEncode);
            this.grpInput.Controls.Add(this.btnExample);
            this.grpInput.Location = new System.Drawing.Point(20, 60);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(280, 200);
            this.grpInput.TabIndex = 1;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Входные данные (4 бита)";

            // lblBit1
            this.lblBit1.AutoSize = true;
            this.lblBit1.Location = new System.Drawing.Point(20, 35);
            this.lblBit1.Name = "lblBit1";
            this.lblBit1.Size = new System.Drawing.Size(43, 13);
            this.lblBit1.TabIndex = 0;
            this.lblBit1.Text = "Бит 1:";

            // txtBit1
            this.txtBit1.Location = new System.Drawing.Point(80, 32);
            this.txtBit1.Name = "txtBit1";
            this.txtBit1.Size = new System.Drawing.Size(50, 20);
            this.txtBit1.TabIndex = 1;
            this.txtBit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblBit2
            this.lblBit2.AutoSize = true;
            this.lblBit2.Location = new System.Drawing.Point(20, 65);
            this.lblBit2.Name = "lblBit2";
            this.lblBit2.Size = new System.Drawing.Size(43, 13);
            this.lblBit2.TabIndex = 2;
            this.lblBit2.Text = "Бит 2:";

            // txtBit2
            this.txtBit2.Location = new System.Drawing.Point(80, 62);
            this.txtBit2.Name = "txtBit2";
            this.txtBit2.Size = new System.Drawing.Size(50, 20);
            this.txtBit2.TabIndex = 3;
            this.txtBit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblBit3
            this.lblBit3.AutoSize = true;
            this.lblBit3.Location = new System.Drawing.Point(20, 95);
            this.lblBit3.Name = "lblBit3";
            this.lblBit3.Size = new System.Drawing.Size(43, 13);
            this.lblBit3.TabIndex = 4;
            this.lblBit3.Text = "Бит 3:";

            // txtBit3
            this.txtBit3.Location = new System.Drawing.Point(80, 92);
            this.txtBit3.Name = "txtBit3";
            this.txtBit3.Size = new System.Drawing.Size(50, 20);
            this.txtBit3.TabIndex = 5;
            this.txtBit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblBit4
            this.lblBit4.AutoSize = true;
            this.lblBit4.Location = new System.Drawing.Point(20, 125);
            this.lblBit4.Name = "lblBit4";
            this.lblBit4.Size = new System.Drawing.Size(43, 13);
            this.lblBit4.TabIndex = 6;
            this.lblBit4.Text = "Бит 4:";

            // txtBit4
            this.txtBit4.Location = new System.Drawing.Point(80, 122);
            this.txtBit4.Name = "txtBit4";
            this.txtBit4.Size = new System.Drawing.Size(50, 20);
            this.txtBit4.TabIndex = 7;
            this.txtBit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // btnEncode
            this.btnEncode.Location = new System.Drawing.Point(150, 120);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(100, 30);
            this.btnEncode.TabIndex = 8;
            this.btnEncode.Text = "Кодировать";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.BtnEncode_Click);

            // btnExample
            this.btnExample.Location = new System.Drawing.Point(150, 160);
            this.btnExample.Name = "btnExample";
            this.btnExample.Size = new System.Drawing.Size(100, 30);
            this.btnExample.TabIndex = 9;
            this.btnExample.Text = "Пример (C)";
            this.btnExample.UseVisualStyleBackColor = true;
            this.btnExample.Click += new System.EventHandler(this.BtnExample_Click);

            // grpCodeWord
            this.grpCodeWord.Controls.Add(this.lblCodeWordTitle);
            this.grpCodeWord.Controls.Add(this.lblCodeWord);
            this.grpCodeWord.Controls.Add(this.lblCodeWordWithPositions);
            this.grpCodeWord.Location = new System.Drawing.Point(320, 60);
            this.grpCodeWord.Name = "grpCodeWord";
            this.grpCodeWord.Size = new System.Drawing.Size(380, 200);
            this.grpCodeWord.TabIndex = 2;
            this.grpCodeWord.TabStop = false;
            this.grpCodeWord.Text = "Кодовое слово (7 бит)";

            // lblCodeWordTitle
            this.lblCodeWordTitle.AutoSize = true;
            this.lblCodeWordTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodeWordTitle.Location = new System.Drawing.Point(10, 25);
            this.lblCodeWordTitle.Name = "lblCodeWordTitle";
            this.lblCodeWordTitle.Size = new System.Drawing.Size(93, 15);
            this.lblCodeWordTitle.TabIndex = 0;
            this.lblCodeWordTitle.Text = "Кодовое слово:";

            // lblCodeWord
            this.lblCodeWord.AutoSize = true;
            this.lblCodeWord.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.lblCodeWord.Location = new System.Drawing.Point(110, 23);
            this.lblCodeWord.Name = "lblCodeWord";
            this.lblCodeWord.Size = new System.Drawing.Size(0, 18);
            this.lblCodeWord.TabIndex = 1;

            // lblCodeWordWithPositions
            this.lblCodeWordWithPositions.AutoSize = true;
            this.lblCodeWordWithPositions.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblCodeWordWithPositions.Location = new System.Drawing.Point(10, 50);
            this.lblCodeWordWithPositions.Name = "lblCodeWordWithPositions";
            this.lblCodeWordWithPositions.Size = new System.Drawing.Size(0, 14);
            this.lblCodeWordWithPositions.TabIndex = 2;

            // grpError
            this.grpError.Controls.Add(this.lblErrorPosition);
            this.grpError.Controls.Add(this.txtErrorPosition);
            this.grpError.Controls.Add(this.btnInjectError);
            this.grpError.Location = new System.Drawing.Point(20, 280);
            this.grpError.Name = "grpError";
            this.grpError.Size = new System.Drawing.Size(280, 100);
            this.grpError.TabIndex = 3;
            this.grpError.TabStop = false;
            this.grpError.Text = "Внесение ошибки";

            // lblErrorPosition
            this.lblErrorPosition.AutoSize = true;
            this.lblErrorPosition.Location = new System.Drawing.Point(20, 35);
            this.lblErrorPosition.Name = "lblErrorPosition";
            this.lblErrorPosition.Size = new System.Drawing.Size(148, 13);
            this.lblErrorPosition.TabIndex = 0;
            this.lblErrorPosition.Text = "Номер позиции для ошибки:";

            // txtErrorPosition
            this.txtErrorPosition.Location = new System.Drawing.Point(180, 32);
            this.txtErrorPosition.Name = "txtErrorPosition";
            this.txtErrorPosition.Size = new System.Drawing.Size(70, 20);
            this.txtErrorPosition.TabIndex = 1;
            this.txtErrorPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // btnInjectError
            this.btnInjectError.Enabled = false;
            this.btnInjectError.Location = new System.Drawing.Point(80, 60);
            this.btnInjectError.Name = "btnInjectError";
            this.btnInjectError.Size = new System.Drawing.Size(120, 30);
            this.btnInjectError.TabIndex = 2;
            this.btnInjectError.Text = "Внести ошибку";
            this.btnInjectError.UseVisualStyleBackColor = true;
            this.btnInjectError.Click += new System.EventHandler(this.BtnInjectError_Click);

            // grpDecode
            this.grpDecode.Controls.Add(this.lblSyndrome);
            this.grpDecode.Controls.Add(this.lblErrorPositionResult);
            this.grpDecode.Controls.Add(this.lblDecodedBits);
            this.grpDecode.Controls.Add(this.txtDecodedBit1);
            this.grpDecode.Controls.Add(this.txtDecodedBit2);
            this.grpDecode.Controls.Add(this.txtDecodedBit3);
            this.grpDecode.Controls.Add(this.txtDecodedBit4);
            this.grpDecode.Controls.Add(this.lblNumericValue);
            this.grpDecode.Controls.Add(this.lblLetter);
            this.grpDecode.Controls.Add(this.btnDecode);
            this.grpDecode.Location = new System.Drawing.Point(320, 280);
            this.grpDecode.Name = "grpDecode";
            this.grpDecode.Size = new System.Drawing.Size(380, 200);
            this.grpDecode.TabIndex = 4;
            this.grpDecode.TabStop = false;
            this.grpDecode.Text = "Декодирование и исправление";

            // lblSyndrome
            this.lblSyndrome.AutoSize = true;
            this.lblSyndrome.Location = new System.Drawing.Point(10, 25);
            this.lblSyndrome.Name = "lblSyndrome";
            this.lblSyndrome.Size = new System.Drawing.Size(56, 13);
            this.lblSyndrome.TabIndex = 0;
            this.lblSyndrome.Text = "Синдром: ";

            // lblErrorPositionResult
            this.lblErrorPositionResult.AutoSize = true;
            this.lblErrorPositionResult.Location = new System.Drawing.Point(10, 45);
            this.lblErrorPositionResult.Name = "lblErrorPositionResult";
            this.lblErrorPositionResult.Size = new System.Drawing.Size(104, 13);
            this.lblErrorPositionResult.TabIndex = 1;
            this.lblErrorPositionResult.Text = "Позиция ошибки: ---";

            // lblDecodedBits
            this.lblDecodedBits.AutoSize = true;
            this.lblDecodedBits.Location = new System.Drawing.Point(10, 70);
            this.lblDecodedBits.Name = "lblDecodedBits";
            this.lblDecodedBits.Size = new System.Drawing.Size(120, 13);
            this.lblDecodedBits.TabIndex = 2;
            this.lblDecodedBits.Text = "Восстановленные биты:";

            // txtDecodedBit1
            this.txtDecodedBit1.Location = new System.Drawing.Point(140, 67);
            this.txtDecodedBit1.Name = "txtDecodedBit1";
            this.txtDecodedBit1.ReadOnly = true;
            this.txtDecodedBit1.Size = new System.Drawing.Size(40, 20);
            this.txtDecodedBit1.TabIndex = 3;
            this.txtDecodedBit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // txtDecodedBit2
            this.txtDecodedBit2.Location = new System.Drawing.Point(190, 67);
            this.txtDecodedBit2.Name = "txtDecodedBit2";
            this.txtDecodedBit2.ReadOnly = true;
            this.txtDecodedBit2.Size = new System.Drawing.Size(40, 20);
            this.txtDecodedBit2.TabIndex = 4;
            this.txtDecodedBit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // txtDecodedBit3
            this.txtDecodedBit3.Location = new System.Drawing.Point(240, 67);
            this.txtDecodedBit3.Name = "txtDecodedBit3";
            this.txtDecodedBit3.ReadOnly = true;
            this.txtDecodedBit3.Size = new System.Drawing.Size(40, 20);
            this.txtDecodedBit3.TabIndex = 5;
            this.txtDecodedBit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // txtDecodedBit4
            this.txtDecodedBit4.Location = new System.Drawing.Point(290, 67);
            this.txtDecodedBit4.Name = "txtDecodedBit4";
            this.txtDecodedBit4.ReadOnly = true;
            this.txtDecodedBit4.Size = new System.Drawing.Size(40, 20);
            this.txtDecodedBit4.TabIndex = 6;
            this.txtDecodedBit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblNumericValue
            this.lblNumericValue.AutoSize = true;
            this.lblNumericValue.Location = new System.Drawing.Point(10, 100);
            this.lblNumericValue.Name = "lblNumericValue";
            this.lblNumericValue.Size = new System.Drawing.Size(100, 13);
            this.lblNumericValue.TabIndex = 7;
            this.lblNumericValue.Text = "Числовое значение:";

            // lblLetter
            this.lblLetter.AutoSize = true;
            this.lblLetter.Location = new System.Drawing.Point(10, 125);
            this.lblLetter.Name = "lblLetter";
            this.lblLetter.Size = new System.Drawing.Size(116, 13);
            this.lblLetter.TabIndex = 8;
            this.lblLetter.Text = "Соответствующая буква:";

            // btnDecode
            this.btnDecode.Enabled = false;
            this.btnDecode.Location = new System.Drawing.Point(130, 160);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(120, 30);
            this.btnDecode.TabIndex = 9;
            this.btnDecode.Text = "Декодировать и исправить";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.BtnDecode_Click);

            // btnClear
            this.btnClear.Location = new System.Drawing.Point(550, 500);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 30);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Очистить всё";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);

            // Hamming
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 550);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpDecode);
            this.Controls.Add(this.grpError);
            this.Controls.Add(this.grpCodeWord);
            this.Controls.Add(this.grpInput);
            this.Controls.Add(this.lblTitle);
            this.Name = "Hamming";
            this.Text = "Код Хэмминга (7,4) с исправлением ошибок";
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpCodeWord.ResumeLayout(false);
            this.grpCodeWord.PerformLayout();
            this.grpError.ResumeLayout(false);
            this.grpError.PerformLayout();
            this.grpDecode.ResumeLayout(false);
            this.grpDecode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}