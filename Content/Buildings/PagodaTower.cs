using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>Screenshot 152104: a tall, narrow three-tier pagoda tower with overhanging eaves.</summary>
    public static class PagodaTower
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 7;
            var g = new GridBuilder(15, 36);

            int f = g.PagodaTier(cx, 35, 5, 7, 7, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 4, 6, 6, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 3, 6, 5, 'B', 'D', 'w');
            g.RoofCap(cx, f - 1, 3, 'B', 'D');
            g.DoorGap(2, 35); g.DoorGap(12, 35);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['B'] = TileID.BlueDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.DynastyRoom(def, leftDoorX: 2, rightDoorX: 12, floorY: 35, leftInner: 3, rightInner: 11);
            return def;
        }
    }
}
