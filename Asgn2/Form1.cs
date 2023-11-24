using System;
using System.Windows.Forms;

namespace Asgn2
{
    public partial class Form1 : Form
    {
        public int option = 1;
        public bool bResetPos = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void rb_Op1_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }

        private void rb_Op2_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }

        private void rb_Op3_CheckedChanged(object sender, EventArgs e)
        {
            SetOption();
        }

        private void b_ResetPos_Click(object sender, EventArgs e)
        {
            bResetPos = true;
        }

        public void ResetBool()
        {
            bResetPos = false;
        }

        private void SetOption()
        {
            if(rb_Op1.Checked)
                option = 1;
            else if(rb_Op2.Checked)
                option = 2;
            else if(rb_Op3.Checked)
                option = 3;
        }
    }
}
