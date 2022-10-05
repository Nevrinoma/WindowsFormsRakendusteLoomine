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
    public partial class AvaForm : Form
    {
        public AvaForm()
        {
            Name = "AvaForm";
            Text = "Tere tere, vana kere";
            ClientSize = new Size(300, 400);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            string[] btnText = { "Näita pilti", "Tühjenda pilt", "Määrake taustavärv", "Sulge" };

            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = Color.MediumPurple,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
            };
            Controls.Add(tableLayoutPanel1);

            for (int i = 0; i < 4; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                Button btn = new Button
                {
                    Text = btnText[i],
                    UseVisualStyleBackColor = true,
                    AutoSize = true
                };
                //btn.Click += Action;
                tableLayoutPanel1.Controls.Add(btn);
            }


            

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

        private void AvaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
