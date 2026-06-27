using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>Screenshot 151958: a wide two-floor Dynasty house with a red gable roof. Approximation.</summary>
    public static class DynastyManor
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 14;
            var g = new GridBuilder(29, 22);

            g.Box(1, 8, 27, 21, 'D');          // two-story outer shell
            g.FillWalls(2, 9, 26, 20, 'w');    // interior backing
            g.HLine(2, 26, 14, 'D');           // mid floor
            g.Roof(cx, 7, 14, 5, 'R');         // red gable roof
            g.DoorGap(1, 21);                  // ground-floor door

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['R'] = TileID.RedDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            // Ground floor (floor row 21).
            Furnish.LivableRoom(def, doorX: 1, floorY: 21, torchLX: 6, torchRX: 22, tableX: 4, chairX: 8);
            // Upper floor (floor row 14).
            def.Furniture.Add(new Furniture(FurnitureKind.Torch, TileID.Torches, 6, 13));
            def.Furniture.Add(new Furniture(FurnitureKind.Torch, TileID.Torches, 22, 13));
            def.Furniture.Add(new Furniture(FurnitureKind.Object, TileID.Tables, 4, 13));
            def.Furniture.Add(new Furniture(FurnitureKind.Object, TileID.Chairs, 8, 13));

            return def;
        }
    }
}
