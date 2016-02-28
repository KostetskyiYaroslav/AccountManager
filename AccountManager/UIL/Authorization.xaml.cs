using AccountManager.BLL;
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
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : UserControl
    {
        BusinnesLogic BL = null;

        public Authorization()
        {
            InitializeComponent();
            this.BL = new BusinnesLogic();
        }


        #region Event

        private void Login_B_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string Password = this.UserPassword_PB.Password;
                Password = this.BL.MakeHash(Password);
                var users = this.BL.GetUsers().
                    Where(w => w.UserName == this.UserLogin_TB.Text
                       && w.UserPassword == Password).
                       Select(x => new { x.IdUser, x.UserName, x.UserPassword });

                if (users.Count().ToString() == "1")
                {
                    foreach (var user in users)
                    {
                        CurrentUser.Set(user.IdUser, user.UserName);
                    }
                    this.SetVisibilityLogIn();
                    MessageBox.Show("Welcome, " + CurrentUser.UserName + "!");
                }
                else if (users.Count().ToString() == "0")
                {
                    MessageBox.Show("ERROR: Login or Password don't correct! Try agine!");
                }
                else
                    MessageBox.Show("ERROR: Not Backend bag! It's just feature! Existing second account!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Logout_B_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.Unset();
            this.SetVisibilityLogOut();
        }

        #endregion


        private void SetVisibilityLogIn()
        {
            this.UserLogin_TB.Visibility = Visibility.Hidden;
            this.UserPassword_PB.Visibility = Visibility.Hidden;
            this.Login_B.Visibility = Visibility.Hidden;
            this.Logout_B.Visibility = Visibility.Visible;
        }

        private void SetVisibilityLogOut()
        {
            this.UserLogin_TB.Visibility = Visibility.Visible;
            this.UserPassword_PB.Visibility = Visibility.Visible;
            this.Login_B.Visibility = Visibility.Visible;
            this.Logout_B.Visibility = Visibility.Hidden;
        }

    }
}
