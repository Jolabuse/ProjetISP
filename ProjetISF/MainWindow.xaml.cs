using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
using ProjetISF.Database;
using ProjetISF.Json;
using ProjetISF.Person;

namespace ProjetISF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           /*var c = new ClientDBAccess();
            c.CreateDatabase();
            c.FillTables();*/
            var c = new ClientJsonAccess();
            c.FillJson();
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ButtonQuit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonLOGIN_OnClick(object sender, RoutedEventArgs e)
        {
            var c = new ClientDBAccess();
           

            if(ID.Text=="admin" && Password.Password=="admin")
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Hide();

            }
            else
            {
                try
                {
                    Client cl = new Client();

                    cl = c.GetClient(ID.Text);
                    //test.Text = cl.guid + "--" + Password.Password;
                    if (cl.pin.ToString() == Password.Password)
                    {
                        UserWindow userWindow = new UserWindow(cl);
                        userWindow.Show();
                        this.Hide();

                    }
                }
                catch
                {
                    //
                }
                
                
            }
            
        }
    }
}