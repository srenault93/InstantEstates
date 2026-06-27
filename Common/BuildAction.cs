using InstantEstates.Common.Building;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace InstantEstates.Common
{
    /// <summary>
    /// Clears a building's footprint of soft terrain (sparing anything tougher than
    /// Ebonstone/Crimstone) and then stamps the building into place.
    /// </summary>
    public static class BuildAction
    {
        public static void ClearAndBuild(BuildingDef def, int cursorX, int cursorY)
        {
            Rectangle fp = BuildingPlacer.GetFootprint(def, cursorX, cursorY);

            ClearRect(fp);
            BuildingPlacer.Place(def, fp);

            // In multiplayer, push the changed region to everyone. (Refined in Phase 5.)
            if (Main.netMode != NetmodeID.SinglePlayer)
                NetMessage.SendTileSquare(-1, fp.X, fp.Y, fp.Width, fp.Height);
        }

        /// <summary>Clears blocks and walls in a tile rectangle, sparing protected tiles.</summary>
        public static void ClearRect(Rectangle fp)
        {
            for (int x = fp.Left; x < fp.Right; x++)
            {
                for (int y = fp.Top; y < fp.Bottom; y++)
                {
                    if (!WorldGen.InWorld(x, y, 10))
                        continue;

                    Tile tile = Main.tile[x, y];
                    if (tile.HasTile && BlockToughness.IsProtected(tile.TileType))
                        continue;

                    WorldGen.KillTile(x, y, noItem: true);

                    if (tile.WallType != WallID.None)
                        WorldGen.KillWall(x, y, fail: false);
                }
            }
        }
    }
}
