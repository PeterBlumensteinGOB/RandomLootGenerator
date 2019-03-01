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
        private int maxValueBox;
        private int maxItems;
        private lootLocation location;
        private MainWindow mainWindow;
        private List<lootItem> lootItems = new List<lootItem>();
        private Random random = new Random();

        public lootBox(string lootBoxNamePar, int maxValueBoxPar, lootLocation locationPar, MainWindow main)
        {
            boxName = lootBoxNamePar;
            maxValueBox = maxValueBoxPar;
            location = locationPar;

            maxItems = random.Next(1, 5);

            int MaxValueItem = maxValueBox;
            mainWindow = main;
            createLootItemsList(MaxValueItem);
        }

        private void createLootItemsList(int maxValueItem)
        {
            for (int i = 1; i <= maxItems; i++)
            {
                if (maxValueItem > 0)
                {
                    int itemValue = random.Next(0, maxValueItem);
                    maxValueItem = maxValueItem - itemValue;

                    string itemName = String.Format("ItemName{0}", i);
                    lootItems.Add(new lootItem(itemName, maxValueItem, this, mainWindow));
                }
            }
        }
    }
}
