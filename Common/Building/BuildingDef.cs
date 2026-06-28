using System.Collections.Generic;
using Terraria.ID;

namespace InstantEstates.Common.Building
{
    public enum FurnitureKind { Object, Door, Torch }

    /// <summary>
    /// A furniture placement. If <see cref="ItemId"/> is set, the tile type and style
    /// are resolved from that item at placement time (so themed sets like Dynasty
    /// furniture place correctly without hard-coding style numbers).
    /// </summary>
    public struct Furniture
    {
        public FurnitureKind Kind;
        public ushort Type;  // direct tile type (when ItemId == 0)
        public int Style;    // direct style (when ItemId == 0)
        public int ItemId;   // resolve tile+style from this item if > 0
        public int X, Y;     // relative to building origin

        public static Furniture Object(int itemId, int x, int y)
            => new Furniture { Kind = FurnitureKind.Object, ItemId = itemId, X = x, Y = y };
        public static Furniture Door(int x, int y, int itemId = 0)
            => new Furniture { Kind = FurnitureKind.Door, ItemId = itemId, X = x, Y = y };
        public static Furniture Torch(int x, int y, ushort type = TileID.Torches, int style = 0)
            => new Furniture { Kind = FurnitureKind.Torch, Type = type, Style = style, X = x, Y = y };
    }

    /// <summary>
    /// A data-defined building: foreground tile layer + background wall layer (char
    /// grids resolved via legends) plus a furniture list.
    /// </summary>
    public class BuildingDef
    {
        public string[] Tiles;
        public string[] Walls;

        public Dictionary<char, ushort> TileLegend = new();    // char -> block TileID
        public Dictionary<char, int> PlatformLegend = new();   // char -> platform ITEM id (resolved to tile+style)
        public Dictionary<char, ushort> WallLegend = new();    // char -> WallID
        public Dictionary<char, SlopeType> SlopeLegend = new();// char -> block slope

        public List<Furniture> Furniture = new();

        public int Height => Tiles == null ? 0 : Tiles.Length;
        public int Width => (Tiles == null || Tiles.Length == 0) ? 0 : Tiles[0].Length;
    }
}
