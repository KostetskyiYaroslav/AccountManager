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
using AccountManager.TMC;

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

        #region Function

        private Category GetSelectedCategory()
        {

            foreach (Category Category in this.categoryDataGrid.SelectedItems)
            {
                return Category;
            }

            return null;
        }

        public void ReadCategory()
        {
            this.categoryDataGrid.ItemsSource = this.BL.GetAllCategory().ToList();
        }


        #endregion

        #region Event

        private void Update_B_Click(object sender, RoutedEventArgs e)
        {
            Category UpdateCategory = this.GetSelectedCategory();

            if (UpdateCategory != null) {
                try
                {
                    this.BL.UpdateCategory(UpdateCategory);
                    this.ReadCategory();
                    MessageBox.Show("Category was successfully updated!");
                    this.categoryDataGrid.IsReadOnly = true;
                    this.Delete_B.Visibility = Visibility.Hidden;
                    this.Update_B.Visibility = Visibility.Hidden;
                }
                catch (Exception eDeleteContact)
                {
                    MessageBox.Show("ERROR: " + eDeleteContact.Message);
                }
            }
            else
                MessageBox.Show("Please! Select one category!");

         }


        private void Delete_B_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmation = MessageBox.Show(
                "Do you really want to delete this Category\n " +
                "(All Account will be set `[NO]` Category)?", "Confirmation",
                                                         MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (confirmation == MessageBoxResult.Yes)
            {
                Category DeleteCategory = this.GetSelectedCategory();

                if (DeleteCategory != null)
                    try
                    {
                        this.BL.RemoveCategory(DeleteCategory);
                        this.ReadCategory();
                        MessageBox.Show("Contact was successfully deleted!");

                        this.categoryDataGrid.IsReadOnly = true;
                        this.Delete_B.Visibility = Visibility.Hidden;
                        this.Update_B.Visibility = Visibility.Hidden;
                    }
                    catch (Exception eDeleteContact)
                    {
                        MessageBox.Show("ERROR: " + eDeleteContact.Message);
                    }
                else
                    MessageBox.Show("Please! Select one Category!");
            }
            else
                MessageBox.Show("Choice was cancel!");
         
        }


        private void categoryDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CurrentUser.UserName == "777")
            {
                this.categoryDataGrid.IsReadOnly = false;
                this.Update_B.Visibility =
                this.Delete_B.Visibility = Visibility.Visible;
            }
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReadCategory();
        }

        #endregion

    }
}
