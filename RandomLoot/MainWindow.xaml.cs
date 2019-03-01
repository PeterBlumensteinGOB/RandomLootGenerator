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
using System.Globalization;
using System.Windows.Markup;

namespace RandomLoot
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        object lastSelectedItem;
        lootLocation loot;
        Random random = new Random();
        List<windowList> items = new List<windowList>();

        public MainWindow()
        {
            InitializeComponent();
            CultureInfo cultureInfo = CultureInfo.InstalledUICulture;
            setLanguage(cultureInfo);


            //*******
            // Liste aus der SQL Tabelle mit allen Häusern
            //*******

            List<string> locationList = setHouseType();

            for (int i = 0; i < locationList.Count(); i++)
            {
                LocationCB.Items.Add(locationList[i]);
            }
            
        }

        public void setLanguage(CultureInfo cultureInfo)
        {
            if (cultureInfo.Name == "en-GB")
            {
                headerLabel.Content = "Loot Generator";
                LocationLbl.Content = "Location:";
            }
            else
            {
                headerLabel.Content = "Beutegenerator";
                LocationLbl.Content = "Ort:";
            }
        }

        public List<string> setHouseType()
        {
            List<string> locationList = new List<string>();
            locationList.Add("Wohnhaus");
            locationList.Add("Lehmhaus");
            locationList.Add("Jagdhütte");
            locationList.Add("Trollhöhle");
            return locationList;
        }

        private void LocationCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(LocationCB.SelectedItem != lastSelectedItem)
            {
                lastSelectedItem = LocationCB.SelectedItem;
                if (lastSelectedItem.ToString() == "Lehmhaus")
                {
                    
                    loot = new lootLocation(lastSelectedItem.ToString(), random.Next(5), random.Next(100, 300), this);
                }
                else
                {
                    itemView.Items.Clear();
                }
            }
        }

        public void updateList(string boxNamePar, string itemNamePar, string itemValuePar)
        {
            //    items.Add(new windowList
            //    {
            //        boxName = boxNamePar,
            //        itemName = itemNamePar,
            //        itemValue = itemValuePar
            //    });

            itemView.Items.Add(new windowList { boxName = boxNamePar,
                itemName = itemNamePar,
                itemValue = itemValuePar });

        }

        private void ItemView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            itemView.Items.Add("10");
            
        }
    }
}
