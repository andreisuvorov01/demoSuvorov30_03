using StroyMaterial.DB;
using StroyMaterial.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StroyMaterial.ViewModel
{
    public class AuthVM : BaseVM
    {
        private User _user;

        private string _login;
        private string _password;

        public string Login //получение строки логина
        {
            get => _login;

                set
            {
                _login = value;
               OnPropertyChanged(Login);
            }
        }

       public string Password //получение строки пароля
        {
            get => _password;
                set
            {
                _password = value;
                OnPropertyChanged(Password);
            }
        }

        public async Task<bool> Authorize(string Login, string Password) //метод авторизации
        {
            if (_user != null)
            {
                try
                {
                    var result = DbSingleTone.Db_S.User.FirstOrDefaultAsync(User => User.UserLogin == Login && User.UserPassword == Password);
                    _user = await result;
                    if (result != null)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return false;
        }
        public async void AuthInApp()
        {
            if(await Authorize(Login,Password))
            {
                DataGridWindow dataWindow = new DataGridWindow();
                dataWindow.Show();
            }
        }
    }
}
