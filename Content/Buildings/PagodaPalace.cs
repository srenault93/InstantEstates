using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>Screenshot 152130: a large four-tier pagoda mansion. Approximation.</summary>
    public static class PagodaPalace
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 13;
            var g = new GridBuilder(27, 38);
            g.Tier(cx, 37, 12, 6, 3, 'B', 'D', 'w');
            g.Tier(cx, 31, 9, 6, 3, 'B', 'D', 'w');
            g.Tier(cx, 25, 6, 5, 3, 'B', 'D', 'w');
            g.Tier(cx, 20, 4, 5, 3, 'B', 'D', 'w');
            g.DoorGap(1, 37);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['B'] = TileID.BlueDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.LivableRoom(def, doorX: 1, floorY: 37, torchLX: 5, torchRX: 21, tableX: 4, chairX: 8);
            return def;
        }
    }
}
