using System.Windows;
using ProjetISF.Database;
using ProjetISF.Person;

namespace ProjetISF
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void ButtonAdClient_OnClick(object sender, RoutedEventArgs e)
        {
            addCllientWindow addCllientWindow = new addCllientWindow();
            addCllientWindow.Show();
        }
        private void ButtonSeeClient_OnClick(object sender, RoutedEventArgs e)
        {
            AllClientWindow AllClientWindow = new AllClientWindow();
            AllClientWindow.Show();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Client cl = new Client();
            var c = new ClientDBAccess();
            cl = c.GetClient(clientid.Text);
            UserWindow userWindow = new UserWindow(cl);
            userWindow.Show();
         

            
        }
    }
}