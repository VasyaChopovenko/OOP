using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casino
{
    public partial class Casino : Form
    {
        int balance = 100; 
        int counter_money = 0; 
        int counter_try = 0; 
        int win_money = 0; 
        bool IsActive = true;
        Image[] image = new Image[8];
        int[] index = new int[3];

        public Casino()
        {
            InitializeComponent();
            for (int i = 0; i < image.Length; i++)
            {
                image[i] = Image.FromFile($@"..\..\images\\{i + 1}.png");
            }
        }

        private void dvg1_Tick(object sender, EventArgs e)
        {
            Random random = new Random(); 
            int dvg = random.Next(0, 8);
            pictureBox1.Image = image[dvg];
            index[0] = dvg;
        }
        private void dvg2_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int dvg = random.Next(0, 8);
            pictureBox2.Image = image[dvg];
            index[1] = dvg;
        }
        private void dvg3_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int dvg = random.Next(0, 8);
            pictureBox3.Image = image[dvg];
            index[2] = dvg;
        }

        private void stop1_Tick(object sender, EventArgs e)
        {
            dvg1.Enabled = false; 
            stop1.Enabled = false;
        }
        private void stop2_Tick(object sender, EventArgs e)
        {
            dvg2.Enabled = false;
            stop2.Enabled = false;
        }
        private void stop3_Tick(object sender, EventArgs e)
        {
            counter_try--;
            dvg3.Enabled = false;
            stop3.Enabled = false;
            Win_Money(); 
            if (IsActive)
            {
                if (counter_try != 0) 
                {
                    label6.Text = "Залишилось спроб: " + counter_try;
                    button1.Enabled = true;
                }
                else
                {
                    label6.Text = "Залишилось спроб: " + counter_try;
                    MessageBox.Show("Робіть нову ставку!", "Спроби закінчились...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Enabled = true;
                }
            }
        }

        private void Win_Money()
        {
            if (index[0] == 0 && index[1] == 0 && index[2] == 0) Upd_Win_Money(17);
            if (index[0] == 1 && index[1] == 1 && index[2] == 1) Upd_Win_Money(10);
            if (index[0] == 2 && index[1] == 2 && index[2] == 2) Upd_Win_Money(11);
            if (index[0] == 3 && index[1] == 3 && index[2] == 3) Upd_Win_Money(12);
            if (index[0] == 4 && index[1] == 4 && index[2] == 4) Upd_Win_Money(13);
            if (index[0] == 5 && index[1] == 5 && index[2] == 5) Upd_Win_Money(14);
            if (index[0] == 6 && index[1] == 6 && index[2] == 6) Upd_Win_Money(15);
            if (index[0] == 7 && index[1] == 7 && index[2] == 7) Upd_Win_Money(20);
            if ((index[0] == 0 && index[1] == 0) || (index[1] == 0 && index[2] == 0)) Upd_Win_Money(7);
            if ((index[0] == 1 && index[1] == 1) || (index[1] == 1 && index[2] == 1)) Upd_Win_Money(1);
            if ((index[0] == 2 && index[1] == 2) || (index[1] == 2 && index[2] == 2)) Upd_Win_Money(2);
            if ((index[0] == 3 && index[1] == 3) || (index[1] == 3 && index[2] == 3)) Upd_Win_Money(3);
            if ((index[0] == 4 && index[1] == 4) || (index[1] == 4 && index[2] == 4)) Upd_Win_Money(4);
            if ((index[0] == 5 && index[1] == 5) || (index[1] == 5 && index[2] == 5)) Upd_Win_Money(5);
            if ((index[0] == 6 && index[1] == 6) || (index[1] == 6 && index[2] == 6)) Upd_Win_Money(6);
            if ((index[0] == 7 && index[1] == 7) || (index[1] == 7 && index[2] == 7)) Upd_Win_Money(10);
        }

        private void Upd_Win_Money(int number)
        {
            win_money = counter_money * number; 
            DialogResult result = MessageBox.Show("Ви виграли: $" + win_money, "Вітаємо!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            balance = balance + win_money; 
            label4.Text = "Баланс: $" + balance; 
            button1.Enabled = false; 
            button2.Enabled = true; 
            IsActive = false; 
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Робіть нову ставку!", "Нова гра", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label6.Text = "Залишилось спроб: 0"; 
            }
        }

        private void Init_Counter(decimal counter)
        {
            counter_money = Convert.ToInt32(counter); 
            balance = balance - counter_money; 
            label4.Text = "Баланс: $" + balance; 
            counter_try = 5; 
            label6.Text = "Залишилось спроб: " + counter_try; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dvg1.Enabled = true;
            dvg2.Enabled = true;
            dvg3.Enabled = true;
            stop1.Enabled = true;   
            stop2.Enabled = true;
            stop3.Enabled = true;
            IsActive = true;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Init_Counter(Convert.ToInt32(numericUpDown1.Value));
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void Casino_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = Application.OpenForms[0];
            form.StartPosition = FormStartPosition.Manual; 
            form.Left = Left; 
            form.Top = Top; 
            form.Show();
        }
    }
}
