using AccountManager.BLL;
using AccountManager.DAL;
using AccountManager.TMC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AccountManager.UIL
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : UserControl
    {
        BusinnesLogic BL = null;

        public Registration()
        {
            InitializeComponent();
            this.BL = new BusinnesLogic();
        }
     

        #region Reset Form

        private void ResetField()
        {
            this.UserLogin_WTB.Text       = "";
            this.UserPassword_PB.Password = "";
        }

        #endregion


        #region Validation

        private bool Validation()
        {
            bool condition = true;

            if (!this.ValidateLogin())
                condition = false;

            if (!this.ValidatePassword())
                condition = false;

            return condition;
        }

        private bool ValidateLogin()
        {
            bool condition = true;

            if (this.UserLogin_WTB.Text.Length == 0)
            {
                condition = false;
                this.UserLogin_WTB.BorderBrush = Brushes.Red;
            }
            else
                this.UserLogin_WTB.BorderBrush = Brushes.Gray;

            return condition;
        }

        private bool ValidatePassword()
        {
            bool condition = true;

            if (this.UserPassword_PB.Password.Length == 0)
            {
                condition = false;
                this.UserPassword_PB.BorderBrush = Brushes.Red;
            }
            else
                this.UserPassword_PB.BorderBrush = Brushes.Gray;

            return condition;
        }

        #endregion


        #region Events

        private void UserPassword_PB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.ValidatePassword();

        }

        private void UserLogin_WTB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.ValidateLogin();

        }

        private void AddUser_B_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Validation())
                {
                    string Password = this.UserPassword_PB.Password;
                    Password = this.BL.MakeHash(Password);

                    string Login = this.UserLogin_WTB.Text;

                    Users User = new Users
                    {
                        UserName     = Login,
                        UserPassword = Password
                    };

                    this.BL.AddUser(User);

                    this.ResetField();
                    MessageBox.Show("User was successesfully Added!");
                }
                else
                {
                    throw new InvalidProgramException("ERROR: Data invalid!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.IdUser != 0)
            {
                this.UserLogin_WTB.Visibility = this.UserPassword_PB.Visibility = 
                this.AddUser_B.Visibility     = Visibility.Hidden;
            }
            else
            {
                this.UserLogin_WTB.Visibility = this.UserPassword_PB.Visibility =
                this.AddUser_B.Visibility     = Visibility.Visible;
            }
        }

        #endregion
    }
}
