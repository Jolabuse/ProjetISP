using System.Windows;
using System.Windows.Input;
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
        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
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

        private void ButtonQuit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}