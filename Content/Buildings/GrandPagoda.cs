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
            var g = new GridBuilder(25, 38);

            int f = g.PagodaTier(cx, 37, 9, 8, 11, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 7, 7, 9, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 5, 6, 7, 'B', 'D', 'w');
            g.RoofCap(cx, f - 1, 4, 'B', 'D');
            g.DoorGap(3, 37); g.DoorGap(21, 37);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['B'] = TileID.BlueDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.DynastyRoom(def, leftDoorX: 3, rightDoorX: 21, floorY: 37, leftInner: 4, rightInner: 20);
            return def;
        }
    }
}
