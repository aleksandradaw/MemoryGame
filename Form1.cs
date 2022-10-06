using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "Q", "Q", "N", "N", "R", "R", "J", "J", 
            "o", "o", "S", "S", "B", "B", "!", "!"
        };

        Label firstClick, secondClick;

        public Form1()
        {
            InitializeComponent();
            AssingIconsToAreaOfTableLayout();
        }

        private void label_Click(object sender, EventArgs e)
        {

            if (firstClick != null && secondClick != null)
                return; 

            Label clickArea = sender as Label;

            if (clickArea == null)
                return;

            if (clickArea.ForeColor == Color.OldLace)
                return;

            for (int i = 0; i < (tableLayoutPanel1.RowCount*tableLayoutPanel1.ColumnCount); i++)
            {
                if (firstClick == null)
                {
                    firstClick = clickArea;
                    firstClick.ForeColor = Color.OldLace;
                    return;
                }

                secondClick = clickArea;
                secondClick.ForeColor = Color.OldLace;

                Win();

                string firstPicture = firstClick.ToString();
                string secondPicture = secondClick.ToString();

                if (firstPicture == secondPicture)
                {
                    firstClick = null;
                    secondClick = null;
                    return;


                }
                if (firstPicture == secondPicture)
                {

                    firstClick = null;
                    secondClick = null;
                    return;
                }
                else
                {
                    timer1.Start();
                }
            }
        }

      
     
        private void Win()
        {
            Label label;
            for (int i = 0; i< tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == BackColor)
                return;
            }

            MessageBox.Show("Świetnie Ci poszło! Wygrałeś!");
            Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            timer1.Stop();
            firstClick.ForeColor = firstClick.BackColor;
            secondClick.ForeColor = secondClick.BackColor;

            firstClick = null;
            secondClick = null;
        }

        public void AssingIconsToAreaOfTableLayout()
        {
            Label label;
            int randomNumber; 

            for (int i=0; i<tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomNumber = random.Next(0, icons.Count);
                label.Text = icons[randomNumber];
                icons.RemoveAt(randomNumber);
            }

        
           

        }

    }
}
