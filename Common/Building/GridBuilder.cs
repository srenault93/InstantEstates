namespace InstantEstates.Common.Building
{
    /// <summary>
    /// Mutable two-layer (foreground tiles + background walls) character grid with
    /// drawing primitives, so larger buildings can be composed in code instead of by
    /// hand-typing huge ASCII blocks. Convert to a BuildingDef via Tiles()/Walls().
    /// Origin (0,0) is top-left; the same coordinate space the placer/furniture use.
    /// </summary>
    public class GridBuilder
    {
        public readonly int Width, Height;
        private readonly char[][] _tiles;
        private readonly char[][] _walls;

        public GridBuilder(int width, int height)
        {
            Width = width;
            Height = height;
            _tiles = NewGrid();
            _walls = NewGrid();
        }

        private char[][] NewGrid()
        {
            var g = new char[Height][];
            for (int y = 0; y < Height; y++)
            {
                g[y] = new char[Width];
                for (int x = 0; x < Width; x++)
                    g[y][x] = ' ';
            }
            return g;
        }

        private static bool In(char[][] g, int x, int y) => y >= 0 && y < g.Length && x >= 0 && x < g[0].Length;

        public void T(int x, int y, char c) { if (In(_tiles, x, y)) _tiles[y][x] = c; }
        public void W(int x, int y, char c) { if (In(_walls, x, y)) _walls[y][x] = c; }

        public void HLine(int x0, int x1, int y, char c) { for (int x = x0; x <= x1; x++) T(x, y, c); }
        public void VLine(int x, int y0, int y1, char c) { for (int y = y0; y <= y1; y++) T(x, y, c); }

        public void FillTiles(int x0, int y0, int x1, int y1, char c)
        { for (int y = y0; y <= y1; y++) for (int x = x0; x <= x1; x++) T(x, y, c); }

        public void FillWalls(int x0, int y0, int x1, int y1, char c)
        { for (int y = y0; y <= y1; y++) for (int x = x0; x <= x1; x++) W(x, y, c); }

        public void Box(int x0, int y0, int x1, int y1, char c)
        {
            HLine(x0, x1, y0, c);
            HLine(x0, x1, y1, c);
            VLine(x0, y0, y1, c);
            VLine(x1, y0, y1, c);
        }

        /// <summary>A stepped, narrowing roof of <paramref name="rows"/> rows whose widest
        /// (eave) row is at <paramref name="baseY"/>, centered on <paramref name="cx"/>.</summary>
        public void Roof(int cx, int baseY, int halfWidth, int rows, char c)
        {
            for (int r = 0; r < rows; r++)
            {
                int hw = halfWidth - r;
                if (hw < 0) break;
                HLine(cx - hw, cx + hw, baseY - r, c);
            }
        }

        /// <summary>Draws one pagoda tier (a walled room + a roof above it) and returns the
        /// room's top row so callers can stack the next tier on top.</summary>
        public int Tier(int cx, int floorY, int halfWidth, int roomHeight, int roofRows,
                        char roof, char frame, char wall)
        {
            int top = floorY - roomHeight + 1;
            int left = cx - halfWidth, right = cx + halfWidth;

            FillWalls(left, top, right, floorY - 1, wall); // interior backing
            Box(left, top, right, floorY, frame);          // frame
            Roof(cx, top - 1, halfWidth + 1, roofRows, roof); // eaves overhang by 1
            return top;
        }

        /// <summary>
        /// One pagoda tier: a fully walled room with a WIDE overhanging roof at its
        /// ceiling (eaves project past the side walls). Returns the floor row for the
        /// next, narrower tier to stack on top.
        /// </summary>
        public int PagodaTier(int cx, int floorY, int roomHalf, int roomHeight, int roofHalf,
                              char roof, char frame, char wall)
        {
            int top = floorY - roomHeight + 1;
            int left = cx - roomHalf, right = cx + roomHalf;

            FillWalls(left, top, right, floorY, wall); // interior backing
            VLine(left, top, floorY, frame);           // left wall
            VLine(right, top, floorY, frame);          // right wall
            HLine(left, right, floorY, frame);         // floor

            int ey = top - 1;
            HLine(cx - roofHalf, cx + roofHalf, ey, roof);             // wide eave (overhang)
            HLine(cx - roofHalf + 1, cx + roofHalf - 1, ey - 1, roof); // upper roof row
            return ey - 1; // next tier's floor rests on the upper roof row
        }

        /// <summary>A pointed roof cap with a short finial, for the top of a pagoda.</summary>
        public void RoofCap(int cx, int baseY, int half, char roof, char finial)
        {
            Roof(cx, baseY, half, half + 1, roof);
            int apexY = baseY - half;
            T(cx, apexY - 1, finial);
            T(cx, apexY - 2, finial);
        }

        /// <summary>Carves a 3-tall door opening sitting on the given floor row, at column x.</summary>
        public void DoorGap(int x, int floorY)
        {
            T(x, floorY - 1, ' ');
            T(x, floorY - 2, ' ');
            T(x, floorY - 3, ' ');
        }

        public string[] Tiles() => ToStrings(_tiles);
        public string[] Walls() => ToStrings(_walls);

        private static string[] ToStrings(char[][] g)
        {
            var s = new string[g.Length];
            for (int y = 0; y < g.Length; y++)
                s[y] = new string(g[y]);
            return s;
        }
    }
}
