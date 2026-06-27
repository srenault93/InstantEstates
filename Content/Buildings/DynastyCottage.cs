using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>
    /// First real reference build (screenshot 152053): a small Japanese cottage with a
    /// red Dynasty-shingle gable roof, Dynasty-wood frame, white Dynasty interior walls,
    /// a door, torches, and a table + chair. Livable. First pass for the roofline -
    /// expect slope/tile tuning after seeing it in-game.
    ///
    /// Legend:
    ///   D = Dynasty Wood (frame/floor/ceiling/posts)
    ///   R = Red Dynasty Shingles (roof, solid)
    ///   / \ = Red Dynasty Shingles, sloped (roof eave ends)
    ///   w (walls) = White Dynasty wall (interior backing)
    /// </summary>
    public static class DynastyCottage
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            var def = new BuildingDef
            {
                Tiles = new[]
                {
                    ".......D.......", // 0  ridge ornament
                    "......RRR......", // 1  roof
                    ".....RRRRR.....", // 2
                    "....RRRRRRR....", // 3
                    "...RRRRRRRRR...", // 4
                    "..\\RRRRRRRRR/..", // 5  sloped eave ends
                    "DDDDDDDDDDDDDDD", // 6  ceiling beam
                    "D.............D", // 7  interior
                    "D.............D", // 8
                    "D.............", // 9  (door gap, right)
                    "D.............", // 10 (door gap)
                    "D.............", // 11 (door gap)
                    "DDDDDDDDDDDDDDD", // 12 floor
                },
                Walls = new[]
                {
                    "               ", // 0
                    "               ", // 1
                    "               ", // 2
                    "               ", // 3
                    "               ", // 4
                    "               ", // 5
                    "               ", // 6
                    " wwwwwwwwwwwww ", // 7
                    " wwwwwwwwwwwww ", // 8
                    " wwwwwwwwwwwwww", // 9
                    " wwwwwwwwwwwwww", // 10
                    " wwwwwwwwwwwwww", // 11
                    "               ", // 12
                },
            };

            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['R'] = TileID.RedDynastyShingles;
            def.TileLegend['/'] = TileID.RedDynastyShingles;
            def.TileLegend['\\'] = TileID.RedDynastyShingles;

            def.SlopeLegend['/'] = SlopeType.SlopeDownRight;
            def.SlopeLegend['\\'] = SlopeType.SlopeDownLeft;

            def.WallLegend['w'] = WallID.WhiteDynasty;

            // Door in the right-wall gap (rows 9-11, col 14).
            def.Furniture.Add(new Furniture(FurnitureKind.Door, TileID.ClosedDoor, x: 14, y: 10));
            // Light.
            def.Furniture.Add(new Furniture(FurnitureKind.Torch, TileID.Torches, x: 4, y: 8));
            def.Furniture.Add(new Furniture(FurnitureKind.Torch, TileID.Torches, x: 10, y: 8));
            // Flat-surface + comfort items.
            def.Furniture.Add(new Furniture(FurnitureKind.Object, TileID.Tables, x: 3, y: 11));
            def.Furniture.Add(new Furniture(FurnitureKind.Object, TileID.Chairs, x: 6, y: 11));

            return def;
        }
    }
}
