using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Authorization.Model;
using Authorization.ViewModel;

namespace Authorization
{
    public partial class LoggingForm : Form
    {
        private readonly PersonInfoViewModel _personInfoViewModel;

        private readonly PersonInfo _personInfo = new PersonInfo()
        {
        };
        private Point lstPoint;
        public LoggingForm()
        {
            _personInfoViewModel = new PersonInfoViewModel(_personInfo);
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DataBinding();
        }
        private void DataBinding()
        {
            textBox1.DataBindings.Add(nameof(textBox1.Text), _personInfoViewModel, nameof(_personInfoViewModel.Email),
                true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add(nameof(textBox2.Text), _personInfoViewModel, nameof(_personInfoViewModel.Password),
                true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoggingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                ((LoggingForm)sender).Close();
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (((TextBox) sender).TextLength == 0)
            {
               errorProvider1.SetError(textBox1, "Please enter an email address!");
            }

            if (!((TextBox) sender).Text.Contains("@"))
            {
                errorProvider1.SetError(textBox1, "Not a correct format");
            }
        }

        private void LoggingForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lstPoint.X;
                this.Top += e.Y - lstPoint.Y;
            }
        }

        private void LoggingForm_MouseDown(object sender, MouseEventArgs e)
        {
            lstPoint = new Point(e.X, e.Y);
        }

        private void AutharButton_Click(object sender, EventArgs e)
        {
            this._personInfoViewModel.ReadFile();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            var registration = new Registration() { StartPosition = FormStartPosition.CenterParent };
            registration.Show();
        }
    }
}
