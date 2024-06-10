﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telas
{
    public abstract class TelaPadrao : Form
    {
        public TelaPadrao()
        {
            Width = 1000;
            Height = 720;
            BackColor = Color.White;
            Panel barra = new Panel();
            barra.Width = 1000;
            barra.Height = 100;
            barra.BackColor = Color.DarkBlue;
            Controls.Add(barra);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }
    }
}