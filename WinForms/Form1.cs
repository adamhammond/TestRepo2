﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int x = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open dialog box for user to be able to change form background color
            ModelessDialog modelessDialog = new ModelessDialog(this);
            modelessDialog.ChangedWord += ModelessDialog_ChangedWord;
            modelessDialog.Show();
        }

        private void ModelessDialog_ChangedWord(string word)
        {
            label1.Text = word;
        }
    }
}
