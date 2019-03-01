using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLoot
{
    class lootLocation
    {
        private string name;
        private int maxLootBoxes;
        private int maxValueLoc;
        private List<lootBox> lootBoxes = new List<lootBox>();

        MainWindow MainWindow;
        Random random = new Random();

        public lootLocation(string LocationNamepar, int maxlootboxespar, int maxvaluepar, MainWindow main)
        {
            name = LocationNamepar;
            maxLootBoxes = maxlootboxespar;
            maxValueLoc = maxvaluepar;

            MainWindow = main;

            int maxValueBox = maxValueLoc;
            createLootBoxes(maxValueBox);

            
        }

        private void createLootBoxes(int maxValueBox)
        {
            int numberOfLootBoxes = random.Next(1, maxLootBoxes + 1);
            for (int i = 1; i <= numberOfLootBoxes; i++)
            {
                int maxItemValue = random.Next(0, maxValueBox);
                maxValueBox = maxValueBox - maxItemValue;

                string lootBoxName = String.Format("LootBox{0}", i);
                lootBoxes.Add(new lootBox(lootBoxName, maxItemValue, this, MainWindow));
            }

        }
    }
}
