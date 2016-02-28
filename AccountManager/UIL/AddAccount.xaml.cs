using AccountManager.BLL;
using AccountManager.DAL;
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
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : UserControl
    {
        BusinnesLogic BL = null;

        public AddAccount()
        {
            InitializeComponent();
            this.BL = new BusinnesLogic();
        }

        private void AddCount_B_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.Validation())
                {
                    Accounts Account = new Accounts
                    {
                        Login = this.Login_WTB.Text,
                        Password = this.Password_WTB.Text,
                        Domain = this.Domain_WTB.Text,
                        SiteName = this.SiteName_WTB.Text,
                        Description = this.Description_WTB.Text
                    };

                    Account.Users = this.CurrentUser();
                    foreach (var c in this.BL.GetCategoryByName(this.CategoryList_CB.SelectedItem.ToString()))
                    {
                        Account.Category = c;
                    }

                    this.BL.AddAccount(Account);

                    this.ResetField();
                    MessageBox.Show("Account was successesfully Added!");
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

        private Users CurrentUser()
        {
            try
            {
                Users CurrentUser = null;
                List<Users> UserList = this.BL.GetAuthUserList();

                foreach (Users u in UserList)
                {
                    CurrentUser = u;
                }

                return CurrentUser;
            }
            catch (Exception ex)
            {
                throw new InvalidProgramException(ex.Message);
            }
        }


        #region Reset Form

        private void ResetField()
        {
            this.Login_WTB.Text = "";
            this.Password_WTB.Text = "";
            this.Domain_WTB.Text = "";
            this.SiteName_WTB.Text = "";
            this.Description_WTB.Text = "";
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

            if (!this.ValidateDomain())
                condition = false;

            if (!this.ValidateSiteName())
                condition = false;

            return condition;
        }

        private bool ValidateLogin()
        {
            bool condition = true;

            if (this.Login_WTB.Text.Length == 0)
            {
                condition = false;
                this.Login_WTB.BorderBrush = Brushes.Red;
            }
            else
                this.Login_WTB.BorderBrush = Brushes.Gray;

            return condition;
        }

        private bool ValidatePassword()
        {
            bool condition = true;

            if (this.Password_WTB.Text.Length == 0)
            {
                condition = false;
                this.Password_WTB.BorderBrush = Brushes.Red;
            }
            else
                this.Password_WTB.BorderBrush = Brushes.Gray;

            return condition;
        }

        private bool ValidateDomain()
        {
            bool condition = true;

            if (this.Domain_WTB.Text.Length == 0)
            {
                condition = false;
                this.Domain_WTB.BorderBrush = Brushes.Red;
            }
            else
                this.Domain_WTB.BorderBrush = Brushes.Gray;

            return condition;
        }

        private bool ValidateSiteName()
        {
            bool condition = true;

            if (this.SiteName_WTB.Text.Length == 0)
            {
                condition = false;
                this.SiteName_WTB.BorderBrush = Brushes.Red;
            }
            else
                this.SiteName_WTB.BorderBrush = Brushes.Gray;

            return condition;
        }


        #endregion


        #region Events

        private void Login_WTB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.ValidateLogin();
        }
        private void Password_WTB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.ValidatePassword();
        }
        private void Domain_WTB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.ValidateDomain();
        }
        private void SiteName_WTB_LostFocus(object sender, RoutedEventArgs e)
        {
            this.ValidateSiteName();
        }
        #endregion

        private void CategoryList_CB_Loaded(object sender, RoutedEventArgs e)
        {
            this.CategoryList_CB.ItemsSource = this.BL.GetAllCategoryNameList();
        }
    }
}
