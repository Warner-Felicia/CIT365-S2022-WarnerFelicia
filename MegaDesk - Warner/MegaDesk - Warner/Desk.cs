namespace MegaDesk___Warner
{
    public class Desk
    {
        public double Width { get; }
        public double Depth { get; }

        public double Area { get; }

        public int Drawers { get; }
        public SurfaceMaterial SurfaceMaterial { get; set; }
        public RushOptions RushOptions { get; set; }

        public const double DepthMax = 48;
        public const double DepthMin = 12;
        public const double WidthMax = 96;
        public const double WidthMin = 24;

        public Desk(double width, double depth, int drawers, SurfaceMaterial surfaceMaterial, RushOptions rushOptions)

        {
            Width = width;
            Depth = depth;
            Area = width * depth;
            Drawers = drawers;
            SurfaceMaterial = surfaceMaterial;
            RushOptions = rushOptions;
        }

    }

    public enum SurfaceMaterial
    {
        Oak = 200,
        Laminate = 100,
        Pine = 50,
        Rosewood = 300,
        Veneer = 125
    }

    public enum RushOptions
    {
        Three,
        Five,
        Seven,
        Fourteen

    }
}
