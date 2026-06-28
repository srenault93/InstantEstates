using InstantEstates.Common.Building;
using Terraria.ID;

namespace InstantEstates.Content.Buildings
{
    /// <summary>Screenshot 151939: a torii gate over a deck, with a small enclosed shrine room. Approximation.</summary>
    public static class ToriiGate
    {
        public static readonly BuildingDef Def = Build();

        private static BuildingDef Build()
        {
            const int cx = 11;
            var g = new GridBuilder(23, 16);

            // Gate posts + crossbeams + deck.
            g.VLine(4, 4, 14, 'D');
            g.VLine(18, 4, 14, 'D');
            g.HLine(2, 20, 4, 'R');
            g.HLine(3, 19, 5, 'D');
            g.HLine(1, 21, 14, 'D');

            // Small shrine room on the deck.
            g.Box(7, 8, 15, 14, 'D');
            g.FillWalls(8, 9, 14, 13, 'w');
            g.Roof(cx, 7, 5, 2, 'R');
            g.DoorGap(7, 14); g.DoorGap(15, 14);

            var def = new BuildingDef { Tiles = g.Tiles(), Walls = g.Walls() };
            def.TileLegend['D'] = TileID.DynastyWood;
            def.TileLegend['R'] = TileID.RedDynastyShingles;
            def.WallLegend['w'] = WallID.WhiteDynasty;

            Furnish.DynastyRoom(def, leftDoorX: 7, rightDoorX: 15, floorY: 14, leftInner: 8, rightInner: 14);
            return def;
        }
    }
}
