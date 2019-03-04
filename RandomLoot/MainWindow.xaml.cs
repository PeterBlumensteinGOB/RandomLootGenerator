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
using MySql;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using System.Linq;

namespace RandomLoot
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        lootLocation selectedLocation;

        Random random = new Random();
        List<windowList> items = new List<windowList>();
        List<lootLocation> locationList;

        lootSQLResult sQLResult;
        SqlAbfrage getInformation;

        public MainWindow()
        {
            InitializeComponent();
            CultureInfo cultureInfo = CultureInfo.InstalledUICulture;
            setLanguage(cultureInfo);

            sQLResult = new lootSQLResult();

            //MySqlConnection conn = DBUtils.GetDBConnection();
            //conn.Open();



            //*******
            // Liste aus der SQL Tabelle mit allen Häusern
            //*******
            getInformation = new SqlAbfrage();
            locationList = getInformation.getLocations(this);

            for (int i = 0; i < locationList.Count(); i++)
            {
                LocationCB.Items.Add(locationList[i].getLocationName());
            }

            
            
        }

        public void setLanguage(CultureInfo cultureInfo)
        {
            if (cultureInfo.Name == "en-GB")
            {
                headerLabel.Content = "Loot Generator";
                LocationLbl.Content = "Location:";
                LootBoxCBLbl.Content = "Lootbox:";
            }
            else
            {
                headerLabel.Content = "Beutegenerator";
                LocationLbl.Content = "Ort:";
                LootBoxCBLbl.Content = "Beutekiste:";
            }
        }

        //public List<lootLocation> SetHouseType()
        //{
        //    List<lootLocation> locationList = new List<lootLocation>();
        //    getInformation = new SqlAbfrage();
        //    locationList = getInformation.getLocations(this);



        //    //List<string> locationList = new List<string>();
        //    //locationList.Add("Wohnhaus");
        //    //locationList.Add("Lehmhaus");
        //    //locationList.Add("Jagdhütte");
        //    //locationList.Add("Trollhöhle");
        //    return locationList;
        //}

        private void LocationCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LootBoxCB.Items.Clear();
            boxView.Items.Clear();

            selectedLocation = locationList.FirstOrDefault(o => o.name == Convert.ToString(LocationCB.SelectedItem));
            if (selectedLocation != null)
            {
                if (itemView.Items != null)
                {
                    itemView.Items.Clear();
                }

               
                

                // Hole dir die LootItems und speichere sie in Objekten
                sQLResult.clearLootItemsList();
                sQLResult = getInformation.getItemsOfLocation(selectedLocation.name, this);

                selectedLocation.createLootBoxes(sQLResult);
                selectedLocation.showLootBoxes(this);
            }
            else
            {
                itemView.Items.Clear();
            }
        }

        public void updateList(string boxNamePar, string itemNamePar, string itemValuePar)
        {
            itemView.Items.Add(new windowList { boxName = boxNamePar,
                itemName = itemNamePar,
                itemValue = itemValuePar });

            List<windowList> Items = new List<windowList>();
            

        }

        private void boxView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //object chosenBox = boxView.SelectedItem;
            //string testString = boxView.SelectedItem.ToString();
            //selectedLocation.showBoxItems(this, boxView.SelectedItems[0]);
                
        }

        private void LootBoxCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            itemView.Items.Clear();
            selectedLocation.showBoxItems(this, LootBoxCB.SelectedItem);
        }
    }
}
