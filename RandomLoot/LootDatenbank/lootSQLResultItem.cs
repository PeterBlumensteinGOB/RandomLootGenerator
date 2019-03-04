using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLoot
{
    class lootSQLResultItem
    {
        public string itemName { get; set; }
        public int itemValue { get; set; }

        public lootSQLResultItem(string itemNamePar, int itemValuePar)
        {
            itemName = itemNamePar;
            itemValue = itemValuePar;
        }
    }
}
