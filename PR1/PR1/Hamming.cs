using System;
using System.Windows.Forms;

namespace PR1
{
    public partial class Hamming : Form
    {
        private int[] informationBits = new int[4];  // 4 информационных бита
        private int[] codeWord = new int[7];          // 7-битное кодовое слово
        private bool isEncoded = false;                // Флаг, закодировано ли сообщение

        public Hamming()
        {
            InitializeComponent();
        }

        // Метод для кодирования информационного слова
        private void Encode()
        {
            // Чтение информационных битов из текстовых полей
            try
            {
                informationBits[0] = int.Parse(txtBit1.Text);
                informationBits[1] = int.Parse(txtBit2.Text);
                informationBits[2] = int.Parse(txtBit3.Text);
                informationBits[3] = int.Parse(txtBit4.Text);

                // Проверка, что все биты являются 0 или 1
                for (int i = 0; i < 4; i++)
                {
                    if (informationBits[i] != 0 && informationBits[i] != 1)
                    {
                        MessageBox.Show("Информационные биты должны быть 0 или 1!", "Ошибка ввода",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Пожалуйста, введите корректные биты (0 или 1)!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вычисление проверочных битов по алгоритму Хэмминга
            // Позиции проверочных битов: 1, 2, 4 (индексы 0, 1, 3 в массиве)
            // p1 (позиция 1): проверяет биты на позициях 1, 3, 5, 7 (индексы 0, 2, 4, 6)
            // p2 (позиция 2): проверяет биты на позициях 2, 3, 6, 7 (индексы 1, 2, 5, 6)
            // p3 (позиция 4): проверяет биты на позициях 4, 5, 6, 7 (индексы 3, 4, 5, 6)

            int p1 = informationBits[0] ^ informationBits[1] ^ informationBits[3];  // d1, d2, d4
            int p2 = informationBits[0] ^ informationBits[2] ^ informationBits[3];  // d1, d3, d4
            int p3 = informationBits[1] ^ informationBits[2] ^ informationBits[3];  // d2, d3, d4

            // Формирование кодового слова (7 бит)
            // Формат: [p1, p2, d1, p3, d2, d3, d4]
            codeWord[0] = p1;                     // позиция 1
            codeWord[1] = p2;                     // позиция 2
            codeWord[2] = informationBits[0];     // позиция 3 (d1)
            codeWord[3] = p3;                     // позиция 4
            codeWord[4] = informationBits[1];     // позиция 5 (d2)
            codeWord[5] = informationBits[2];     // позиция 6 (d3)
            codeWord[6] = informationBits[3];     // позиция 7 (d4)

            // Отображение кодового слова
            DisplayCodeWord();
            isEncoded = true;

            // Активация кнопок для дальнейших действий
            btnInjectError.Enabled = true;
            btnDecode.Enabled = true;

            // Очистка поля для ввода номера ошибки
            txtErrorPosition.Text = "";

            MessageBox.Show("Кодирование выполнено успешно!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Метод для отображения кодового слова
        private void DisplayCodeWord()
        {
            lblCodeWord.Text = string.Join("", codeWord);
            lblCodeWordWithPositions.Text = "";

            // Отображение с позициями
            for (int i = 0; i < 7; i++)
            {
                lblCodeWordWithPositions.Text += $"Позиция {i + 1}: {codeWord[i]}\r\n";
            }
        }

        // Метод для внесения ошибки
        private void InjectError()
        {
            if (!isEncoded)
            {
                MessageBox.Show("Сначала закодируйте сообщение!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int errorPosition;
            try
            {
                errorPosition = int.Parse(txtErrorPosition.Text);
                if (errorPosition < 1 || errorPosition > 7)
                {
                    MessageBox.Show("Номер позиции должен быть от 1 до 7!", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Пожалуйста, введите корректный номер позиции (1-7)!", "Ошибка ввода",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Инвертирование бита в указанной позиции
            codeWord[errorPosition - 1] ^= 1;

            // Отображение искаженного кодового слова
            DisplayCodeWord();

            MessageBox.Show($"Ошибка внесена в позицию {errorPosition}.", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Метод для декодирования и исправления ошибки
        private void DecodeAndCorrect()
        {
            if (!isEncoded)
            {
                MessageBox.Show("Сначала закодируйте сообщение!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Вычисление синдрома
            // s1 (позиция 1): проверка битов 1, 3, 5, 7
            // s2 (позиция 2): проверка битов 2, 3, 6, 7
            // s3 (позиция 4): проверка битов 4, 5, 6, 7

            int s1 = codeWord[0] ^ codeWord[2] ^ codeWord[4] ^ codeWord[6];  // p1 ^ d1 ^ d2 ^ d4
            int s2 = codeWord[1] ^ codeWord[2] ^ codeWord[5] ^ codeWord[6];  // p2 ^ d1 ^ d3 ^ d4
            int s3 = codeWord[3] ^ codeWord[4] ^ codeWord[5] ^ codeWord[6];  // p3 ^ d2 ^ d3 ^ d4

            int syndrome = (s3 << 2) | (s2 << 1) | s1;  // Формирование числа из синдрома

            lblSyndrome.Text = $"Синдром (s3,s2,s1): ({s3},{s2},{s1}) = {syndrome}";

            if (syndrome == 0)
            {
                lblErrorPosition.Text = "Ошибок не обнаружено";
                MessageBox.Show("Ошибок не обнаружено. Кодовое слово корректно.", "Результат декодирования",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lblErrorPosition.Text = $"Обнаружена ошибка в позиции {syndrome}";

                // Исправление ошибки
                codeWord[syndrome - 1] ^= 1;

                MessageBox.Show($"Обнаружена ошибка в позиции {syndrome}. Ошибка исправлена.",
                    "Результат декодирования", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Отображение исправленного кодового слова
                DisplayCodeWord();
            }

            // Извлечение информационных битов из исправленного кодового слова
            int[] decodedBits = new int[4];
            decodedBits[0] = codeWord[2];  // d1 на позиции 3
            decodedBits[1] = codeWord[4];  // d2 на позиции 5
            decodedBits[2] = codeWord[5];  // d3 на позиции 6
            decodedBits[3] = codeWord[6];  // d4 на позиции 7

            // Отображение восстановленных информационных битов
            txtDecodedBit1.Text = decodedBits[0].ToString();
            txtDecodedBit2.Text = decodedBits[1].ToString();
            txtDecodedBit3.Text = decodedBits[2].ToString();
            txtDecodedBit4.Text = decodedBits[3].ToString();

            // Вычисление числового значения
            int numericValue = decodedBits[0] * 8 + decodedBits[1] * 4 +
                               decodedBits[2] * 2 + decodedBits[3] * 1;
            lblNumericValue.Text = $"Числовое значение: {numericValue}";

            // Соответствие буквам (A=0, B=1, C=2, ...)
            if (numericValue >= 0 && numericValue <= 25)
            {
                char letter = (char)('A' + numericValue);
                lblLetter.Text = $"Соответствующая буква: {letter}";
            }
            else
            {
                lblLetter.Text = "Соответствующая буква: (нет, число > 25)";
            }
        }

        // Метод для очистки всех полей
        private void ClearAll()
        {
            txtBit1.Text = "";
            txtBit2.Text = "";
            txtBit3.Text = "";
            txtBit4.Text = "";

            txtDecodedBit1.Text = "";
            txtDecodedBit2.Text = "";
            txtDecodedBit3.Text = "";
            txtDecodedBit4.Text = "";

            txtErrorPosition.Text = "";
            lblCodeWord.Text = "";
            lblCodeWordWithPositions.Text = "";
            lblSyndrome.Text = "";
            lblErrorPosition.Text = "";
            lblNumericValue.Text = "";
            lblLetter.Text = "";

            isEncoded = false;
            btnInjectError.Enabled = false;
            btnDecode.Enabled = false;
        }

        // Метод для загрузки примера (буква 'C' как в лабораторной)
        private void LoadExample()
        {
            txtBit1.Text = "0";
            txtBit2.Text = "0";
            txtBit3.Text = "1";
            txtBit4.Text = "0";
        }

        // Обработчики событий кнопок
        private void BtnEncode_Click(object sender, EventArgs e)
        {
            Encode();
        }

        private void BtnInjectError_Click(object sender, EventArgs e)
        {
            InjectError();
        }

        private void BtnDecode_Click(object sender, EventArgs e)
        {
            DecodeAndCorrect();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void BtnExample_Click(object sender, EventArgs e)
        {
            ClearAll();
            LoadExample();
        }
    }
}