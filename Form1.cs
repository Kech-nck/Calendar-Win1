using System.Text;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>();
        List<string> eventsList = new List<string>();
        string eventsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "events.txt");

        public Form1()
        {
            InitializeComponent();
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;

            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            timer2.Interval = 14000;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label6.Text = String.Format($"{e.Start.ToLongDateString()}");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (File.Exists(eventsFilePath))
                {
                    var allEvents = File.ReadAllLines(eventsFilePath);
                    if (allEvents.Length > 0)
                    {
                        Random rnd = new Random();
                        string randomEvent = allEvents[rnd.Next(allEvents.Length)];
                        listBox1.Items.Add($"{label6.Text} - {randomEvent} - добавлено в {label7.Text}");
                        listBox1.Refresh();
                        eventsList.Add(randomEvent);
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
            else
            {
                label8.Text = label6.Text;
                listBox1.Items.Add($"{label6.Text} - {textBox1.Text} - добавлено в {label7.Text}");
                listBox1.Refresh();
                eventsList.Add(textBox1.Text);
                list.Add(label8.Text);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongTimeString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string dateNow = DateTime.Now.ToShortDateString();
            int count = 0;
            foreach (string item in list)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                try
                {
                    string newEvent = $"{textBox1.Text}";
                    File.AppendAllText(eventsFilePath, newEvent + Environment.NewLine);
                    MessageBox.Show("Событие успешно сохранено в файл!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("Введите текст события!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
    }
}
