using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>Screenshot 152104: a tall, narrow three-tier pagoda tower. Approximation.</summary>
    public static class PagodaTower
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 6;
            var g = new GridBuilder(13, 30);
            g.Tier(cx, 29, 5, 5, 3, 'B', 'D', 'w');
            g.Tier(cx, 24, 4, 5, 3, 'B', 'D', 'w');
            g.Tier(cx, 19, 3, 5, 3, 'B', 'D', 'w');
            g.DoorGap(1, 29);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['B'] = TileID.BlueDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.LivableRoom(def, doorX: 1, floorY: 29, torchLX: 3, torchRX: 9, tableX: 3, chairX: 6);
            return def;
        }
    }
}
