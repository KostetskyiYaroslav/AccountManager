using AccountManager.BLL;
using AccountManager.AccountManagerDBDataSetTableAdapters;
using AccountManager.DAL;
using AccountManager.Properties;
using AccountManager.TMC;
using AccountManager.UIL;
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
    /// Interaction logic for Analitycs.xaml
    /// </summary>
    public partial class Analitycs : UserControl
    {
        BusinnesLogic BL = null;
        public Analitycs()
        {
            InitializeComponent();
            this.BL = new BusinnesLogic();
        }

        private void ReadAnalitycs() {
            this.analyticsDataGrid.ItemsSource = this.BL.GetAnalitycs().ToList();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void analyticsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReadAnalitycs();
        }


    }
}
