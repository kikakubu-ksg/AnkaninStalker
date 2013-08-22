using System;
using System.Windows.Forms;

namespace AnkaninStalker
{
    public partial class Version : Form
    {
        public string _strVersion;

        public Version()
        {
            InitializeComponent();
        }

        private void Version_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public string strVersion
        {
            get
            {

                return _strVersion;

            }
            set
            {
                _strVersion = value;
                this.label_version.Text = value;
            }
        }

    }
}
