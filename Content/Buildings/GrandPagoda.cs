using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>Screenshot 151909: a wide three-tier teal-roof pagoda. Approximation.</summary>
    public static class GrandPagoda
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 11;
            var g = new GridBuilder(23, 32);
            g.Tier(cx, 31, 10, 6, 3, 'B', 'D', 'w'); // ground tier
            g.Tier(cx, 25, 7, 5, 3, 'B', 'D', 'w');  // middle tier
            g.Tier(cx, 20, 4, 4, 3, 'B', 'D', 'w');  // top tier
            g.DoorGap(1, 31);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['B'] = TileID.BlueDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.LivableRoom(def, doorX: 1, floorY: 31, torchLX: 5, torchRX: 17, tableX: 4, chairX: 7);
            return def;
        }
    }
}
