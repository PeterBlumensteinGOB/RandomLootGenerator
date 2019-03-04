using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLoot
{
    class lootBox
    {
        public string boxName { get; set; }
        public int maxValueBox { get; set; }
        private int maxItems;
        private lootLocation location;

        private List<lootItem> lootItemsList;
        private Random random = new Random();

        public lootBox(string lootBoxNamePar, int maxValueBoxPar, lootLocation locationPar, lootSQLResult sQLResult)
        {
            boxName = lootBoxNamePar;
            maxValueBox = maxValueBoxPar;
            location = locationPar;

            maxItems = random.Next(1, 5);

            createLootItemsList(sQLResult);
        }

        public void createLootItemsList(lootSQLResult sQLResult)
        {
            int maxValueItem = maxValueBox;
            lootItemsList = new List<lootItem>();
            for (int i = 1; i <= maxItems; i++)
            {
                if (maxValueItem > 0)
                {
                    // getItemFromDB!
                    
                    int itemValue = random.Next(0, maxValueItem);
                    maxValueItem = maxValueItem - itemValue;
                    lootItem addItem = sQLResult.getRandomItemFromList(itemValue);
                    if (addItem != null)
                    {
                        lootItemsList.Add(addItem);
                    }
                    

                    //string itemName = String.Format("ItemName{0}", i);
                    //lootItemsList.Add(new lootItem(itemName, itemValue));
                }
            }
        }

        public List<lootItem> GetLootItems()
        {
            return lootItemsList;
        }

    }
}
