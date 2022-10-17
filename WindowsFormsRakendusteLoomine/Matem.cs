using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace WindowsFormsRakendusteLoomine
{
    public partial class Matem : Form
    {
        Timer timer = new Timer { Interval = 1000 }; //taimer
        NumericUpDown[] numericUpDown = new NumericUpDown[4];// numbriline üles alla
        Random rnd = new Random();
        TableLayoutPanel tableLayoutPanel;
        Label timelabel,scorelbl;
        int[] intnum = new int[4];
        int[] intnum2 = new int[4];
        string[] mathsymbol = new string[4] { "+", "-", "*", "/" };
        string text; //tekst
        int score;// punktid
        ComboBox mybox; //rippmenüü muusikaloendi jaoks
        public Matem()
        {
            Name = "MatemaatikaViktoriin";
            Text = "Matemaatika viktoriin";
            ClientSize = new Size(500, 250);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;

            timelabel = new Label
            {
                Name = "Taimer",
                AutoSize = false,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(190, 60),
                Location = new Point(50, 0),
                Font = new Font("Friendly", 16, FontStyle.Bold)

            };

            scorelbl = new Label
            {
                Name = "Score",
                Text="",
                AutoSize = false,
                BorderStyle = BorderStyle.Fixed3D,
                Size = new Size(190, 60),
                Location = new Point(250, 0),
                Font = new Font("Friendly", 16, FontStyle.Bold)

            };
            Controls.Add(scorelbl);

            tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 5,
                RowCount = 4,
                Location = new Point(0, 60),
                BackColor = Color.MediumPurple,
            };
            Button button = new Button //nupp
            {
                Text = "Alusta viktoriin",
                Location = new Point(20, 188),
                Size = new Size(150, 60),
                Font = new Font("Friendly", 10)

            };
            mybox = new ComboBox
            {
                Name = "mybox",
                Location = new Point(350, 188),
                Size = new Size(150, 50),
                DropDownStyle = ComboBoxStyle.DropDown
            };
            string[] files = Directory.GetFiles(@"..\..\muusika", "*.wav");
            foreach (var item in files)
            {
                string[] abc = item.Split('\\');
                mybox.Items.Add(abc[abc.Length - 1]);
            }
            Controls.Add(mybox);
            Button musicBtn = new Button
            {

                Text = "Lüülita muusika",
                Location = new Point(200, 188),
                Size = new Size(75, 60),
                Font = new Font("Friendly", 10)
            };
            Button musicBtn2 = new Button
            {

                Text = "Stop muusika",
                Location = new Point(275, 188),
                Size = new Size(75, 60),
                Font = new Font("Friendly", 10)
            };
            timer.Enabled = true;
            button.Click += Button_Click;
            Controls.Add(button);
            musicBtn.Click += Muusikalul;
            Controls.Add(musicBtn);
            musicBtn2.Click += MuusikaStop;
            Controls.Add(musicBtn2);



            for (int i = 0; i < 4; i++) // tsükkel, mis loob liidese näidetega
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                for (int j = 0; j < 5; j++)
                {
                    tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));

                    if (j == 1)
                    {
                        text = mathsymbol[i];
                    }
                    else if (j == 3)
                    {
                        text = "=";
                    }
                    else if (j == 0)
                    {
                        int a = rnd.Next(1, 20);
                        text = a.ToString();
                        intnum[i] = a;
                    }
                    else if (j == 2)
                    {
                        if (mathsymbol[i] == "/" || mathsymbol[i] == "*")
                        {
                            int a = rnd.Next(1, 5);
                            text = a.ToString();
                            intnum2[i] = a;
                        }
                        else
                        {
                            int a = rnd.Next(1, 20);
                            text = a.ToString();
                            intnum2[i] = a;
                        }
                    }

                    if (j == 4)
                    {
                        numericUpDown[i] = new NumericUpDown
                        {
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            Name = mathsymbol[i],
                            Size = new Size(50, 100),
                            Location = new Point(100, 100),
                            DecimalPlaces = 2,
                            Minimum = -20
                        };

                        tableLayoutPanel.Controls.Add(numericUpDown[i], j, i);
                    }
                    else
                    {
                        Label l = new Label { Text = text };
                        l.Font = new Font("Friendly", 16, FontStyle.Bold);
                        tableLayoutPanel.Controls.Add(l, j, i);
                    }
                }
            }
            this.Controls.Add(tableLayoutPanel);
        }
        int tik = 0;

        private void Muusikalul(object sender, EventArgs e) //mängib ripploendist valitud muusikat
        {
            var ind = Directory.GetCurrentDirectory().ToString()
                .IndexOf("bin", StringComparison.Ordinal);
            string binFolder =
                Directory.GetCurrentDirectory().ToString().Substring(0, ind)
                .ToString();
            string resourcesFoler = binFolder + "muusika\\";
            musika.URL = resourcesFoler + mybox.Items[mybox.SelectedIndex].ToString();
            musika.controls.play();
        }
        private void MuusikaStop(object sender, EventArgs e) //lõpetab muusika mängimine
        {
            musika.controls.stop();
        }
        WindowsMediaPlayer musika = new WindowsMediaPlayer();


        private void Button_Click(object sender, EventArgs e) // Nupp Klõps
        {
            timer.Start();
            timer.Tick += Timer_Tick;
            timelabel.Text = "Taimer: " + tik.ToString();
            timelabel.TextAlign = ContentAlignment.MiddleCenter;
            timelabel.Font = new Font("Arial", 16, FontStyle.Bold);
            this.Controls.Add(timelabel);
        }
        private void Timer_Tick(object sender, EventArgs e)// Taimeri Linnuke
        {
            tik++;
            timelabel.Text = "Taimer: " + tik.ToString();
            scorelbl.Text = "Õige vastud: " + score.ToString();
            rightAns();
            if (check_ans())
            {
                timer.Stop();
                MessageBox.Show("Väga hästi", "Väga hea");
            }
        }


        public int rightAns()//lisab iga õige vastuse eest (score)hinde +1 ja tagastab väärtuse
        {
            
            if (intnum[0] + intnum2[0] == numericUpDown[0].Value || intnum[1] - intnum2[1] == numericUpDown[1].Value || intnum[2] * intnum2[2] == numericUpDown[2].Value || intnum[3] / intnum2[3] == numericUpDown[3].Value)
            {
                score++;
            }
            return score;
        }


        public bool check_ans() //kontrollige vastuseid
        {
            if (intnum[0] + intnum2[0] == numericUpDown[0].Value && intnum[1] - intnum2[1] == numericUpDown[1].Value && intnum[2] * intnum2[2] == numericUpDown[2].Value && intnum[3] / intnum2[3] == numericUpDown[3].Value) 
            { return true; }
            else { return false; }
        }

        private void Matem_Load(object sender, EventArgs e)
        {

        }
    }
}
