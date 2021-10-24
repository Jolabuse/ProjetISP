using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
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
            title.Text = "Bank Acount of " + c.firstname +" "+ c.name;
            favcurrency.Text = c.currency;
            totalfavcurrency.Text = c.currency + " only :" ;
            total.Text = GetTotal(c.money,c.currency).ToString();
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
                to.Getchange(cur,mo.currency,mo.value.ToString());
                total += to.objectRes.conversion_result;
                using StreamWriter file = new("WriteLines2.txt", append: true);
                file.WriteLineAsync(to.objectRes.conversion_result.ToString()); 
                using StreamWriter file2 = new("WriteLines.txt", append: true);
                file2.WriteLineAsync(mo.value.ToString()+mo.currency);
            }
            
            
            return total;

        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }  
        private void ButtonRemove_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonConver_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}