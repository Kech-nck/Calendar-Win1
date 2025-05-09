using System.Text;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        List<string> list = new(); //������ ������� ��� ����������
        List<string> eventsDate = new(); //������ ������� ��� �����������
        string eventsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "events.txt"); //���� � ����� ����������

        public Form1()
        {
            InitializeComponent();
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;

            label6.Text = DateTime.Now.ToString("D"); //��������� �������� label6 � label7
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
            label6.Text = String.Format($"{e.Start.ToLongDateString()}"); //label6 �������� �� ��������� ���� ���������
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            listBox1.Items.Add($"{label6.Text} - {textBox1.Text}"); //���� � ��� ������� �������� � listbox1
            list.Add($"{label6.Text} - {textBox1.Text}"); //���������� ������� � �������
            eventsDate.Add(label6.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string item in list) //������ ������� �� ������� list
            {
                try
                {
                    string newEvent = item;
                    File.AppendAllText(eventsFilePath, newEvent + Environment.NewLine); //���������� ������� � ����
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ���������� �������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            MessageBox.Show("������� ���� ���������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(eventsFilePath))
            {
                var allEvents = File.ReadAllLines(eventsFilePath); //������ ����� ����������
                if (allEvents.Length > 0)
                {
                    listBox1.Items.AddRange(allEvents); //���������� ���� ������� �� �����
                }
                else
                {
                    MessageBox.Show("���� ������� ����", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("���� ������� �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString("T"); //������ ������� ����� � label7
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string dateNow = DateTime.Now.ToString("D"); //������� ����
            int count = 0; //���������� ������� �� �������
            foreach (string item in eventsDate) //���������� ���� �� ������� eventsDate
            {
                if (item == dateNow)
                {
                    count += 1;
                }
            }

            if (count == 1)
            {
                MessageBox.Show($"{count} c������ �� ������� ({dateNow}) ��� ��������!");
            }

            if (count > 1)
            {
                MessageBox.Show($"{count} c������ �� ������� ({dateNow}) ��� ��������!");
            }
        }

        
    }
}
