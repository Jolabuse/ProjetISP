using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjetISF.Database;
using ProjetISF.Json;
using ProjetISF.Person;

namespace ProjetISF
{
    public partial class UserWindow : Window
    {
        private Client cl;
        public UserWindow(Client c)
        {
            InitializeComponent();
            cl = c;
            int i = Findfavcurinmoney(c.money, c.currency);
            title.Text = "Bank Acount of " + c.firstname +" "+ c.name;
            favcurrency.Text = c.currency;
            totalfavcurrency.Text = c.currency + " only :" +c.money[i].value;
            total.Text = GetTotal(c.money,c.currency).ToString();
            ComboBoxItem typeItem = (ComboBoxItem)ComboBox.SelectedItem;
            string value = typeItem.Content.ToString();
            int ii = Findfavcurinmoney(cl.money, value);
            moneyincurrecny.Text =cl.money[ii].value.ToString();
            


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
        private void Buttonpin_OnClick(object sender, RoutedEventArgs e)
        {
            if (newpin.Text == newpinverif.Text && oldpin.Text == cl.pin.ToString())
            {
                var c = new ClientDBAccess();
                cl.pin = newpin.Text;
                c.UpdateClient(cl);
            }
        }
        
        public  Double GetTotal(List<Money> m, string cur)
        {
            Double total =0 ;
            ApiAccess to = new ApiAccess();
            foreach (var mo in m)
            {
                to.Getchange(mo.currency,cur,mo.value.ToString().Replace(',','.'));
                total += to.objectRes.conversion_result;

                
            }
            
            
            return total;

        }

        private int Findfavcurinmoney(List<Money> m,string cur)
        {
            int i = 0;
            foreach (var c in m)
            {
                if (c.currency == cur)
                {
                    break;
                }
                i++;
            }

            return i;
        }
        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int i = Findfavcurinmoney(cl.money, cl.currency);
                cl.money[i].value += Double.Parse(addmoney.Text);
                var c = new ClientDBAccess();
                c.UpdateClient(cl);
                Hide();
                UserWindow userWindow = new UserWindow(cl);
                userWindow.Show();
            }
            catch (Exception exception)
            {
                //
            }
            

        }  
        private void ButtonSend_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var c = new ClientDBAccess();
                Client use = c.GetClient(iduser.Text);
                int i = Findfavcurinmoney(cl.money, cl.currency);
                use.money[i].value += Double.Parse(retrievemoney.Text);
                cl.money[i].value -= Double.Parse(retrievemoney.Text);
                c.UpdateClient(cl);
                c.UpdateClient(use);
                Hide();
                UserWindow userWindow = new UserWindow(cl);
                userWindow.Show();
            }
            catch (Exception exception)
            {
                //
            }
        }

        private void ButtonConver_OnClick(object sender, RoutedEventArgs e)
        {
            
            try
            {
                ApiAccess t = new ApiAccess();
                ComboBoxItem typeItem = (ComboBoxItem)from.SelectedItem;
                string value = typeItem.Content.ToString();
                ComboBoxItem typeItem2 = (ComboBoxItem)to.SelectedItem;
                string value2 = typeItem2.Content.ToString();
                int i = Findfavcurinmoney(cl.money, value);
                int y = Findfavcurinmoney(cl.money, value2);
                t.Getchange(from.Text,to.Text,switch_.Text);
                cl.money[i].value -= Double.Parse(switch_.Text);
                
                cl.money[y].value += t.objectRes.conversion_result;

                var c = new ClientDBAccess();
                c.UpdateClient(cl);
                Hide();
                UserWindow userWindow = new UserWindow(cl);
                userWindow.Show();
            }
            catch (Exception exception)
            {
                //
            }
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem typeItem = (ComboBoxItem)ComboBox.SelectedItem;
                string value = typeItem.Content.ToString();
                int i = Findfavcurinmoney(cl.money, value);
                moneyincurrecny.Text =cl.money[i].value.ToString();
            }
            catch (Exception exception)
            {
                //
            }
        }
    }
}