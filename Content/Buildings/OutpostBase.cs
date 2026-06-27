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

            g.Box(1, 5, 15, 23, 'W');        // wooden shell
            g.FillWalls(2, 6, 14, 22, 'o');  // wood backing
            g.HLine(2, 14, 11, 'P');         // upper platform floor
            g.HLine(2, 14, 17, 'P');         // middle platform floor
            g.Roof(cx, 4, 8, 5, 'W');        // wood gable
            g.DoorGap(1, 23);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['W'] = TileID.WoodBlock;
            def.PlatformLegend['P'] = 0; // wood platform
            def.WallLegend['o'] = WallID.Wood;

            // Ground floor.
            Furnish.LivableRoom(def, doorX: 1, floorY: 23, torchLX: 4, torchRX: 12, tableX: 3, chairX: 6);
            // Lights for the upper floors.
            Furnish.Light(def, 4, 15);
            Furnish.Light(def, 12, 15);
            Furnish.Light(def, 4, 9);
            Furnish.Light(def, 12, 9);

            return def;
        }
    }
}
