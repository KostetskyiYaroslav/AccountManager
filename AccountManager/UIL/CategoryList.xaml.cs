using AccountManager.BLL;
using AccountManager.AccountManagerDBDataSetTableAdapters;
using AccountManager.UIL;
using AccountManager.Properties;
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
using AccountManager.DAL;

namespace AccountManager.UIL
{
    /// <summary>
    /// Interaction logic for CategoryList.xaml
    /// </summary>
    public partial class CategoryList : UserControl
    {
        BusinnesLogic BL = null;

        public CategoryList()
        {
            InitializeComponent();
            this.BL = new BusinnesLogic();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.categoryDataGrid.ItemsSource = this.BL.GetAllCategoryList();
        }


        #region Function

        private void ReadAccount()
        {
            if (TMC.CurrentUser.UserName == "777")
            {
                this.categoryDataGrid.ItemsSource = this.BL.GetAllAccounts().ToList();
            }
            else
                this.categoryDataGrid.ItemsSource = this.BL.GetAccountsCurrentUser().ToList();
        }


        private void DeleteAccount()
        {
            MessageBoxResult confirmation = MessageBox.Show("Do you really want to delete this Contact?", "Confirmation",
                                                          MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmation == MessageBoxResult.Yes)
            {
              

            }
            else
                MessageBox.Show("Choice was cancel!");
        }


        private void UpdateAccount()
        {
           
        }


        private void RemoveHashPassword() { }


        private Category GetSelectedAccount()
        {
       
            return null;
        }

        #endregion


        #region Event

        private void Delete_B_Click(object sender, RoutedEventArgs e)
        {
            this.DeleteAccount();
            this.categoryDataGrid.IsReadOnly = true;
            this.Delete_B.Visibility = Visibility.Hidden;
            this.Update_B.Visibility = Visibility.Hidden;
        }


        private void Update_B_Click(object sender, RoutedEventArgs e)
        {
            this.UpdateAccount();
            this.categoryDataGrid.IsReadOnly = true;
            this.Delete_B.Visibility = Visibility.Hidden;
            this.Update_B.Visibility = Visibility.Hidden;
        }


        private void RemovHash_B_Click(object sender, RoutedEventArgs e)
        {
            this.RemoveHashPassword();
            this.categoryDataGrid.IsReadOnly = true;
            this.Delete_B.Visibility = Visibility.Hidden;
            this.Update_B.Visibility = Visibility.Hidden;
        }


        private void categoryDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReadAccount();
        }


        private void categoryDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.categoryDataGrid.IsReadOnly = false;
            this.Delete_B.Visibility = Visibility.Visible;
            this.Update_B.Visibility = Visibility.Visible;
        }

        #endregion


    }
}
