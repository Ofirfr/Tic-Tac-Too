using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
       
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            
            counter++;
            counter++;
            Button b = (Button)sender;
            

            b.Text = "O";

            b.Enabled = false;
            if (winner() != "")
            {
                counter = 0;
                MessageBox.Show("Player " + winner() + " won!", "Game over");
                foreach (Button b1 in tableLayoutPanel1.Controls)
                {
                    b1.Text = null;
                    b1.Enabled = true;
                }
                reset_game();
            }
            else
            {


                Random temp = new Random();
                List<Button> list = new List<Button>();
                foreach (Button b1 in tableLayoutPanel1.Controls)
                {
                    if (b1.Enabled == true)
                    {
                        list.Add(b1);
                    }
                }
                bool flag = false;
                int temp_win = -1;
                for (int i = 0; i < list.Count; i++)
                {
                    if (put_here(list[i]) == 1)
                    {
                        list[i].Text = "X";
                        list[i].Enabled = false;
                        MessageBox.Show("Player X won!", "Game over");
                        reset_game();
                        flag = true;
                        break;
                    }
                    if (put_here(list[i]) == 0)
                    {
                        temp_win = i;
                    }
                }
                if (temp_win >= 0 && !flag)
                {
                    flag = true;
                    list[temp_win].Text = "X";
                    list[temp_win].Enabled = false;
                }
                if (!flag)
                {
                    int bal = temp.Next(0, list.Count);
                    list[bal].Text = "X";
                    list[bal].Enabled = false;
                }

                if (counter == 16)
                {
                    MessageBox.Show("Its a tie!", "Game over");
                    foreach (Button b1 in tableLayoutPanel1.Controls)
                    {
                        b1.Text = "";
                        b1.Enabled = true;
                    }
                    reset_game();
                }

            }
        }

        public void reset_game()
        {
            counter = 0;
            foreach (Button b1 in tableLayoutPanel1.Controls)
            {
                b1.Text = "";
                b1.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Tic Tac Toe";
            label1.ForeColor = Color.White;
            label1.Font = new Font("Arial", 24, FontStyle.Bold);
            button17.Text = "Play";
            button17.TabStop = false;
            button17.FlatStyle = FlatStyle.Flat;
            button17.FlatAppearance.BorderSize = 0;
            button17.Font = new Font(button17.Font.Name, button17.Font.Size + 5, FontStyle.Bold);

            button17.BackColor = Color.White;
            BackColor = Color.Black;
            foreach (Button b1 in tableLayoutPanel1.Controls)
            {
                b1.Visible = false;
                b1.TabStop = false;
                b1.FlatStyle = FlatStyle.Flat;
                b1.FlatAppearance.BorderSize = 0;
                b1.Font = new Font(b1.Font.Name, b1.Font.Size+5, FontStyle.Bold);

                b1.BackColor = Color.White;
                b1.Text = "";
                b1.Enabled = false;
            }
        }
        public String winner()
        {
            if (button1.Text != "" && button1.Text == button2.Text && button2.Text == button3.Text && button4.Text == button3.Text)
            {
                return button1.Text;
            }
            if (button1.Text != "" && button1.Text == button5.Text && button5.Text == button9.Text && button9.Text == button13.Text)
            {
                return button1.Text;
            }
            if (button1.Text != "" && button1.Text == button6.Text && button6.Text == button11.Text && button11.Text == button16.Text)
            {
                return button1.Text;
            }
            if (button4.Text != "" && button4.Text == button8.Text && button8.Text == button12.Text && button12.Text == button16.Text)
            {
                return button4.Text;
            }
            if (button4.Text != "" && button4.Text == button7.Text && button7.Text == button10.Text && button10.Text == button13.Text)
            {
                return button4.Text;
            }
            if (button8.Text != "" && button8.Text == button7.Text && button7.Text == button6.Text && button6.Text == button5.Text)
            {
                return button8.Text;
            }
            if (button12.Text != "" && button12.Text == button11.Text && button11.Text == button10.Text && button10.Text == button9.Text)
            {
                return button12.Text;
            }
            if (button16.Text != "" && button16.Text == button15.Text && button15.Text == button14.Text && button14.Text == button13.Text)
            {
                return button16.Text;
            }
            if (button3.Text != "" && button3.Text == button7.Text && button7.Text == button11.Text && button11.Text == button15.Text)
            {
                return button3.Text;
            }
            if (button2.Text != "" && button2.Text == button6.Text && button6.Text == button10.Text && button10.Text == button14.Text)
            {
                return button2.Text;
            }
            return "";
        }
        public int put_here(Button b)
        {

            b.Text = "X";
            if (winner()!="")
            {
                b.Text = "";
                return 1;
            }
            b.Text = "O";
            if (winner()!="")
            {
                b.Text = "";
                return 0;
            }
            b.Text = "";
            return -1;
        }

        private void play_button(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.SendToBack();
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderColor = BackColor;
            b.FlatAppearance.MouseOverBackColor = BackColor;
            b.FlatAppearance.MouseDownBackColor = BackColor;
            label1.Visible = false;
            label1.Enabled = false;
            foreach (Button b1 in tableLayoutPanel1.Controls)
            {
                b1.Visible = true;
                b1.TabStop = false;
                b1.FlatStyle = FlatStyle.Flat;
                b1.FlatAppearance.BorderSize = 0;
                b1.Font = new Font(b1.Font.Name, b1.Font.Size + 5, FontStyle.Bold);

                b1.BackColor = Color.White;
                b1.Text = "";
                b1.Enabled = true;
            }
        }

        private void thanks(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Ofir Frisch","Thanks for playing");
        }
    }
}
