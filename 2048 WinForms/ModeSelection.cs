using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048_WinForms
{
    public partial class ModeSelection : Form
    {
        public ModeSelection()
        {
            InitializeComponent();
        }
        private Form2048 _caller;
        public void SetCaller(Form2048 caller, Form2048.MoveModes mm)
        {
            _caller = caller;
            if (mm == Form2048.MoveModes.Normal)
                radioButtonNormal.Checked = true;
            if (mm == Form2048.MoveModes.Hard)
                radioButtonHard.Checked = true;
            if (mm == Form2048.MoveModes.Harder)
                radioButtonHarder.Checked = true;
            if (mm == Form2048.MoveModes.TwoPersonWaitingForMouse)
                radioButtonTwoPlayer.Checked = true;

        }

        private void radioButtonNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (_caller == null) return;

            _caller.MoveMode = Form2048.MoveModes.Normal;
             Hide();
           _caller.Show();
        }

        private void radioButtonTwoPerson_CheckedChanged(object sender, EventArgs e)
        {
            if (_caller == null) return;

            _caller.MoveMode = Form2048.MoveModes.TwoPersonWaitingForMouse;
            this.Hide();
            _caller.Show();
        }

        private void radioButtonHard_CheckedChanged(object sender, EventArgs e)
        {
            if (_caller == null) return;

             _caller.MoveMode = Form2048.MoveModes.Hard;
            this.Hide();
             _caller.Show();
        }

        private void radioButtonHarder_CheckedChanged(object sender, EventArgs e)
        {
            if (_caller == null) return;

            _caller.MoveMode = Form2048.MoveModes.Harder;
            this.Hide();
           _caller.Show();
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (_caller != null)
                _caller.Show();
        }
    }
}
