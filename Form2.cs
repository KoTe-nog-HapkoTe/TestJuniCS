using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestXML
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(988, 559);

            Label lbl = new Label();
            lbl.Size = new Size(570, 50);
            lbl.Location = new Point(50, 600);
            lbl.Text = "Вылегжанин Илья Иванови 26.08.2025 " +
                "\nСпециально для \"ООО Програмный Центр\"";

            panel1.Controls.Add(lbl);
        }
    }
}
