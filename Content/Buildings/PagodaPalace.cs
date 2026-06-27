using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>Screenshot 152130: a large four-tier pagoda mansion with overhanging eaves.</summary>
    public static class PagodaPalace
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 14;
            var g = new GridBuilder(31, 42);

            int f = g.PagodaTier(cx, 41, 12, 6, 14, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 10, 6, 12, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 7, 5, 9, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 5, 5, 7, 'B', 'D', 'w');
            g.RoofCap(cx, f - 1, 5, 'B', 'D');
            g.DoorGap(2, 41);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['B'] = TileID.BlueDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.LivableRoom(def, doorX: 2, floorY: 41, torchLX: 6, torchRX: 22, tableX: 5, chairX: 9);
            return def;
        }
    }
}
