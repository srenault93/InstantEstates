using InstantEstates.Content.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InstantEstates.Content.Items
{
    /// <summary>
    /// A cheap summon item: craft from 1 wood, use it to drop the Architect right
    /// there - no house or housing lottery required.
    /// </summary>
    public class ArchitectSpawner : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useTurn = true;
            Item.consumable = true;
            Item.maxStack = Item.CommonMaxStack;
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item37; // crafting/poof-ish sound
        }

        public override bool? UseItem(Player player)
        {
            // NPC spawning must happen on the server (or in singleplayer).
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.NewNPC(
                    player.GetSource_ItemUse(Item),
                    (int)player.Center.X,
                    (int)player.Center.Y - 64,
                    ModContent.NPCType<Architect>());
            }

            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 1)
                .Register();
        }
    }
}
