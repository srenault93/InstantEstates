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
            var g = new GridBuilder(31, 46);

            int f = g.PagodaTier(cx, 45, 12, 8, 14, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 10, 7, 12, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 7, 7, 9, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 5, 6, 7, 'B', 'D', 'w');
            g.RoofCap(cx, f - 1, 5, 'B', 'D');
            g.DoorGap(2, 45); g.DoorGap(26, 45);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['B'] = TileID.BlueDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.DynastyRoom(def, leftDoorX: 2, rightDoorX: 26, floorY: 45, leftInner: 3, rightInner: 25);
            return def;
        }
    }
}
