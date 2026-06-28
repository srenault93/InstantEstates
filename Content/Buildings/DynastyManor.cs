using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>
    /// Screenshot 151958, built to the provided spec: a 48-wide two-floor Japanese
    /// house. Outer Dynasty-wood shell, partition walls 3 in from each edge with a
    /// door on BOTH sides of every floor, a Dynasty platform mid-floor, white Dynasty
    /// interior walls, themed Dynasty furniture, and a wide tiered red roof capped
    /// with Dynasty wood.
    /// </summary>
    public static class DynastyManor
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            var g = new GridBuilder(48, 34);

            // Shell: side walls, ground floor, top ceiling (under the roof).
            g.VLine(1, 13, 31, 'D');
            g.VLine(46, 13, 31, 'D');
            g.HLine(1, 46, 31, 'D');
            g.HLine(1, 46, 13, 'D');

            // Mid floor is a Dynasty platform you can pass through.
            g.HLine(2, 45, 22, 'P');

            // White Dynasty interior (both floors).
            g.FillWalls(2, 14, 45, 30, 'w');

            // Partition walls 3 in from each edge, with doors carved per floor.
            g.VLine(4, 14, 30, 'D');
            g.VLine(43, 14, 30, 'D');
            g.DoorGap(4, 31); g.DoorGap(43, 31);   // ground floor
            g.DoorGap(4, 22); g.DoorGap(43, 22);   // upper floor

            // Wide tiered red hip roof, capped with Dynasty wood.
            int rx0 = 0, rx1 = 47, ry = 12;
            while (rx1 - rx0 >= 4) { g.HLine(rx0, rx1, ry, 'R'); rx0 += 3; rx1 -= 3; ry--; }
            g.HLine(rx0, rx1, ry, 'D');

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['R'] = TileID.RedDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;
            def.PlatformLegend['P'] = ItemID.DynastyPlatform;

            Furnish.DynastyRoom(def, leftDoorX: 4, rightDoorX: 43, floorY: 31, leftInner: 6, rightInner: 41);
            Furnish.DynastyRoom(def, leftDoorX: 4, rightDoorX: 43, floorY: 22, leftInner: 6, rightInner: 41);
            return def;
        }
    }
}
