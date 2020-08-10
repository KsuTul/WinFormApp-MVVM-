using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Authorization.Model;

namespace Authorization.ViewModel
{
    public class PersonInfoViewModel : INotifyPropertyChanged
    {
        private readonly PersonInfo _personModel;

        public PersonInfoViewModel(PersonInfo personModel)
        {
            _personModel = personModel;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FullName
        {
            get => this._personModel.FullName;
            set
            {
                if (_personModel.FullName != value)
                {
                    _personModel.FullName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime DateOfBirth
        {
            get => this._personModel.DateOfBirth;
            set
            {
                if (_personModel.DateOfBirth != value)
                {
                    _personModel.DateOfBirth = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Email
        {
            get => this._personModel.Email;
            set
            {
                if (_personModel.Email != value)
                {
                    _personModel.Email = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => this._personModel.Password;
            set
            {
                if (_personModel.Password != value)
                {
                    _personModel.Password = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string SelectedCity
        {
            get => this._personModel.SelectedCity;
            set
            {
                if (_personModel.SelectedCity != value)
                {
                    _personModel.SelectedCity = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public void SaveFile()
        {
            var saveFile = _personModel.SaveFile(_personModel);
        }

        public void ReadFile()
        {
            _personModel.ReadFile(this._personModel.Email, this._personModel.Password);
        }
    }
}
