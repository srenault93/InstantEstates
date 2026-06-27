using System.Collections.Generic;
using Terraria.ID;

namespace InstantEstates.Common.Building
{
    /// <summary>How a piece of furniture is placed (different vanilla calls per kind).</summary>
    public enum FurnitureKind
    {
        Object, // generic multitile: table, chair, chest, workbench, bookcase...
        Door,   // 1x3 door
        Torch,  // light source
    }

    /// <summary>A single furniture placement, positioned relative to the building's top-left.</summary>
    public struct Furniture
    {
        public ushort Type;        // TileID
        public int Style;          // object style (e.g. wood = 0)
        public int X;              // column relative to building origin
        public int Y;              // row relative to building origin (anchor cell)
        public FurnitureKind Kind;

        public Furniture(FurnitureKind kind, ushort type, int x, int y, int style = 0)
        {
            Kind = kind; Type = type; X = x; Y = y; Style = style;
        }
    }

    /// <summary>
    /// A data-defined building. Two char-grid layers (background walls + foreground
    /// blocks/platforms) plus a list of multitile furniture. Symbols are resolved via
    /// the legends. A blank/space char means "nothing" in that layer.
    /// </summary>
    public class BuildingDef
    {
        public string[] Tiles;   // foreground: blocks & platforms
        public string[] Walls;   // background walls (optional, same dimensions)

        public Dictionary<char, ushort> TileLegend = new();   // char -> block TileID
        public Dictionary<char, int> PlatformLegend = new();  // char -> platform style (placed as TileID.Platforms)
        public Dictionary<char, ushort> WallLegend = new();   // char -> WallID
        public Dictionary<char, SlopeType> SlopeLegend = new(); // char -> slope applied to that block (roof edges, etc.)

        public List<Furniture> Furniture = new();

        public int Height => Tiles == null ? 0 : Tiles.Length;
        public int Width => (Tiles == null || Tiles.Length == 0) ? 0 : Tiles[0].Length;
    }
}
