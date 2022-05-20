using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MegaDesk___Warner
{
    public class DeskQuote
    {
        public string CustomerName { get; }
        public Desk Desk;
        public double BasePrice { get; }
        public double AreaPrice { get; }
        public double DrawersPrice { get; }
        public double MaterialsPrice { get; }
        public double RushOrderPrice { get; }
        public double TotalPrice { get; }

        public DateTime Date { get; }

        public static List<DeskQuote> AllQuotes { get; set; }

        public DeskQuote(Desk desk, string customerName)
        {
            CustomerName = customerName;
            Desk = desk;

            //hard-coded business values
            BasePrice = 200;
            const double minArea = 1000;
            const double areaUnitPrice = 1;
            const double drawersUnitPrice = 50;
            
            //calculations
            
            AreaPrice = CalcAreaPrice(desk.Area, minArea, areaUnitPrice);
            DrawersPrice = CalcDrawersPrice(desk.Drawers, drawersUnitPrice);
            MaterialsPrice = (int)desk.SurfaceMaterial;
            RushOrderPrice = CalcRushOrderPrice(desk.RushOptions, desk.Area);

            TotalPrice = BasePrice + AreaPrice + DrawersPrice + MaterialsPrice + RushOrderPrice;

            Date = DateTime.Today;
        }

        private static double CalcAreaPrice(double deskArea, double minArea, double areaUnitPrice)
        {
            return Math.Max((deskArea - minArea), 0) * areaUnitPrice;
        }
        private static double CalcDrawersPrice(int deskDrawers, double drawersUnitPrice)
        {
            return deskDrawers * drawersUnitPrice;
        }
        private static double CalcRushOrderPrice(RushOptions deskRushOptions, double deskArea)
        {
            int price = 0;
            var rushOrderPrices = CreateRushOrderPricesArray();
            
            switch (deskRushOptions.ToString())
            {
                case "Three":
                    if (deskArea < 1000)
                        price = (int)rushOrderPrices.GetValue(0, 0);
                    else if (deskArea > 1000 && deskArea < 2000)
                        price = (int)rushOrderPrices.GetValue(0, 1);
                    else
                        price = (int)rushOrderPrices.GetValue(0, 2);
                    break;
                case "Five":
                    if (deskArea < 1000)
                        price = (int)rushOrderPrices.GetValue(1, 0);
                    else if (deskArea > 1000 && deskArea < 2000)
                        price = (int)rushOrderPrices.GetValue(1, 1);
                    else
                        price = (int)rushOrderPrices.GetValue(1, 2);
                    break;
                case "Seven":
                    if (deskArea < 1000)
                        price = (int)rushOrderPrices.GetValue(2, 0);
                    else if (deskArea > 1000 && deskArea < 2000)
                        price = (int)rushOrderPrices.GetValue(2, 1);
                    else
                        price = (int)rushOrderPrices.GetValue(2, 2);
                    break;
                case "Fourteen":
                    price = 0;
                    break;
            }

            return price;
        }

        private static Array CreateRushOrderPricesArray()
        {
            try
            {
                TextReader textIn = new StreamReader("rushOrderPrices.txt");
                int [,] priceArray = new int[3, 3];
                for (var i = 0; i < 3; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        priceArray[i, j] = Convert.ToInt32((textIn.ReadLine()));
                    }
                }
                Console.WriteLine(priceArray[0, 1]);
                return priceArray;
            }
            catch
            {
                return null;
            }

        }

        public static void SaveQuote(DeskQuote quote)
        {
            if (AllQuotes == null)
            {
                AllQuotes = new List<DeskQuote>();
            }
            AllQuotes.Add(quote);
            var serializedQuotes = JsonConvert.SerializeObject(AllQuotes);
            File.WriteAllText("quotes.json", serializedQuotes);
            }

        
    }
           

        




}

    

    

