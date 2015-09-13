using System;
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
    public partial class ModelessDialog : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // Method Signature
        public delegate void ChangedWordEvent(string word);
        private Form1 _view;

        // Event that is triggered when the word changes
        public event ChangedWordEvent ChangedWord;

        public void OnChangedWord(string word)
        {
            if (ChangedWord != null)
            {
                ChangedWord(word);
            }
        }
        public ModelessDialog()
        {
            InitializeComponent();
            textBox1.Text = "Test";
            TopMost = true;
        }

        public ModelessDialog(Form1 form1)
        {
            InitializeComponent();
            _view = form1;
            _view.button1.Enabled = false;
            textBox1.Text = form1.label1.Text;
            TopMost = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnChangedWord(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            _view.button1.Enabled = true;
        }

        private void ModelessDialog_Load(object sender, EventArgs e)
        {
            SetForegroundWindow(this.Handle);
        }

        private void ModelessDialog_Deactivate(object sender, EventArgs e)
        {
            TopMost = true;
            SetForegroundWindow(this.Handle);
            Opacity = .75;
        }

        private void ModelessDialog_Activated(object sender, EventArgs e)
        {
            Opacity = 1;
        }
    }
}
