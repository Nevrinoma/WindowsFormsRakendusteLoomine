using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsRakendusteLoomine
{
    public partial class matchingGame : Form
    {
        //Label lbl;
        TableLayoutPanel tableLayoutPanel1;
        Random rnd = new Random();
        List<string> icons = new List<string>()
            {
                "!", "!", "N", "N", ",", ",", "k", "k",
                "b", "b", "v", "v", "w", "w", "z", "z"
            };
        Label firstClicked = null;
        Label secondClicked = null;
        Timer timer1 = new Timer { Interval = 750 };
        public matchingGame()
        {
            Name = "MatchingGame";
            Text = "MatchingGame!";
            timer1.Tick += timer1_Tick;

            ClientSize = new Size(550, 550);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            tableLayoutPanel1 = new TableLayoutPanel
            {
                ColumnCount = 4,
                RowCount = 4,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,

            };

            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                for (int j = 0; j < 4; j++)
                {

                    Label lbl = new Label
                    {
                        BackColor = Color.CornflowerBlue,
                        AutoSize = false,
                        Dock=DockStyle.Fill,
                        TextAlign=ContentAlignment.MiddleCenter,
                        Font = new Font("Webdings",48,FontStyle.Bold)
                    };
                    tableLayoutPanel1.Controls.Add(lbl, i, j);
                }
                
            }
            
            Controls.Add(tableLayoutPanel1);
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = rnd.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                }
                iconLabel.ForeColor = iconLabel.BackColor;
                iconLabel.Click += label1_Click;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                timer1.Start();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked.ForeColor = firstClicked.ForeColor;
                secondClicked.ForeColor = secondClicked.ForeColor;
            }
            else
            {
                firstClicked.ForeColor = firstClicked.BackColor;
                secondClicked.ForeColor = secondClicked.BackColor;
            }
            firstClicked = null;
            secondClicked = null;
            timer1.Stop();
            CheckForWinner();
        }
        private void CheckForWinner()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("Sa sobitasid kõik ikoonid!", "Palju õnne");
            Close();
        }


    }
}
