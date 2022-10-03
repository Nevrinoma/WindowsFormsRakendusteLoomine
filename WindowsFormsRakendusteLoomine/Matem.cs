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
    public partial class Matem : Form
    {
        public Matem()
        {
            Name = "MatemForm";
            Size = new Size(500, 400);
            Text = "Math Quiz";
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Label mainLable = new Label
            {
                Name = "timeLabel",
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(200,30),
                

            };
            

        }
    }
}
