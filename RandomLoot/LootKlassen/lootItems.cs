using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLoot
{
    class lootItem
    {
        public string itemName { get; set; }
        public int itemValue { get; set; }

        //private MainWindow mainWindow;

        private lootBox lootBox;
        private Random random = new Random();

        public lootItem(string itemNamePar, int itemValuePar)
        {
            itemName = itemNamePar;
            itemValue = itemValuePar;

            //itemValue = calcItemValue();
        }

        //private int calcItemValue()
        //{
            //int newItemValue = random.Next(maxValueItem);
            //mainWindow.updateList(lootBox.boxName, itemName, Convert.ToString(newItemValue));
            //return newItemValue;
        //}

        public int getItemValue()
        {
            return itemValue;
        }
    }
}
