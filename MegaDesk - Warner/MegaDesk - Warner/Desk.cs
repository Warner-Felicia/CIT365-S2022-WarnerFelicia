namespace MegaDesk___Warner
{
    internal class Desk
    {
        public double Width { get; set; }
        public double Depth { get; set; }
        public int Drawers { get; set; }
        public SurfaceMaterial SurfaceMaterial { get; set; }
        public RushOptions RushOptions { get; set; }

        public const double DEPTH_MAX = 48;
        public const double DEPTH_MIN = 12;
        public const double WIDTH_MAX = 96;
        public const double WIDTH_MIN = 24;

        public Desk(double width, double depth, int drawers, SurfaceMaterial surfaceMaterial, RushOptions rushOptions)

        {
            this.Width = width;
            this.Depth = depth;
            this.Drawers = drawers;
            this.SurfaceMaterial = surfaceMaterial;
            this.RushOptions = rushOptions;
        }

    }

    internal enum SurfaceMaterial
    {
        Oak = 200,
        Laminate = 100,
        Pine = 50,
        Rosewood = 300,
        Veneer = 125
    }

    enum RushOptions
    {
        Three,
        Five,
        Seven

    }
}
