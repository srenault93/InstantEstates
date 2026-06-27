using InstantEstates.Common.Building;
using InstantEstates.Content.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace InstantEstates.Common
{
    /// <summary>
    /// Draws a translucent outline of the plot footprint at the cursor while the
    /// player is holding the Estate Deed, so they can aim before placing.
    /// </summary>
    public class PlacementPreview : ModSystem
    {
        private static readonly Color FillColor = Color.Cyan * 0.12f;
        private static readonly Color BorderColor = Color.Cyan * 0.9f;
        private const int BorderThickness = 2;

        public override void PostDrawTiles()
        {
            Player player = Main.LocalPlayer;
            if (player is null || !player.active || player.dead)
                return;

            // Only while holding a deed, and not when staring at the fullscreen map.
            if (player.HeldItem?.ModItem is not BuildingDeed deed || Main.mapFullscreen)
                return;

            BuildingDef def = deed.Building;
            if (def == null || def.Width == 0)
                return;

            Rectangle plot = BuildingPlacer.GetFootprint(def, Player.tileTargetX, Player.tileTargetY);

            // Tile coords -> screen-space pixels (zoom is applied via the matrix below).
            Rectangle screenRect = new(
                (int)(plot.X * 16 - Main.screenPosition.X),
                (int)(plot.Y * 16 - Main.screenPosition.Y),
                plot.Width * 16,
                plot.Height * 16);

            SpriteBatch sb = Main.spriteBatch;
            sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp,
                DepthStencilState.None, RasterizerState.CullCounterClockwise, null,
                Main.GameViewMatrix.TransformationMatrix);

            Texture2D pixel = TextureAssets.MagicPixel.Value;
            sb.Draw(pixel, screenRect, FillColor);
            DrawBorder(sb, pixel, screenRect, BorderColor, BorderThickness);

            sb.End();
        }

        private static void DrawBorder(SpriteBatch sb, Texture2D pixel, Rectangle r, Color color, int t)
        {
            sb.Draw(pixel, new Rectangle(r.X, r.Y, r.Width, t), color);              // top
            sb.Draw(pixel, new Rectangle(r.X, r.Bottom - t, r.Width, t), color);     // bottom
            sb.Draw(pixel, new Rectangle(r.X, r.Y, t, r.Height), color);             // left
            sb.Draw(pixel, new Rectangle(r.Right - t, r.Y, t, r.Height), color);     // right
        }
    }
}
