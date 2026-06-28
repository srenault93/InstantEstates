using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>
    /// Screenshot 152053: a small Japanese cottage with a wide red-shingle overhanging
    /// roof, a pointed gable cap, doors on both sides, white Dynasty interior, and themed
    /// Dynasty furniture. Livable.
    /// </summary>
    public static class DynastyCottage
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 9;
            var g = new GridBuilder(19, 16);

            int f = g.PagodaTier(cx, 13, 7, 6, 9, 'R', 'D', 'w');
            g.RoofCap(cx, f - 1, 4, 'R', 'D');
            g.DoorGap(2, 13); g.DoorGap(16, 13);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['R'] = TileID.RedDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.DynastyRoom(def, leftDoorX: 2, rightDoorX: 16, floorY: 13, leftInner: 4, rightInner: 14);
            return def;
        }
    }
}
