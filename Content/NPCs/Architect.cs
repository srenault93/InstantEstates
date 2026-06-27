using System.Collections.Generic;
using InstantEstates.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace InstantEstates.Content.NPCs
{
    /// <summary>
    /// The Architect: a town NPC who moves into a vacant house and sells Estate Deeds.
    /// Uses the Guide's walk animation; art is placeholder for now.
    /// </summary>
    [AutoloadHead]
    public class Architect : ModNPC
    {
        public const string ShopName = "Shop";

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 25; // matches the Guide-style spritesheet layout

            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.AttackFrameCount[Type] = 4;
            NPCID.Sets.DangerDetectRange[Type] = 700;
            NPCID.Sets.AttackType[Type] = 0;
            NPCID.Sets.AttackTime[Type] = 90;
            NPCID.Sets.AttackAverageChance[Type] = 30;
            NPCID.Sets.HatOffsetY[Type] = 4;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = NPCAIStyleID.Passive;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;
        }

        // Allowed to move in as soon as there is a vacant house. (Tighten later if desired.)
        public override bool CanTownNPCSpawn(int numTownNPCs) => true;

        public override List<string> SetNPCNameList() => new() { "Vera", "Magnus", "Drystan", "Soraya" };

        public override string GetChat()
        {
            return Main.rand.Next(3) switch
            {
                0 => "Tell me where, and I'll raise you a home before you can blink.",
                1 => "Soft ground, hard ground - my magic only clears what a pickaxe could anyway.",
                _ => "An estate deed in hand is a house in the making.",
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28"); // "Shop"
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
                shopName = ShopName;
        }

        public override void AddShops()
        {
            new NPCShop(Type, ShopName)
                .Add<DynastyCottageDeed>()
                .Add<DynastyManorDeed>()
                .Add<GrandPagodaDeed>()
                .Add<PagodaTowerDeed>()
                .Add<PagodaPalaceDeed>()
                .Add<ToriiGateDeed>()
                .Add<OutpostBaseDeed>()
                .Register();
        }
    }
}
