using System;

namespace MegaDesk___Warner
{
    internal class DeskQuote
    {
        public  string CustomerName { get; }
        public double BasePrice { get; }
        public double AreaPrice { get; }
        public double DrawersPrice { get; }
        public double MaterialsPrice { get; }
        public double RushOrderPrice { get; }
        public double TotalPrice { get; }

        public DateTime Date { get; }

        public DeskQuote(Desk desk, string customerName)
        {
            this.CustomerName = customerName;

            //hard-coded business values
            BasePrice = 200;
            double minArea = 1000;
            double areaUnitPrice = 1;
            double drawersUnitPrice = 50;
            
            
            //calculating area
            double area = desk.Depth * desk.Width;

            this.AreaPrice = Math.Max((area - minArea), 0) * areaUnitPrice;
            this.DrawersPrice = desk.Drawers * drawersUnitPrice;
            MaterialsPrice = (int)desk.SurfaceMaterial;

            switch (desk.RushOptions.ToString())
            {
                case "Three":
                    if (area < 1000)
                        this.RushOrderPrice = 60;
                    else if (area > 1000 && area < 2000)
                        this.RushOrderPrice = 70;
                    else
                    {
                        this.RushOrderPrice = 80;
                    }
                    break;
                case "Five":
                    if (area < 1000)
                        this.RushOrderPrice = 40;
                    else if (area > 1000 && area < 2000)
                        this.RushOrderPrice = 50;
                    else
                    {
                        this.RushOrderPrice = 60;
                    }
                    break;
                case "Seven":
                    if (area < 1000)
                        this.RushOrderPrice = 30;
                    else if (area > 1000 && area < 2000)
                        this.RushOrderPrice = 35;
                    else
                    {
                        this.RushOrderPrice = 40;
                    }
                    break;
            }

            this.TotalPrice = BasePrice + this.AreaPrice + this.DrawersPrice + this.MaterialsPrice + this.RushOrderPrice;

            this.Date = DateTime.Today;



        }
    }

    

    
}
