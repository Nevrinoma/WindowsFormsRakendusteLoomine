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
            string[] btnText = { "Pildivaatur", "Matemaatika viktoriin", "Piltide Mäng", "Sulge" };

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
                    AutoSize = true,
                    BackColor = Color.LightGoldenrodYellow,
                    Dock = DockStyle.Fill,
                };
                btn.Click += Action;
                tableLayoutPanel1.Controls.Add(btn);
            }
        }

        private void Action(object sender, EventArgs e) //meetod Toiming loeb Saatja kaudu, millist nuppu vajutatakse, ja avab vormi
        {
            ImageForm ImageForm = new ImageForm(); //
            Matem Matem = new Matem();
            matchingGame matchingGame = new matchingGame();

            Button nupp_sender = (Button)sender;
            if (nupp_sender.Text == "Pildivaatur")
            {
                ImageForm.ShowDialog(); // ava Pildivaatur
            }
            else if (nupp_sender.Text == "Sulge")
            {
                Close(); //
            }
            else if (nupp_sender.Text == "Matemaatika viktoriin")
            {
                Matem.ShowDialog();
            }
            else if (nupp_sender.Text == "Piltide Mäng")
            {
                matchingGame.ShowDialog();
            }
        }
    }

}
