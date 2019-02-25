using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MenuSetting
{
    public class MenuHepler
    {

        private SortedList<string, string> MenuList = new SortedList<string, string>();

        public MenuHepler(string path)
        {
            //產品選單
            string fileName = path + "/App_data/menu.xml";

            XDocument xd = XDocument.Load(fileName);

            //   menuName = xd.SelectSingleNode($"./Menus/menu[@id='{menuId}']/culture[@name='zh-tw']").InnerText;

            var nodeList = (from x in xd.Element("Menus").Elements("menu").Elements("culture")
                            where x.Attribute("name").Value == "zh-tw"
                            select new { ID = x.Parent.Attribute("id").Value, Value = x.Value }
                            );

            foreach (var node in nodeList)
            {
                if (!MenuList.Keys.Contains(node.ID))
                    MenuList.Add(node.ID, node.Value);
                else
                    MenuList[node.ID] = node.Value;
            }
            //客製選單

            fileName = path + "/CDS/Setting/menu.xml";

             xd = XDocument.Load(fileName);

            //   menuName = xd.SelectSingleNode($"./Menus/menu[@id='{menuId}']/culture[@name='zh-tw']").InnerText;

             nodeList = (from x in xd.Element("Menus").Elements("menu").Elements("culture")
                            where x.Attribute("name").Value == "zh-tw"
                            select new { ID = x.Parent.Attribute("id").Value, Value = x.Value }
                            );

            foreach (var node in nodeList)
            {
                if (!MenuList.Keys.Contains(node.ID))
                    MenuList.Add(node.ID, node.Value);
                else
                    MenuList[node.ID] = node.Value;
            }
        }

        public string FindKey(string menuID)
        {
            if (!MenuList.Keys.Contains(menuID))
                return menuID;
            else
                return MenuList[menuID];
        }


    }
}
