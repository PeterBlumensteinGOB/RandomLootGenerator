using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLoot
{
    class lootItem
    {
        private string itemName;
        private int maxValueItem;
        private int itemValue;

        private MainWindow mainWindow;
        private lootBox lootBox;
        private Random random = new Random();

        public lootItem(string itemNamePar, int maxItemValuePar, lootBox lootBoxPar, MainWindow main)
        {
            itemName = itemNamePar;
            maxValueItem = maxItemValuePar;
            lootBox = lootBoxPar;

            mainWindow = main;

            itemValue = calcItemValue();
        }

        private int calcItemValue()
        {
            int newItemValue = random.Next(maxValueItem);
            mainWindow.updateList(lootBox.boxName, itemName, Convert.ToString(newItemValue));
            return newItemValue;
        }

        public int getItemValue()
        {
            return itemValue;
        }
    }
}
