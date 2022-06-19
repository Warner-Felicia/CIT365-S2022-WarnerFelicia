using System;
using System.ComponentModel;
using System.IO;

namespace MegaDeskRazorPages.Models
{
    public class DeskQuote : Desk
    {
        public int Id { get; set; }

        //Properties of the DeskQuote class
        [DisplayName("First Name")]

        public string customerFirstName { get; set; }
        [DisplayName("Last Name")]
        public string customerLastName { get; set; }
        [DisplayName("Rush Days")]
        public int rushDays { get; set; }
        [DisplayName("Date")]
        public DateTime quoteDate { get; set; }
        [DisplayName("Quote Price")]
        public int quoteTotal { get; set; }

        // Constructor
        public DeskQuote(int width, int depth, int drawers, string surfaceMaterial, int rushDays, string customerFirstName, string customerLastName) :
            base(width, depth, drawers, surfaceMaterial)
        {
            this.rushDays = rushDays;
            this.customerFirstName = customerFirstName;
            this.customerLastName = customerLastName;
            this.quoteTotal = getQuoteTotal();
            this.quoteDate = DateTime.Today;
        }

        public int calcRushPrice()
        {
            int surfaceArea = calcSurfaceArea();
            int rushPrice;
            int[,] rushPrices = getRushOrder();

            if (rushPrices == null)
            {
                return 0;
            }

            switch (rushDays)
            {
                case 3:
                    if (surfaceArea < 1000) rushPrice = rushPrices[0, 0];
                    else if (surfaceArea <= 2000) rushPrice = rushPrices[0, 1];
                    else rushPrice = rushPrices[0, 2];
                    break;
                case 5:
                    if (surfaceArea < 1000) rushPrice = rushPrices[1, 0];
                    else if (surfaceArea <= 2000) rushPrice = rushPrices[1, 1];
                    else rushPrice = rushPrices[1, 2];
                    break;
                case 7:
                    if (surfaceArea < 1000) rushPrice = rushPrices[2, 0];
                    else if (surfaceArea <= 2000) rushPrice = rushPrices[2, 1];
                    else rushPrice = rushPrices[2, 2];
                    break;
                default:
                    rushPrice = 0;
                    break;
            }
            return rushPrice;
        }

        public int[,] getRushOrder()
        {
            try
            {
                StreamReader reader = new StreamReader("Resources/rushOrderPrices.txt");
                int i1 = 0;
                int[,] rushPrices = new int[3, 3];
                while (reader.EndOfStream == false)
                {
                    for (int i2 = 0; i2 < 3; i2++)
                    {
                        rushPrices[i1, i2] = Convert.ToInt32(reader.ReadLine());
                    }

                    i1++;
                }
                reader.Close();
                return rushPrices;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public int calcDrawerPrice()
        {
            return 50 * drawers;
        }

        public int calcAreaPrice()
        {
            int surfaceArea = calcSurfaceArea();
            if (surfaceArea > 1000)
            {
                return 200 + (surfaceArea - 1000);
            }
            else
            {
                return 200;
            }
        }

        public int calcMaterialPrice()
        {
            string material = surfaceMaterial;
            int materialPrice = 0;

            switch (material)
            {
                case "Oak":
                    materialPrice = 200;
                    break;
                case "Laminate":
                    materialPrice = 100;
                    break;
                case "Pine":
                    materialPrice = 50;
                    break;
                case "Rosewood":
                    materialPrice = 300;
                    break;
                case "Veneer":
                    materialPrice = 125;
                    break;
            }
            return materialPrice;
        }

        public int getQuoteTotal()
        {
            int totalPrice = calcAreaPrice() + calcDrawerPrice() + calcMaterialPrice() + calcRushPrice();
            return totalPrice;
        }

       
    }
}
