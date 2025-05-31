namespace WinFormsApp4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            monthCalendar1 = new MonthCalendar();
            label3 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            listBox1 = new ListBox();
            label4 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            label6 = new Label();
            timer2 = new System.Windows.Forms.Timer(components);
            button2 = new Button();
            button3 = new Button();
            textBox2 = new TextBox();
            button4 = new Button();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 11);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 0;
            label1.Text = "Выберите Дату:";
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(123, 35);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 1;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 256);
            label3.Name = "label3";
            label3.Size = new Size(116, 15);
            label3.TabIndex = 3;
            label3.Text = "Запишите событие:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(136, 248);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 23);
            textBox1.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(178, 302);
            button1.Name = "button1";
            button1.Size = new Size(128, 23);
            button1.TabIndex = 5;
            button1.Text = "Добавить событие";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(349, 86);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(310, 274);
            listBox1.TabIndex = 6;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(349, 68);
            label4.Name = "label4";
            label4.Size = new Size(136, 15);
            label4.TabIndex = 7;
            label4.Text = "Добавленные события:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(114, 219);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 10;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // button2
            // 
            button2.Location = new Point(9, 289);
            button2.Name = "button2";
            button2.Size = new Size(133, 23);
            button2.TabIndex = 13;
            button2.Text = "Сохранить события";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(9, 318);
            button3.Name = "button3";
            button3.Size = new Size(133, 23);
            button3.TabIndex = 14;
            button3.Text = "Загрузить события";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(340, 11);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(145, 23);
            textBox2.TabIndex = 15;
            // 
            // button4
            // 
            button4.Location = new Point(481, 46);
            button4.Name = "button4";
            button4.Size = new Size(178, 23);
            button4.TabIndex = 16;
            button4.Text = "Сохранить изменения";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(491, 12);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(176, 23);
            textBox3.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 370);
            Controls.Add(textBox3);
            Controls.Add(button4);
            Controls.Add(textBox2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(monthCalendar1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Календарь";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MonthCalendar monthCalendar1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private Button button1;
        private ListBox listBox1;
        private Label label4;
        private System.Windows.Forms.Timer timer1;
        private Label label5;
        private Label label6;
        private System.Windows.Forms.Timer timer2;
        private Button button2;
        private Button button3;
        private TextBox textBox2;
        private Button button4;
        private TextBox textBox3;
    }
}
