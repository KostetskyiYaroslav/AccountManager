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
    /// Interaction logic for AccountList.xaml
    /// </summary>
    public partial class AccountList : UserControl
    {
        BusinnesLogic BL = null;

        public AccountList()
        {
            InitializeComponent();
            this.BL = new BusinnesLogic();
        }


        #region Function

        private void ReadAccount()
        {
            if (TMC.CurrentUser.UserName == "777")
            {
                this.accountsDataGrid.ItemsSource = this.BL.GetAllAccounts().ToList();
            }
            else
                this.accountsDataGrid.ItemsSource = this.BL.GetAccountsCurrentUser().ToList();
        }

        private string GetCategoryDG()
        {

            foreach (CustumAccount item in this.accountsDataGrid.SelectedItems)
            {
                if (item != null)
                    return item.Category;
                else
                    MessageBox.Show("Please! Select Account!");
            }

            return null;
        }

        private void DeleteAccount()
        {
            MessageBoxResult confirmation = MessageBox.Show("Do you really want to delete this Contact?", "Confirmation",
                                                          MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmation == MessageBoxResult.Yes)
            {
                Accounts RemoveAccount = this.GetSelectedAccount();
                Accounts Account = this.GetSelectedAccount();
                if (Account != null)

                    try
                    {
                        this.BL.RemoveAccount(RemoveAccount);
                        this.ReadAccount();
                        MessageBox.Show("Contact was successfully deleted!");
                    }
                    catch (Exception eDeleteContact)
                    {
                        MessageBox.Show("ERROR: " + eDeleteContact.Message);
                    }
                else
                    MessageBox.Show("Please! Select one Account");

            }
            else
                MessageBox.Show("Choice was cancel!");
        }


        private void UpdateAccount()
        {
            Accounts Account = this.GetSelectedAccount();
            if (Account != null)
            {
                Category category = null;
                foreach (var item in this.BL.GetCategoryByName(this.GetCategoryDG()))
                    category = item;
                if (category != null)
                {
                    if (category.Name != Account.Category.Name)
                    {
                        Account.Category = category;
                    }
                    this.BL.UpdateAccount(Account);
                }
                else
                {
                    foreach (var item in this.BL.GetCategoryByName("[NO]"))
                        category = item;
                    Account.Category = category;
                    this.BL.UpdateAccount(Account);
                }
                this.ReadAccount();
            }
            else
                MessageBox.Show("Please! Select one Account");
        }


        private void RemoveHashPassword() { }


        private Accounts GetSelectedAccount()
        {
            foreach (CustumAccount item in this.accountsDataGrid.SelectedItems)
            {
                if (item != null)
                {
                    Category AccountCategory = null;
                    Users AccountUser = null;
                    if(item.Category != "")
                    foreach(var c in this.BL.GetCategoryByName(item.Category)){
                        AccountCategory = c;
                    }
                    else
                        foreach (var c in this.BL.GetCategoryByName("[NO]"))
                        {
                            AccountCategory = c;
                        }
                    
                    foreach (var u in this.BL.GetUsers().Where(x => x.UserName == item.UserName))
                    {
                            AccountUser = u;
                    }

                    return new Accounts { 
                        IdAccount = item.IdAccount,
                        IdUser = AccountUser.IdUser,
                        IdCategory = AccountCategory.IdCategory,
                        Login = item.Login,
                        Password = item.Password,
                        Domain = item.Domain,
                        SiteName = item.SiteName,
                        Description = item.Description,
                        Category = AccountCategory,
                        Users = AccountUser
                    };
                }
                else
                    MessageBox.Show("Please! Select Account!");
            }

            return null;
        }

        #endregion


        #region Event

        private void Delete_B_Click(object sender, RoutedEventArgs e)
        {
            this.DeleteAccount();
            this.accountsDataGrid.IsReadOnly = true;
            this.Delete_B.Visibility = Visibility.Hidden;
            this.Update_B.Visibility = Visibility.Hidden;
        }


        private void Update_B_Click(object sender, RoutedEventArgs e)
        {
            this.UpdateAccount();
            this.accountsDataGrid.IsReadOnly = true;
            this.Delete_B.Visibility = Visibility.Hidden;
            this.Update_B.Visibility = Visibility.Hidden;
        }


        private void RemovHash_B_Click(object sender, RoutedEventArgs e)
        {
            this.RemoveHashPassword();
            this.accountsDataGrid.IsReadOnly = true;
            this.Delete_B.Visibility = Visibility.Hidden;
            this.Update_B.Visibility = Visibility.Hidden;
        }


        private void accountsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.accountsDataGrid.IsReadOnly = false;
            this.Delete_B.Visibility = Visibility.Visible;
            this.Update_B.Visibility = Visibility.Visible;
        }


        private void accountsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReadAccount();
        }

        #endregion

    }
}
