using InstantEstates.Common;
using InstantEstates.Common.Building;
using InstantEstates.Content.Buildings;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InstantEstates.Content.Items
{
    /// <summary>
    /// The placeable "deed". Using it clears the building's footprint at the cursor
    /// and stamps the building. Other deeds can subclass and override <see cref="Building"/>.
    /// </summary>
    public class EstateDeed : ModItem
    {
        /// <summary>The building this deed places. Override for other deed variants.</summary>
        public virtual BuildingDef Building => DynastyCottage.Def;

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useTurn = true;
            Item.autoReuse = false;
            Item.consumable = false; // becomes true once balanced (Phase 6)
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 5);
            Item.UseSound = SoundID.Item4;
        }

        public override bool? UseItem(Player player)
        {
            // Only the owning client decides where to build; the action self-syncs.
            if (player.whoAmI != Main.myPlayer)
                return true;

            BuildAction.ClearAndBuild(Building, Player.tileTargetX, Player.tileTargetY);
            return true;
        }
    }
}
