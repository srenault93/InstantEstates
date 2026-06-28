using Terraria.ID;

namespace InstantEstates.Common.Building
{
    /// <summary>Helpers to drop a "makes a room livable" furniture set.</summary>
    public static class Furnish
    {
        /// <summary>
        /// Japanese/Dynasty themed room: a door on BOTH sides, a Dynasty lamp in each
        /// bottom corner, and a Dynasty bookcase + table + chair grouped at centre.
        /// </summary>
        public static void DynastyRoom(BuildingDef def, int leftDoorX, int rightDoorX,
            int floorY, int leftInner, int rightInner)
        {
            def.Furniture.Add(Furniture.Door(leftDoorX, floorY - 2, ItemID.DynastyDoor));
            def.Furniture.Add(Furniture.Door(rightDoorX, floorY - 2, ItemID.DynastyDoor));

            def.Furniture.Add(Furniture.Object(ItemID.DynastyLamp, leftInner, floorY - 1));   // corner light
            def.Furniture.Add(Furniture.Object(ItemID.DynastyLamp, rightInner, floorY - 1));  // corner light

            int c = (leftInner + rightInner) / 2;
            def.Furniture.Add(Furniture.Object(ItemID.DynastyBookcase, c - 6, floorY - 1));
            def.Furniture.Add(Furniture.Object(ItemID.DynastyTable, c - 2, floorY - 1));
            def.Furniture.Add(Furniture.Object(ItemID.DynastyChair, c + 1, floorY - 1));
        }

        /// <summary>Plain wooden room: doors both sides, corner torches, work bench + chair.</summary>
        public static void WoodRoom(BuildingDef def, int leftDoorX, int rightDoorX,
            int floorY, int leftInner, int rightInner)
        {
            def.Furniture.Add(Furniture.Door(leftDoorX, floorY - 2));
            def.Furniture.Add(Furniture.Door(rightDoorX, floorY - 2));
            def.Furniture.Add(Furniture.Torch(leftInner, floorY - 2));
            def.Furniture.Add(Furniture.Torch(rightInner, floorY - 2));

            int c = (leftInner + rightInner) / 2;
            def.Furniture.Add(Furniture.Object(ItemID.WorkBench, c - 2, floorY - 1));
            def.Furniture.Add(Furniture.Object(ItemID.WoodenChair, c + 1, floorY - 1));
        }

        public static void Lamp(BuildingDef def, int x, int y) => def.Furniture.Add(Furniture.Object(ItemID.DynastyLamp, x, y));
        public static void Light(BuildingDef def, int x, int y) => def.Furniture.Add(Furniture.Torch(x, y));
    }
}
