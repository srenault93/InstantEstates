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
            var g = new GridBuilder(15, 32);

            int f = g.PagodaTier(cx, 31, 5, 5, 7, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 4, 5, 6, 'B', 'D', 'w');
            f = g.PagodaTier(cx, f, 3, 5, 5, 'B', 'D', 'w');
            g.RoofCap(cx, f - 1, 3, 'B', 'D');
            g.DoorGap(2, 31);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['B'] = TileID.BlueDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.LivableRoom(def, doorX: 2, floorY: 31, torchLX: 4, torchRX: 10, tableX: 4, chairX: 7);
            return def;
        }
    }
}
