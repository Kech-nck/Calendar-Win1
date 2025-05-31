using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Reflection.Emit;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        List<string> list = new List<string>();
        List<string> eventsDate = new List<string>();
        string eventsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "events.txt");
        int index = -1;

        public Form1()
        {
            InitializeComponent();
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;

            // Текущая дата
            label6.Text = DateTime.Now.ToString("D");

            // Таймер проверки событий
            timer2.Interval = 60000;
            timer2.Tick += timer2_Tick;
            timer2.Start();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label6.Text = e.Start.ToLongDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите название события!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string eventEntry = $"{label6.Text} - {textBox1.Text.Trim()}";
            listBox1.Items.Add(eventEntry);
            list.Add(eventEntry);
            eventsDate.Add(label6.Text);

            textBox1.Clear(); // Очищение поля
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (list.Count == 0)
                {
                    MessageBox.Show("Нет событий для сохранения!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                File.WriteAllLines(eventsFilePath, list); // Перезапись файла
                MessageBox.Show("События успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(eventsFilePath))
                {
                    MessageBox.Show("Файл событий не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var loadedEvents = File.ReadAllLines(eventsFilePath);
                if (loadedEvents.Length == 0)
                {
                    MessageBox.Show("Файл событий пуст!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                listBox1.Items.Clear();
                list.Clear();
                eventsDate.Clear();

                foreach (var line in loadedEvents)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        listBox1.Items.Add(line);
                        list.Add(line);

                        var dateEnd = line.IndexOf(" - ");
                        if (dateEnd > 0)
                        {
                            eventsDate.Add(line.Substring(0, dateEnd));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("D");
            int count = 0;

            foreach (string date in eventsDate)
            {
                if (date.Equals(today, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }

            if (count > 0)
            {
                string message = count == 1 ?
                    $"1 событие на сегодня ({today})!" :
                    $"{count} события на сегодня ({today})!";

                MessageBox.Show(message, "Напоминание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;

            string selected = listBox1.SelectedItem.ToString();
            int separatorPos = selected.IndexOf(" - ");

            if (separatorPos > 0)
            {
                textBox2.Text = selected.Substring(0, separatorPos);
                textBox3.Text = selected.Substring(separatorPos + 3); // +3 чтобы пропустить " - "
                index = listBox1.SelectedIndex;
            }
            else
            {
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (index == -1 || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Выберите событие и заполните оба поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string updatedEvent = $"{textBox2.Text.Trim()} - {textBox3.Text.Trim()}";
            listBox1.Items[index] = updatedEvent;
            list[index] = updatedEvent;

            eventsDate[index] = textBox2.Text.Trim();
        }
    }
}