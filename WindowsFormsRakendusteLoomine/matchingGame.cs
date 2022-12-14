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
        TableLayoutPanel tableLayoutPanel1;
        Random rnd = new Random();
        ColorDialog colorDialog1 = new ColorDialog();
        Label firstClicked = null;
        Label secondClicked = null;
        Timer timer1 = new Timer { Interval = 750 };
        string[] btnText = { "lihtne", "keskmine", "raske" };

        public Color bgcolor; // loon klassi objekti tagaplaan värv tulevikuks kasutamine meetodis Värv

        public matchingGame()
        {
            Name = "PiltideMäng";
            Text = "Piltide Mäng!";
            timer1.Tick += timer1_Tick;

            ClientSize = new Size(550, 550);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;

            valik();

        }
        private void valik() //meetod Valik loob 3 raskusastme nuppu ja nupule klõpsamisel kutsutakse välja raskusmeetod
        {

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = Color.MediumPurple,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
            };
            Controls.Add(tableLayoutPanel);

            for (int i = 0; i < 3; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                Button btnV = new Button
                {
                    Text = btnText[i],
                    UseVisualStyleBackColor = true,
                    AutoSize = true,
                    BackColor = Color.LightGoldenrodYellow,
                    Dock = DockStyle.Fill,
                };
                btnV.Click += raskused;
                tableLayoutPanel.Controls.Add(btnV);
            }
        }





        public Color varv()//avab värvidialoogi, kus kasutaja valib tulevaste siltide jaoks värvi
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
               bgcolor = colorDialog1.Color; // taust

            }
            return bgcolor;
            
        }
        private void raskused(object sender, EventArgs e) //meetod raskused mis sõltuvalt valitud raskustest genereerib erineva arvu ridade ja veergudega mängu
        {

            this.Controls.Clear();
            tableLayoutPanel1 = new TableLayoutPanel
            {
                ColumnCount = 4,
                RowCount = 4,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,

            };
            Controls.Add(tableLayoutPanel1);
            Button nupp_sender = (Button)sender;
            if (nupp_sender.Text == "lihtne")
            {
                List<string> icons = new List<string>()//nimekiri ikoonidega mängu jaoks
                    {
                        "!", "!", "N", "N"
                    };
                Color eeee = varv();
                for (int i = 0; i < 2; i++)
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                    for (int j = 0; j < 2; j++)
                    {
                        
                        Label lbl = new Label
                        {
                            
                            BackColor = eeee,
                            AutoSize = false,
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Webdings", 48, FontStyle.Bold)
                        };
                        tableLayoutPanel1.Controls.Add(lbl, i, j);
                    }

                }

                
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
            else if (nupp_sender.Text == "keskmine")
            {
                List<string> icons = new List<string>()//nimekiri ikoonidega mängu jaoks
                {
                    "!", "!", "N", "N", ",", ",", "k", "k",
                    "b", "b", "v", "v", "w", "w", "z", "z"
                };
                Color eeee = varv();
                for (int i = 0; i < 4; i++)
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                    for (int j = 0; j < 4; j++)
                    {

                        Label lbl = new Label
                        {
                            BackColor = eeee,
                            AutoSize = false,
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Webdings", 48, FontStyle.Bold)
                        };
                        tableLayoutPanel1.Controls.Add(lbl, i, j);
                    }

                }

                
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
            else if (nupp_sender.Text == "raske")
            {
                Color eeee = varv();
                List<string> icons = new List<string>()//nimekiri ikoonidega mängu jaoks
                {
                    "!", "!", "N", "N", ",", ",", "k", "k",
                    "b", "b", "v", "v", "w", "w", "z", "z",
                    "u", "u", "d", "d"
                };
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                    for (int j = 0; j < 4; j++)
                    {

                        Label lbl = new Label
                        {
                            BackColor = eeee,
                            AutoSize = false,
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Webdings", 48, FontStyle.Bold)
                        };
                        tableLayoutPanel1.Controls.Add(lbl, i, j);
                    }

                }

                
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
        }

        private void label1_Click(object sender, EventArgs e)// sildi klõps
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


        private void timer1_Tick(object sender, EventArgs e)// taimeri linnuke
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
        private void CheckForWinner()// Kontrollige Võitjat
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

        private void matchingGame_Load(object sender, EventArgs e)
        {

        }
    }
}
