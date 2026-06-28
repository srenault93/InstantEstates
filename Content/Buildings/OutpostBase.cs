using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>Screenshot 152200: a three-floor wooden survival base with platform floors. Approximation.</summary>
    public static class OutpostBase
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 8;
            var g = new GridBuilder(17, 24);

            g.Box(1, 5, 15, 23, 'W');
            g.FillWalls(2, 6, 14, 22, 'o');
            g.HLine(2, 14, 11, 'P'); // upper platform floor
            g.HLine(2, 14, 17, 'P'); // middle platform floor
            g.Roof(cx, 4, 8, 5, 'W');
            g.DoorGap(1, 23); g.DoorGap(15, 23);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['W'] = TileID.WoodBlock;
            def.PlatformLegend['P'] = ItemID.WoodPlatform;
            def.WallLegend['o'] = WallID.Wood;

            Furnish.WoodRoom(def, leftDoorX: 1, rightDoorX: 15, floorY: 23, leftInner: 2, rightInner: 14);
            Furnish.Light(def, 4, 15);
            Furnish.Light(def, 12, 15);
            Furnish.Light(def, 4, 9);
            Furnish.Light(def, 12, 9);

            return def;
        }
    }
}
