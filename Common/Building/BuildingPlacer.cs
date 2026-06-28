using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace InstantEstates.Common.Building
{
    /// <summary>
    /// Stamps a <see cref="BuildingDef"/> into the world: walls, blocks, platforms,
    /// furniture, then a framing pass so everything draws correctly.
    /// </summary>
    public static class BuildingPlacer
    {
        /// <summary>Cursor maps to the bottom-center of the building footprint.</summary>
        public static Rectangle GetFootprint(BuildingDef def, int cursorX, int cursorY)
        {
            int left = cursorX - def.Width / 2;
            int top = cursorY - (def.Height - 1);
            return new Rectangle(left, top, def.Width, def.Height);
        }

        public static void Place(BuildingDef def, Rectangle fp)
        {
            PlaceWalls(def, fp);
            PlaceTilesAndPlatforms(def, fp);
            PlaceFurniture(def, fp);
            ReframeRegion(fp);
        }

        private static void PlaceWalls(BuildingDef def, Rectangle fp)
        {
            if (def.Walls == null) return;
            for (int row = 0; row < def.Height && row < def.Walls.Length; row++)
            {
                string line = def.Walls[row];
                for (int col = 0; col < def.Width && col < line.Length; col++)
                {
                    if (def.WallLegend.TryGetValue(line[col], out ushort wallType))
                    {
                        Tile t = Main.tile[fp.X + col, fp.Y + row];
                        t.WallType = wallType;
                    }
                }
            }
        }

        private static void PlaceTilesAndPlatforms(BuildingDef def, Rectangle fp)
        {
            for (int row = 0; row < def.Height; row++)
            {
                string line = def.Tiles[row];
                for (int col = 0; col < def.Width && col < line.Length; col++)
                {
                    char c = line[col];
                    int wx = fp.X + col, wy = fp.Y + row;

                    if (def.PlatformLegend.TryGetValue(c, out int platformItem))
                    {
                        Item s = ContentSamples.ItemsByType[platformItem];
                        WorldGen.PlaceTile(wx, wy, s.createTile, mute: true, forced: true, style: s.placeStyle);
                        continue;
                    }

                    if (def.TileLegend.TryGetValue(c, out ushort tileType))
                    {
                        Tile t = Main.tile[wx, wy];
                        t.HasTile = true;
                        t.TileType = tileType;
                        t.IsHalfBlock = false;
                        t.Slope = def.SlopeLegend.TryGetValue(c, out SlopeType slope) ? slope : SlopeType.Solid;
                    }
                }
            }
        }

        private static void PlaceFurniture(BuildingDef def, Rectangle fp)
        {
            foreach (Furniture f in def.Furniture)
            {
                int wx = fp.X + f.X, wy = fp.Y + f.Y;
                switch (f.Kind)
                {
                    case FurnitureKind.Door:
                        int doorTile = f.ItemId > 0 ? ContentSamples.ItemsByType[f.ItemId].createTile : TileID.ClosedDoor;
                        WorldGen.PlaceDoor(wx, wy, doorTile);
                        break;

                    case FurnitureKind.Torch:
                        WorldGen.PlaceTile(wx, wy, f.Type, mute: true, forced: true, style: f.Style);
                        break;

                    default:
                        if (f.ItemId > 0)
                        {
                            Item s = ContentSamples.ItemsByType[f.ItemId];
                            WorldGen.PlaceObject(wx, wy, s.createTile, mute: true, style: s.placeStyle);
                        }
                        else
                        {
                            WorldGen.PlaceObject(wx, wy, f.Type, mute: true, style: f.Style);
                        }
                        break;
                }
            }
        }

        private static void ReframeRegion(Rectangle fp)
        {
            for (int x = fp.Left; x < fp.Right; x++)
            {
                for (int y = fp.Top; y < fp.Bottom; y++)
                {
                    WorldGen.SquareTileFrame(x, y, true);
                    Framing.WallFrame(x, y, true);
                }
            }
        }
    }
}
