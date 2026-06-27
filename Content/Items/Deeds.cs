using InstantEstates.Common;
using InstantEstates.Common.Building;
using InstantEstates.Content.Buildings;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InstantEstates.Content.Items
{
    /// <summary>
    /// Base for all "deed" items: use it to clear a footprint and stamp a building.
    /// Each concrete deed just names which building it places. Priced at 1 copper.
    /// </summary>
    public abstract class BuildingDeed : ModItem
    {
        public abstract BuildingDef Building { get; }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useTurn = true;
            Item.autoReuse = false;
            Item.consumable = false;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(copper: 1);
            Item.UseSound = SoundID.Item4;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI != Main.myPlayer)
                return true;

            BuildAction.ClearAndBuild(Building, Player.tileTargetX, Player.tileTargetY);
            return true;
        }
    }

    public class DynastyCottageDeed : BuildingDeed { public override BuildingDef Building => DynastyCottage.Def; }
    public class DynastyManorDeed : BuildingDeed { public override BuildingDef Building => DynastyManor.Def; }
    public class GrandPagodaDeed : BuildingDeed { public override BuildingDef Building => GrandPagoda.Def; }
    public class PagodaTowerDeed : BuildingDeed { public override BuildingDef Building => PagodaTower.Def; }
    public class PagodaPalaceDeed : BuildingDeed { public override BuildingDef Building => PagodaPalace.Def; }
    public class ToriiGateDeed : BuildingDeed { public override BuildingDef Building => ToriiGate.Def; }
    public class OutpostBaseDeed : BuildingDeed { public override BuildingDef Building => OutpostBase.Def; }
}
