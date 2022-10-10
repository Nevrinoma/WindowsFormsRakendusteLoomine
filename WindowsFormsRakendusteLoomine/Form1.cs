using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsRakendusteLoomine
{
    public partial class ImageForm : Form
    {
        private Random rnd = new Random();

        public ImageForm()
        {
            Name = "ImageForm";
            Text = "Pildivaatur";
            ClientSize = new Size(1250, 800);
            colorDialog1 = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            pictureBox1 = new PictureBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel { ColumnCount = 2, RowCount = 2, Dock = DockStyle.Fill }; //loob tabeli, millel on kaks rida ja kaks veergu
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            Controls.Add(tableLayoutPanel1);
            




            FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
            };
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);

            string[] btnText = { "Näita pilti", "Tühjenda pilt", "Määrake taustavärv", "Sulge" }; //massiiv nuppude nimedega

            for (int i = 0; i < btnText.Length; i++) //nuppude loomine tsükli kaudu
            {
                Button btn = new Button
                {
                    Text = btnText[i],
                    UseVisualStyleBackColor = true,
                    AutoSize = true
                };
                btn.Click += Action;
                flowLayoutPanel1.Controls.Add(btn);
            }

            pictureBox1 = new PictureBox
            {
                BorderStyle = BorderStyle.Fixed3D,
                Dock = DockStyle.Fill,
                TabStop = false,
                SizeMode = PictureBoxSizeMode.CenterImage
            };

            tableLayoutPanel1.SetColumnSpan(pictureBox1, 2);
            checkBox1 = new CheckBox
            {
                AutoSize = true,
                Text = "Venitada",
                UseVisualStyleBackColor = true,
            };
            checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);


            checkBox2 = new CheckBox
            {
                AutoSize = true,
                Text = "Disco",
                UseVisualStyleBackColor = true,
            };
            checkBox2.CheckedChanged += new EventHandler(this.backgroundDance);



            openFileDialog1 = new OpenFileDialog
            {
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" + "s (*.*)|*.*",
                Title = "Select a picture file"
            };

            Controls.Add(tableLayoutPanel1);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(checkBox1, 0, 1);
            tableLayoutPanel1.Controls.Add(checkBox2, 0, 2);

        }
        private void Action(object sender, EventArgs e)
        {
            Button nupp_sender = (Button)sender;
            if (nupp_sender.Text == "Tühjenda pilt")
            {
                pictureBox1.Image = null;
            }
            else if (nupp_sender.Text == "Sulge")
            {
                Close();
            }
            else if (nupp_sender.Text == "Määrake taustavärv")
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                    pictureBox1.BackColor = colorDialog1.Color;
            }
            else if (nupp_sender.Text == "Näita pilti")
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Load(openFileDialog1.FileName);
                    Bitmap finalImg = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Image = finalImg;
                    pictureBox1.Show();
                }
            }
        }
        //растягивает картинку при добавление через кнопку Näita pilti

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
        Timer timer1 = new Timer();
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int R, G, B;
            R = rnd.Next(0, 255);
            G = rnd.Next(0, 255);
            B = rnd.Next(0, 255);
            pictureBox1.BackColor=Color.FromArgb(R, G, B);
        }

        private void backgroundDance(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                timer1.Interval = 100;
                timer1.Start();
                timer1.Tick += timer1_Tick;
            }
            else
                timer1.Stop();
        }
    }



}
