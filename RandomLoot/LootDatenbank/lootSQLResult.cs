using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLoot
{
    class lootSQLResult
    {
        List<lootSQLResultItem> lootItemsList;

        Random random;

        public lootSQLResult()
        {
            lootItemsList = new List<lootSQLResultItem>();
            random = new Random();
        }

        public void assignLootsItemList(string itemNamePar, int itemValuePar)
        {
            lootItemsList.Add(new lootSQLResultItem(itemNamePar, itemValuePar));
        }

        public List<lootSQLResultItem> getLootItemsList()
        {
            return lootItemsList;
        }

        public void clearLootItemsList()
        {
            lootItemsList.Clear();
        }

        public lootItem getRandomItemFromList(int maxItemValue)
        {
            List<lootItem> chosenLootItems = new List<lootItem>();
            for (int i = 0; i < lootItemsList.Count(); i++)
            {
                if (lootItemsList[i].itemValue <= maxItemValue)
                {
                    chosenLootItems.Add(new lootItem(lootItemsList[i].itemName, lootItemsList[i].itemValue ));
                }
            }


            if (chosenLootItems.Count() == 0)
            {
                return null;
            }
            else
            {
                int maxValue = chosenLootItems.Count() - 1;
                lootItem chosenLootItem = chosenLootItems[random.Next(maxValue)];
                if (chosenLootItem != null)
                {
                    return chosenLootItem;
                }
                else
                {
                    return null;
                }
            }
            
        }
    }
    
}
