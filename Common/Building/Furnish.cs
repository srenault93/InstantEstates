using Terraria.ID;

namespace InstantEstates.Common.Building
{
    /// <summary>Helpers to drop the standard "makes a room livable" furniture set.</summary>
    public static class Furnish
    {
        /// <summary>Adds a door, two torches, a table and a chair to satisfy housing.</summary>
        public static void LivableRoom(BuildingDef def, int doorX, int floorY,
            int torchLX, int torchRX, int tableX, int chairX)
        {
            def.Furniture.Add(new Furniture(FurnitureKind.Door, TileID.ClosedDoor, doorX, floorY - 2));
            def.Furniture.Add(new Furniture(FurnitureKind.Torch, TileID.Torches, torchLX, floorY - 2));
            def.Furniture.Add(new Furniture(FurnitureKind.Torch, TileID.Torches, torchRX, floorY - 2));
            def.Furniture.Add(new Furniture(FurnitureKind.Object, TileID.Tables, tableX, floorY - 1));
            def.Furniture.Add(new Furniture(FurnitureKind.Object, TileID.Chairs, chairX, floorY - 1));
        }

        public static void Light(BuildingDef def, int x, int y)
            => def.Furniture.Add(new Furniture(FurnitureKind.Torch, TileID.Torches, x, y));
    }
}
