﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalCalculation
{
    public partial class LoginDetails : Form
    {
        public LoginDetails()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            Total t = new Total();
        }
    }
}
