using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>
    /// A small livable wood cottage: hollow box of wood blocks, wood background walls,
    /// a door on the right, two torches, a table and a chair. Meets vanilla housing
    /// requirements (enclosed + wall + light + flat-surface item + comfort item).
    /// This is the placeholder proof-of-concept until real builds are encoded from images.
    /// </summary>
    public static class StarterCottage
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            var def = new BuildingDef
            {
                Tiles = new[]
                {
                    "#############",
                    "#...........#",
                    "#...........#",
                    "#...........#",
                    "#...........#",
                    "#............",
                    "#............",
                    "#............",
                    "#############",
                },
                Walls = new[]
                {
                    "             ",
                    " wwwwwwwwwww ",
                    " wwwwwwwwwww ",
                    " wwwwwwwwwww ",
                    " wwwwwwwwwww ",
                    " wwwwwwwwwwww",
                    " wwwwwwwwwwww",
                    " wwwwwwwwwwww",
                    "             ",
                },
            };

            def.TileLegend['#'] = TileID.WoodBlock;
            def.WallLegend['w'] = WallID.Wood;

            // Door in the right-wall gap (rows 5-7, col 12).
            def.Furniture.Add(new Furniture(FurnitureKind.Door, TileID.ClosedDoor, x: 12, y: 6));
            // Light.
            def.Furniture.Add(new Furniture(FurnitureKind.Torch, TileID.Torches, x: 3, y: 2));
            def.Furniture.Add(new Furniture(FurnitureKind.Torch, TileID.Torches, x: 9, y: 2));
            // Flat-surface + comfort items (table + chair), sitting on the floor row.
            def.Furniture.Add(new Furniture(FurnitureKind.Object, TileID.Tables, x: 3, y: 7));
            def.Furniture.Add(new Furniture(FurnitureKind.Object, TileID.Chairs, x: 7, y: 7));

            return def;
        }
    }
}
