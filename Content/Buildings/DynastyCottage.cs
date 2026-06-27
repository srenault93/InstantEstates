using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>
    /// Screenshot 152053: a small Japanese cottage with a wide red-shingle overhanging
    /// roof, a pointed gable cap, Dynasty-wood frame, white interior walls, door, torches,
    /// table + chair. Livable.
    /// </summary>
    public static class DynastyCottage
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 8;
            var g = new GridBuilder(17, 15);

            int f = g.PagodaTier(cx, 13, 6, 5, 8, 'R', 'D', 'w'); // room + wide red eave
            g.RoofCap(cx, f - 1, 4, 'R', 'D');                    // gable cap + finial
            g.DoorGap(14, 13);                                    // door in right wall

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['R'] = TileID.RedDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.LivableRoom(def, doorX: 14, floorY: 13, torchLX: 5, torchRX: 11, tableX: 4, chairX: 7);
            return def;
        }
    }
}
