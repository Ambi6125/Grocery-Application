﻿using SynthesisLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobertHeijn_Desktop.Forms
{
    public partial class ProductsForm : Form
    {
        private readonly Homescreen origin;
        private readonly RootManager managers;
        public ProductsForm(RootManager managers, Homescreen source)
        {
            InitializeComponent();
            origin = source;
            this.managers = managers;
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                origin.Show();
            }
        }
    }
}
