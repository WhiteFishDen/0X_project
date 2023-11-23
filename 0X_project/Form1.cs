using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0X_project
{
    public partial class Form1 : Form
    {
        string _side = ""; 
        Button[] _btn = new Button[9];
        int[] _state = new int[9]; 
        Random _turn = new Random();
        public Form1()
        {
            InitializeComponent();
            if (_turn.Next(1, 10) <= 5)
            {
                _side = "крестики";
                turn.Text = "Ходят крестики!";
            }
            else
            {
                _side = "нолики";
                turn.Text = "Ходят нолики!";
            }
            _btn[0] = button1;
            _btn[1] = button2;
            _btn[2] = button3;
            _btn[3] = button4;
            _btn[4] = button5;
            _btn[5] = button6;
            _btn[6] = button7;
            _btn[7] = button8;
            _btn[8] = button9;

        }
        private void Win(int startItem, int step, string player)
        {
            if(player!="ничья")
            {
                _btn[startItem].BackColor = Color.ForestGreen;
                _btn[startItem + step].BackColor = Color.ForestGreen;
                _btn[startItem + 2 * step].BackColor = Color.ForestGreen;
            }
            else
            {
                for (int i = 0; i <_btn.Length; i++)
                    _btn[i].BackColor = Color.ForestGreen;
            }
            for (int i = 0; i < _btn.Length; i++)
                _btn[i].Enabled = false;
            Restart.Enabled = true;
            MessageBox.Show( $"Победили {player} !!!");

        }
        private bool DrawGame()
        {
            int counter = 0;
            for (int i = 0; i < _btn.Length; i++)
                if (!_btn[i].Enabled)
                    counter++;
            if (counter == 9) 
                return true;
            else
                return false;
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if(_side == "крестики")
            {
                for (int i = 0; i < _btn.Length; i++)
                {
                    if(sender == _btn[i] )
                    {
                        _btn[i].Text = "X";
                        turn.Text = "Ходят нолики!";
                        _side = "нолики";
                        _btn[i].Enabled = false;
                        _state[i] = 1;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < _btn.Length; i++)
                {
                    if (sender == _btn[i])
                    {
                        _btn[i].Text = "0";
                        turn.Text = "Ходят крестики!";
                        _side = "крестики";
                        _btn[i].Enabled = false;
                        _state[i] = 2;
                        break;

                    }
                }
            }
            if (_state[0] == 1 && _state[1] == 1 && _state[2] == 1)
                Win(0, 1, "крестики");
            else if (_state[3] == 1 && _state[4] == 1 && _state[5] == 1)
                Win(3, 1, "крестики");
            else if (_state[6] == 1 && _state[7] == 1 && _state[8] == 1)
                Win(6, 1, "крестики");
            else if (_state[0] == 1 && _state[3] == 1 && _state[6] == 1)
                Win(0, 3, "крестики");
            else if (_state[1] == 1 && _state[4] == 1 && _state[7] == 1)
                Win(1, 3, "крестики");
            else if (_state[2] == 1 && _state[5] == 1 && _state[8] == 1)
                Win(2, 3, "крестики");
            else if (_state[0] == 1 && _state[4] == 1 && _state[8] == 1)
                Win(0, 4, "крестики");
            else if (_state[2] == 1 && _state[4] == 1 && _state[6] == 1)
                Win(2, 2, "крестики");
            else if (_state[0] == 2 && _state[1] == 2 && _state[2] == 2)
                Win(0, 1, "нолики");
            else if (_state[3] == 2 && _state[4] == 2 && _state[5] == 2)
                Win(3, 1, "нолики");
            else if (_state[6] == 2 && _state[7] == 2 && _state[8] == 2)
                Win(6, 1, "нолики");
            else if (_state[0] == 2 && _state[3] == 2 && _state[6] == 2)
                Win(0, 3, "нолики");
            else if (_state[1] == 2 && _state[4] == 2 && _state[7] == 2)
                Win(1, 3, "нолики");
            else if (_state[2] == 2 && _state[5] == 2 && _state[8] == 2)
                Win(2, 3, "нолики");
            else if (_state[0] == 2 && _state[4] == 2 && _state[8] == 2)
                Win(0, 4, "нолики");
            else if (_state[2] == 2 && _state[4] == 2 && _state[6] == 2)
                Win(2, 2, "нолики");
            else if (DrawGame())
                Win(0, 0, "ничья");
        }
        private void Restart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _btn.Length; i++)
            {
                _btn[i].Enabled = true;
                _btn[i].Text = "";
                _btn[i].BackColor = Color.White;
                _state[i] = 0;

                if (_turn.Next(1, 10) <= 5)
                {
                    _side = "крестики";
                    turn.Text = "Ходят крестики!";
                }
                else
                {
                    _side = "нолики";
                    turn.Text = "Ходят нолики!";
                }
            }
        }
    }
}
