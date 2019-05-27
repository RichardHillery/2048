using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace _2048_WinForms
{
    public class Square
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_value != 0)
                    _label.Text = value.ToString();
                switch (value)
                {
                    case 0:
                        _label.Text = "";
                        _label.ForeColor = Color.DarkGray;
                        _label.BackColor = Color.LightSlateGray;
                        _panel.BackColor = Color.LightSlateGray;
                        break;
                    case 2:
                        _label.ForeColor = Color.DarkGray;
                        _label.BackColor = Color.LightGray;
                        _panel.BackColor = Color.LightGray;

                        break;
                    case 4:
                        _label.ForeColor = Color.DarkGray;
                        _label.BackColor = Color.LightGoldenrodYellow;
                        _panel.BackColor = Color.LightGoldenrodYellow;

                        break;
                    case 8:
                        _label.ForeColor = Color.White;
                        _label.BackColor = Color.Orange;
                        _panel.BackColor = Color.Orange;

                        break;
                    case 16:
                        _label.ForeColor = Color.White;
                        _label.BackColor = Color.DarkOrange;
                        _panel.BackColor = Color.DarkOrange;

                        break;
                    case 32:
                        _label.ForeColor = Color.White;
                        _label.BackColor = Color.DarkOrange;
                        _panel.BackColor = Color.DarkOrange;

                        break;
                    case 64:
                        _label.ForeColor = Color.White;
                        _label.BackColor = Color.DarkRed;
                        _panel.BackColor = Color.DarkRed;

                        break;
                    case 128:
                        _label.ForeColor = Color.White;
                        _label.BackColor = Color.SandyBrown;
                        _panel.BackColor = Color.SandyBrown;

                        break;
                    case 256:
                        _label.ForeColor = Color.White;
                        _label.BackColor = Color.Crimson;
                        _panel.BackColor = Color.Crimson;

                        break;
                    case 512:
                        _label.ForeColor = Color.White;
                        _label.BackColor = Color.DarkGoldenrod;
                        _panel.BackColor = Color.DarkGoldenrod;

                        break;
                    case 1024:
                        _label.ForeColor = Color.White;
                        _label.BackColor = Color.DarkOliveGreen;
                        _panel.BackColor = Color.DarkOliveGreen;

                        break;
                    case 2048:
                        _label.ForeColor = Color.White;
                        _label.BackColor = Color.Blue;
                        _panel.BackColor = Color.Blue;

                        break;

                    default:
                        _label.ForeColor = Color.White;
                        _label.BackColor = Color.Black;
                        _panel.BackColor = Color.Black;

                        break;
                }
            }
        }

        private Label _label;
        public Label GetLable
        { get => _label; }
        private Panel _panel;
        public Panel GetPanel
        { get => _panel; }

        private int _row;
        private int _col;
        public Square(Label label, Panel panel)
        {
            _label = label;
            _panel = panel;
            StartingPoint = panel.Location;
        }
        public Square(Panel parent, int row, int col)
        {
            _panel = new System.Windows.Forms.Panel();
            _label = new System.Windows.Forms.Label();

            // 
            // panel1
            // 
            _panel.Controls.Add(_label);
            _panel.Location = new System.Drawing.Point(3+106*row, 3 + 106 * col);
            _panel.Name = "panel" + col + row;
            _panel.Size = new System.Drawing.Size(100, 100);
            _panel.TabIndex = row * 4 + col;
            _panel.MouseClick += new System.Windows.Forms.MouseEventHandler(Square_MouseClick);
            _panel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(Square_MouseDoubleClick);
            // 
            // label1
            // 

            _label.AutoSize = true;
            _label.Location = new System.Drawing.Point(23, 38);
            _label.Name = "label"+col+row;
            _label.Size = new System.Drawing.Size(35, 13);
            _label.TabIndex = row*4+col+16;
            //_label.Text = "label"+col+row;
            _label.MouseClick += new System.Windows.Forms.MouseEventHandler(Square_MouseClick);
            _label.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(Square_MouseDoubleClick);


            parent.Controls.Add(_panel);

            Value = 0;
            _row = row;
            _col = col;

        }
        private void MM(int row, int col, int val)
        {
            if (Form2048.IsWaitingForMouse)
            {
                if (Value == 0)
                {
                    Value = val;
                    Form2048.IsWaitingForArrow = true;
                }
            }

        }

        private void Square_MouseClick(object sender, MouseEventArgs e)
        {
            MM(_row, _col, 2);
        }
        private void Square_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MM(_row, _col, 4);
        }
        private Point StartingPoint;
        public bool Animate()
        {
            int MaxSpeed = 15;
            if (_panel.Location != StartingPoint)
            {
                int deltaX = _panel.Location.X - StartingPoint.X;
                int deltaY = _panel.Location.Y - StartingPoint.Y;
                if (deltaX > MaxSpeed) deltaX = MaxSpeed;
                if (deltaY > MaxSpeed) deltaY = MaxSpeed;
                if (deltaX < -MaxSpeed) deltaX = -MaxSpeed;
                if (deltaY < -MaxSpeed) deltaY = -MaxSpeed;
                _panel.Location = new Point(_panel.Location.X - deltaX, _panel.Location.Y - deltaY);
                return true;
            }
            _panel.Visible = true;
            return false;
        }
        public bool AnimationInProgress = false;
    }

}
