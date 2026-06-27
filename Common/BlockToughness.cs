using System.Collections.Generic;
using Terraria.ID;

namespace InstantEstates.Common
{
    /// <summary>
    /// Decides which tiles survive the magic clear. The rule of the mod is
    /// "destroy everything softer than Ebonstone/Crimstone" (which require 65%
    /// pickaxe power). Terraria has no public per-tile pickaxe-power table, so we
    /// keep a curated set of tiles that are at least that tough and preserve them.
    /// Add/remove TileIDs here to tune the behavior.
    /// </summary>
    public static class BlockToughness
    {
        private static readonly HashSet<int> Protected = new()
        {
            // The reference tier: 65% pickaxe power.
            TileID.Ebonstone,
            TileID.Crimstone,
            TileID.Demonite,   // Demonite ore
            TileID.Crimtane,   // Crimtane ore
            TileID.Hellstone,

            // Dungeon (65%+).
            TileID.BlueDungeonBrick,
            TileID.GreenDungeonBrick,
            TileID.PinkDungeonBrick,

            // Jungle temple (210%).
            TileID.LihzahrdBrick,

            // Hardmode ores (100%+).
            TileID.Cobalt,
            TileID.Palladium,
            TileID.Mythril,
            TileID.Orichalcum,
            TileID.Adamantite,
            TileID.Titanium,
            TileID.Chlorophyte,
        };

        /// <summary>True if the tile is too tough to be cleared by the magic builder.</summary>
        public static bool IsProtected(int tileType) => Protected.Contains(tileType);
    }
}
