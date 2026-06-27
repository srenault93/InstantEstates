using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InstantEstates.Common
{
    /// <summary>
    /// Dev convenience: lets you craft StructureHelper's capture wands from a single
    /// dirt block, so you can save your own houses without a cheat mod.
    /// Uses a weak (string) reference - no hard dependency needed to compile.
    /// Remove (or gate) before a public release.
    /// </summary>
    public class DevTools : ModSystem
    {
        public override void PostAddRecipes()
        {
            if (!ModLoader.TryGetMod("StructureHelper", out Mod sh))
                return;

            AddDirtRecipe(sh, "StructureWand");         // select corners + save
            AddDirtRecipe(sh, "TestWand");              // place/preview a saved structure
            AddDirtRecipe(sh, "NullBlockItem");         // Passthrough Block - ignored on placement
            AddDirtRecipe(sh, "NullWallItem");          // Passthrough Wall - ignored on placement
            AddDirtRecipe(sh, "NullTileAndWallPlacer"); // places both passthrough block + wall at once
        }

        private static void AddDirtRecipe(Mod sh, string itemName)
        {
            if (sh.TryFind<ModItem>(itemName, out ModItem item))
            {
                Recipe.Create(item.Type)
                    .AddIngredient(ItemID.DirtBlock, 1)
                    .Register();
            }
        }
    }
}
