using System;
using System.Windows.Forms;

namespace isp_223k
{
    public partial class calc : Form
    {
        // Объявление основные переменных (private - здесь излишен, но в ООП важен)
        private string bufferInput;
        private double res;
        private double in0, in1;
        private char sym;

        private string system;

        // Основной конструктор 
        public calc()
        { 
            system = "dec";
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        // Main input field
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // binary 
        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "Binary";
            system = "bin";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            setText(button20);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            setText(button14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            setText(button15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            setText(button16);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            setText(button10);
        }

        // Clear button
        private void button2_Click(object sender, EventArgs e)
        {
            clearText();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            setText(button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            setText(button12);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setText(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setText(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            setText(button8);
        }

        // backspace
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Length > 0 ? textBox1.Text.Remove(textBox1.Text.Length - 1) : "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setSymbol(button5);
        }

        // "вычисление" результатов
        private string getResult()
        {
            string res = "";

            // Проверка на систему счисление с помощью тернарного оператора (?) 
            // И последующий перевод буферных переменных in0 и in1 в двоичную систему
            // (за это отвечает класс Convert)
            in0 = !system.Equals("dec") ? Convert.ToInt32(in0.ToString(), 2) : in0;
            in1 = !system.Equals("dec") ? Convert.ToInt32(in1.ToString(), 2) : in1;

            // сами вычисления
            switch (sym)
            {
                case '+': res = (in0 + in1).ToString(); break;
                case '-': res = (in0 - in1).ToString(); break;
                case '*': res = (in0 * in1).ToString(); break;
                case '/': res = (in0 / in1).ToString(); break;
            }

            // То же самое что было с in0 и in1, но уже с результатом(переменная res)
            if (system.Equals("dec")) return res;
            else if(system.Equals("bin"))
            {  
                // Проверка на негативность числа (двоичное число может быть негативный с помощью дополнительного числа 0 или 1
                // однако это не требуется => возвращает строку, что двоичное число не может быть меньше нуля
                
                return int.Parse(res) > 0 ? Convert.ToString(int.Parse(res), 2) : "Result smaller than 0"; 
            } else
            {
                // не войдовый метод обязан вернуть что либо, поэтому в любом ином случае возвращает дефолтную строку
                return "NaN";
            }
        }

        // result
        private void button19_Click(object sender, EventArgs e)
        {
            in1 = Double.Parse(textBox1.Text); 
            label2.Text = "";
            textBox1.Clear();
            // Отлавливаем исключения (возможность непредвиденного поведения программы)
            try
            {
                label2.Text = getResult().ToString();
            } catch (FormatException)
            {
                // Если что то пошло не так - вписать результат как неверный формат
                label2.Text = "Format incorrect";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            setSymbol(button9);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            setSymbol(button13);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            setSymbol(button17);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //setSymbol(button3); - // не важно
        }

        private void button18_Click(object sender, EventArgs e)
        {
            setText(button18);   
        }

        // Этот метод был создан в результате работы моей буйной фантазии, а также (как мне показалось)
        // для удобства многократного использования и дальнейшего расширения программы
        private void setSymbol(Button text)
        {
            if (text.Text.Equals("+")) sym = '+';
            else if (text.Text.Equals("-")) sym = '-';
            else if (text.Text.Equals("*")) sym = '*';
            else if (text.Text.Equals("/")) sym = '/';
            else if (text.Text.Equals("log")) sym = 'l';

            // Если введённый знак не имеет под собой основания(нету первого или второго числа), то ничего не делать
            in0 = textBox1.Text.Length != 0 ? Double.Parse(textBox1.Text) : in0;

            label2.Text = textBox1.Text;
            textBox1.Clear();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // кнопка изменения системы
            system = "dec";
            label1.Text = "Decimal";
        }

        private void clearText()
        {
            label2.Text = "Here would can ur ad";
            textBox1.Clear();
        }

        private void calc_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            label1.Text = "?";
        }

        // Те же причины создания, что и метод setSymbol
        private void setText(Button btn)
        {
            textBox1.Text += btn.Text;
            if(system.Equals("bin")) textBox1.Text = Convert.ToString(int.Parse(textBox1.Text), 2);
        }
    }
}
