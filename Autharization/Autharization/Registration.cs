using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Authorization.Model;
using Authorization.ViewModel;

namespace Authorization
{
    public partial class Registration : Form
    {

        private readonly PersonInfoViewModel _personInfoViewModel;

        private readonly PersonInfo _personInfo = new PersonInfo();

        private readonly IList<string> Cities = new List<string>()
        {

            "Nizhney Novgorod",
            "Moscow",
            "Saint Peterburg",
            "Kaliningrad",
            "Petrozavodsk",
            "Kazan",
            "Sochi"
        };

        private TextBox name;
        private TextBox email;
        private TextBox password;
        private DateTimePicker dateOfBirth;
        private ComboBox cities;
        private Button save;
        private Point lstPoint = new Point();
        public Registration()
        {
            _personInfoViewModel = new PersonInfoViewModel(_personInfo);
            InitializeComponent();
            Add_Title();
            Add_Main();
            Button();
            save.Click += save_Click;
            this.MouseDown += Registration_MouseDown;
            this.MouseMove += Registration_MouseDown;
            email.Validating += textBox1_Validating;
            password.Validating += password_Validating;
            cities.DataSource = Cities;
        }



        private void save_Click(object sender, EventArgs e)
        {
            _personInfoViewModel.SaveFile();
            if (sender != null)
            {
                Close();
            }
        }


        private void Registration_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lstPoint.X;
                this.Top += e.Y - lstPoint.Y;
            }
        }

        private void Registration_MouseDown(object sender, MouseEventArgs e)
        {
            lstPoint = new Point(e.X, e.Y);
        }

        private void Add_Title()
        {
            var title = new Label()
            {
                ForeColor = Color.DimGray,
                Font = new Font("MV Boli", 16, FontStyle.Italic),
                Text = "Registration",
                Anchor = AnchorStyles.None,
               Size = new Size(208, 37),
            };
            Title.Controls.Add(title);
        }

        private void DataBinding()
        {
            name.DataBindings.Add(nameof(name.Text), _personInfoViewModel, nameof(_personInfoViewModel.FullName),
                true, DataSourceUpdateMode.OnPropertyChanged);
            email.DataBindings.Add(nameof(email.Text), _personInfoViewModel, nameof(_personInfoViewModel.Email),
                true, DataSourceUpdateMode.OnPropertyChanged);
            password.DataBindings.Add(nameof(password.Text), _personInfoViewModel, nameof(_personInfoViewModel.Password),
                true, DataSourceUpdateMode.OnPropertyChanged);
            dateOfBirth.DataBindings.Add(nameof(dateOfBirth.Value), _personInfoViewModel, nameof(_personInfoViewModel.DateOfBirth),
                true, DataSourceUpdateMode.OnPropertyChanged);
            cities.DataBindings.Add(nameof(cities.SelectedItem), _personInfoViewModel,nameof(_personInfoViewModel.SelectedCity),
                true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Add_Main()
        {
            var controls = new Control[]
            {
                new Label() { ForeColor = Color.DimGray, Text = "Full Name",
                    Font = new Font("MV Boli", 11, FontStyle.Italic), Anchor = AnchorStyles.None,},
                name = new TextBox(){ Anchor = AnchorStyles.None,},
                new Label() { ForeColor = Color.DimGray, Text = "DateOfBirth",
                    Font = new Font("MV Boli", 11, FontStyle.Italic), Anchor = AnchorStyles.None,},
                dateOfBirth = new DateTimePicker(){ Anchor = AnchorStyles.None,},
                new Label() { ForeColor = Color.DimGray, Text = "City",
                    Font = new Font("MV Boli", 11, FontStyle.Italic), Anchor = AnchorStyles.None,},
                cities = new ComboBox(){ Anchor = AnchorStyles.None,},
                new Label() { ForeColor = Color.DimGray, Text = "Email",
                    Font = new Font("MV Boli", 11, FontStyle.Italic), Anchor = AnchorStyles.None,},
                email = new TextBox(){ Anchor = AnchorStyles.None,},
                new Label() { ForeColor = Color.DimGray, Text = "Password",
                    Font = new Font("MV Boli", 11, FontStyle.Italic), Anchor = AnchorStyles.None, },
                password = new TextBox(){ Anchor = AnchorStyles.None,},
            };
            MainPanel.Controls.AddRange(controls);
        }

        private void Button()
        {
            save = new Button()
                {Text = "Submit", Font = new Font("MV Boli", 11, FontStyle.Italic), ForeColor = Color.DimGray};
            BottomPanel.Controls.Add(save);
        }

        private void password_Validating(object sender, CancelEventArgs e)
        {
            if (((TextBox) sender).TextLength < 8)
            {
                errorProvider1.SetError(password, "length of password less than 8");
            }
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (((TextBox)sender).TextLength == 0)
            {
                errorProvider1.SetError(email, "Please enter an email address!");
            }

            if (!((TextBox)sender).Text.Contains("@"))
            {
                errorProvider1.SetError(email, "Not a correct format");
            }
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            DataBinding();
        }
    }
}
