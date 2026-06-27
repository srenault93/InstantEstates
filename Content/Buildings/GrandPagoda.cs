using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>Screenshot 151909: a wide three-tier teal-roof pagoda with overhanging eaves.</summary>
    public static class GrandPagoda
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 12;
            var g = new GridBuilder(25, 34);

            int f = g.PagodaTier(cx, 33, 9, 6, 11, 'B', 'D', 'w'); // ground tier
            f = g.PagodaTier(cx, f, 7, 5, 9, 'B', 'D', 'w');       // middle tier
            f = g.PagodaTier(cx, f, 5, 5, 7, 'B', 'D', 'w');       // top tier
            g.RoofCap(cx, f - 1, 4, 'B', 'D');                     // pointed cap + finial
            g.DoorGap(3, 33);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['B'] = TileID.BlueDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.LivableRoom(def, doorX: 3, floorY: 33, torchLX: 7, torchRX: 17, tableX: 5, chairX: 9);
            return def;
        }
    }
}
