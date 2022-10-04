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
        Label lbl;
        TableLayoutPanel tableLayoutPanel1;
        Random rnd = new Random();
        List<string> icons = new List<string>()
            {
                "!", "!", "N", "N", ",", ",", "k", "k",
                "b", "b", "v", "v", "w", "w", "z", "z"
            };
        public matchingGame()
        {
            Name = "MatchingGame";
            Text = "MatchingGame!";
            
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

                    lbl = new Label
                    {
                        BackColor = Color.CornflowerBlue,
                        AutoSize = false,
                        Dock=DockStyle.Fill,
                        TextAlign=ContentAlignment.MiddleCenter,
                        Font = new Font("Webdings",48,FontStyle.Bold)
                    };
                    Controls.Add(lbl,i,j);
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
                    // iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
            

        }
        



    }
}
