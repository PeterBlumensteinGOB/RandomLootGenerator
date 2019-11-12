using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLoot
{
    class lootLocation
    {
        public string name { get; set; }
        private int maxLootBoxes;
        private int maxValueLoc;

        private List<lootBox> lootBoxesList = new List<lootBox>();

        Random random = new Random();

        public lootLocation(string LocationNamepar, int maxlootboxespar, int maxvaluepar)
        {
            name = LocationNamepar;
            maxLootBoxes = maxlootboxespar;
            maxValueLoc = maxvaluepar;
        }

        public void createLootBoxes(lootSQLResult sQLResult)
        {
            lootBoxesList.Clear();

            int maxValueBox = maxValueLoc;
            int numberOfLootBoxes = random.Next(1, maxLootBoxes + 1);

            for (int i = 1; i <= numberOfLootBoxes; i++)
            {
                if (maxValueBox > 0)
                {
                    int lastValueBox = random.Next(0, maxValueBox);
                    maxValueBox = maxValueBox - lastValueBox;

                    string lootBoxName = String.Format("LootBox{0}", i);

                    lootBoxesList.Add(new lootBox(lootBoxName, lastValueBox, this, sQLResult));
                    //lootBoxesList[i].createLootItemsList(sQLResult);
                }

                else
                {
                    break;
                }
            }

        }
        public string getLocationName()
        {
            return name;
        }

        public void showLootBoxes(MainWindow main)
        {
            main.LootBoxCB.Items.Clear();

            for (int i = 0; i < lootBoxesList.Count(); i++)
            {
                List<lootItem> testList = lootBoxesList[i].GetLootItems();
                if (testList != null)
                {

                    main.LootBoxCB.Items.Add(lootBoxesList[i].boxName);


                    main.boxView.Items.Add(new windowListBoxes
                    {
                        boxName = lootBoxesList[i].boxName,
                        maxBoxValue = Convert.ToString(lootBoxesList[i].maxValueBox)
                    });
                }

            }
        }

        public void showBoxItems(MainWindow main, object selectedItem)
        {
            lootBox selectedLootBoxViewItem = lootBoxesList.FirstOrDefault(o => o.boxName == Convert.ToString(selectedItem));
            

            if (selectedLootBoxViewItem != null)
            {
                List<lootItem> lootItemsList = selectedLootBoxViewItem.GetLootItems();
                for (int i = 0; i < lootItemsList.Count(); i++)
                {
                    if (lootItemsList[i] != null)
                    {
                        main.itemView.Items.Add(new windowList
                        {
                            boxName = Convert.ToString(selectedItem),
                            itemName = lootItemsList[i].itemName,
                            itemValue = Convert.ToString(lootItemsList[i].itemValue)
                        });
                    }
                }
            }
        }



    }             
                
                
        

}

