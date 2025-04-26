using System.Text;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        List<string> list = new(); //массив событий для сохранений
        List<string> eventsDate = new(); //массив событий для уведомлений
        string eventsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "events.txt"); //путь к файлу сохранения

        public Form1()
        {
            InitializeComponent();
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;

            label6.Text = DateTime.Now.ToString("D"); //Начальные значения label6 и label7
            label7.Text = DateTime.Now.ToString("T");

            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            timer2.Interval = 14000;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label6.Text = String.Format($"{e.Start.ToLongDateString()}"); //label6 меняется на выбранную даты календаря
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            listBox1.Items.Add($"{label6.Text} - {textBox1.Text}"); //дата и имя события вводятся в listbox1
            list.Add($"{label6.Text} - {textBox1.Text}"); //добавление события в массивы
            eventsDate.Add(label6.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string item in list) //читает события из массива list
            {
                try
                {
                    string newEvent = item;
                    File.AppendAllText(eventsFilePath, newEvent + Environment.NewLine); //сохранение события в файл
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения события!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            MessageBox.Show("События были сохранены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(eventsFilePath))
            {
                var allEvents = File.ReadAllLines(eventsFilePath); //чтение файла сохранения
                if (allEvents.Length > 0)
                {
                    listBox1.Items.AddRange(allEvents); //добавление всех событий из файла
                }
                else
                {
                    MessageBox.Show("Файл событий пуст", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Файл событий не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("T"); //Держит текущее время в label7
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string dateNow = DateTime.Now.ToString("D"); //текущая дата
            int count = 0; //количество событий на сегодня
            foreach (string item in eventsDate) //сравнивает даты из массива eventsDate
            {
                if (item == dateNow)
                {
                    count += 1;
                }
            }

            if (count == 1)
            {
                MessageBox.Show($"{count} cобытие на сегодня ({dateNow}) уже началось!");
            }

            if (count > 1)
            {
                MessageBox.Show($"{count} cобытия на сегодня ({dateNow}) уже начались!");
            }
        }

        
    }
}
