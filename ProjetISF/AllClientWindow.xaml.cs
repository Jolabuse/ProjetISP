using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjetISF.Database;
using ProjetISF.Person;

namespace ProjetISF
{
    public partial class AllClientWindow : Window
    {
        private Client user;
        private List<Client> clients = new List<Client>();

        public AllClientWindow()
        {
            InitializeComponent();
            var c = new ClientDBAccess();
            clients = c.GetAll();
            Users.ItemsSource = clients;
        }
        private void textBox1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var filtered = clients.Where(client => client.name.ToUpper().StartsWith(textBox1.Text.ToUpper()));

            Users.ItemsSource = filtered;            
        }
        private void BtnDel_OnClick(object sender, RoutedEventArgs e)
        {
                var c = new ClientDBAccess();
                Client dataRowView = (Client)((Button)e.Source).DataContext;
                c.DeleteClient(dataRowView.guid);
                Hide();
                AllClientWindow AllClientWindow = new AllClientWindow();
                AllClientWindow.Show();
                
        }
        private void BtnChange_OnClick(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = true;
            user = (Client)((Button)e.Source).DataContext;

            

        }
        private void Gotoclient(object sender, RoutedEventArgs e)
        {
            try
            {
                var c = new ClientDBAccess();
                Client dataRowView = (Client)((Button)e.Source).DataContext;
                Client cl = c.GetClient(dataRowView.guid);

                UserWindow userWindow = new UserWindow(cl);
                userWindow.Show();
            }
            catch 
            {
                //
            }
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
            user.pin = Box.Text;
            var c = new ClientDBAccess();
            c.UpdateClient(user);
        }
    }
}