# Instant Estates

A [tModLoader](https://github.com/tModLoader/tModLoader) mod for Terraria that adds **magic deeds** which instantly clear a plot of land and raise a prebuilt, livable base.

## Features
- **Estate Deed** — clears a building-sized plot (blocks *and* background walls) and stamps a prebuilt structure. Terrain softer than Ebonstone/Crimstone (under 65% pickaxe power) is removed; tougher tiles (dungeon, ores, lihzahrd, etc.) are left intact.
- **Placement preview** — a live outline at the cursor shows the exact footprint before you place.
- **The Architect** — a town NPC who sells the deeds. Also craftable spawner + `/architect` debug command.
- **Code-defined buildings** — structures are authored as data (`BuildingDef`): two char-grid layers (walls + blocks) plus a furniture list, stamped by a placer that handles framing, doors, and multi-tile objects.

## Status
Early development. The build pipeline, terrain clearing, vendor NPC, placement preview, and the building engine (with a starter cottage) are in and working in-game.

## Building from source
Requires the .NET 8 SDK and tModLoader. Place this folder in your tModLoader `ModSources` directory and build via tModLoader's "Develop Mods" menu, or `dotnet build`.
