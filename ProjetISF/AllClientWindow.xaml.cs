using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using ProjetISF.Database;
using ProjetISF.Person;

namespace ProjetISF
{
    public partial class AllClientWindow : Window
    {
        private Client user;
        public AllClientWindow()
        {
            InitializeComponent();
            var c = new ClientDBAccess();
            List<Client> clients = new List<Client>();
            clients = c.GetAll();
            Users.ItemsSource = clients;
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Popup1.IsOpen = false;
            user.pin = Box.Text;
            var c = new ClientDBAccess();
            c.UpdateClient(user);
        }
    }
}