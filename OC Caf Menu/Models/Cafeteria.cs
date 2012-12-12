using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;


namespace OC_Caf_Menu.Models
{
    public class Cafeteria
    {
        private static string xmlUrl1 = "http://otmobapp.com/udapp/API_s/Breakfast.xml";

        public List<Meal> Meals;
        //{
        //    get
        //    {
        //        return Meals;
        //    }
        //    set
        //    {
        //        this.Meals.Add(ParseByXMLDocument());
        //    }
        //}

        //public void PopulateClass
        //{
        //   Meals.Add (ParseByXMLDocument());
        //}



        // Parse the XML Document using XMLDocument Class
        public Meal ParseByXMLDocument()
        {
            var aMeal = new Meal();
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlUrl1);

            XmlNode MealNode = doc.SelectSingleNode("/Breakfast");
            aMeal.mealName = MealNode.Name;
            XmlNodeList LineNodeList = MealNode.SelectNodes("Line");
            //XmlNodeList LineNodeList = doc.ChildNodes;
            foreach (XmlNode node in LineNodeList)
            {
                Line aLine = new Line();
                aLine.lineName = node.FirstChild.InnerText;
                //XmlNode LineNode =
                //node.SelectSingleNode("Item");
                XmlNodeList ItemNodeList = node.ChildNodes;

                //XmlNodeList ItemNodeList2 = doc.SelectNodes("Item");
                foreach (XmlNode node2 in ItemNodeList)
                {
                    Item aItem =new Item();
                    aItem.itemName = node2.InnerText;
                    aItem.foodName = node2.InnerText;
                    aItem.foodServingSize = node2.InnerText;
                    aItem.foodCalories = node2.InnerText;
                    aItem.foodFat = node2.InnerText;
                    aItem.foodCholesterol = node2.InnerText;
                    aItem.foodSodium = node2.InnerText;
                    aItem.foodPotassium = node2.InnerText;
                    aItem.foodProtein = node2.InnerText;

                    aLine.ItemList.Add(aItem);
                }

                aMeal.Lines.Add(aLine);
            }

            return aMeal;
        }
        public class Meal
        {
            public string mealName { get; set; }
            public List<Line> Lines { get; set; }
        }   
        public class Line 
        {
            public string lineName {get; set; }
            public List<Item> ItemList {get; set; }
        } 
        public class Item
        {
            public string itemName { get; set; }
            public string foodName { get; set; }
            public string foodServingSize { get; set; }
            public string foodCalories { get; set; }
            public string foodFat { get; set; }
            public string foodCholesterol { get; set; }
            public string foodSodium { get; set; }
            public string foodPotassium { get; set; }
            public string foodCarbhyrate { get; set; }
            public string foodProtein { get; set; }
        }    
       
    }

  

    

    
}