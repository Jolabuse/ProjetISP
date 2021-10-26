using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProjetISF.Database;
using ProjetISF.Person;

namespace ProjetISF
{
    public partial class addCllientWindow : Window
    {
        public addCllientWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Money m,m2,m3;
            var c = new ClientDBAccess();
            ComboBoxItem typeItem = (ComboBoxItem)currency.SelectedItem;
            string value = typeItem.Content.ToString();
            List<Money> money = new List<Money>();
            m = new Money();
            m2 = new Money();
            m3 = new Money();
            m.currency ="EUR";
            m.value =10;
            money.Add(m);
            m2.currency ="USD";
            m2.value =10;
            money.Add(m2);
            m3.currency ="JPY";
            m3.value =10;
            money.Add(m3);
            c.CreateUser(firstname.Text,name.Text,pin.Text,typeItem.Content.ToString(),money);
            Close();

        }
    }
}