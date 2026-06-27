using InstantEstates.Content.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace InstantEstates.Common
{
    /// <summary>
    /// Debug helper: type "/architect" in chat to spawn the Architect right next to
    /// you, skipping the normal town-NPC housing flow. Handy for testing.
    /// </summary>
    public class SpawnArchitectCommand : ModCommand
    {
        public override CommandType Type => CommandType.Chat;
        public override string Command => "architect";
        public override string Usage => "/architect";
        public override string Description => "Spawn the Architect at your position (debug).";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Player player = caller.Player;
            int type = ModContent.NPCType<Architect>();

            NPC.NewNPC(
                player.GetSource_Misc("InstantEstatesDebugCommand"),
                (int)player.Center.X,
                (int)player.Center.Y - 64,
                type);

            caller.Reply("Architect spawned.");
        }
    }
}
