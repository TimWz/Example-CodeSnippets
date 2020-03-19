using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneratorLibrary.MapStructure
{
    static class MapTools
    {
        public static int GetBlockCount(Map map, Block block, BlockType blockType)
        {

            int gridX = block.Location.X;
            int gridY = block.Location.Y;
            int blockCount = 0;
            int mapWidth = map.Settings.Width;
            int mapHeight = map.Settings.Height;
            for (int x = gridX - 1; x <= gridX; x++)
            {
                for (int y = gridY - 1; y <= gridY; y++)
                {
                    if (x >= 0 && x < mapWidth && y >= 0 && y < mapHeight)
                    {
                        if (x != gridX || y != gridY)
                        {
                            if (map.TotalTiles[(mapWidth * y) + x].Type == blockType)
                            {
                                blockCount++;
                            }

                        }
                    }
                }
            }
            return blockCount;
        }

        public static int GetBlockCount(Map map, Block block, BlockType blockType, int range)
        {

            int gridX = block.Location.X;
            int gridY = block.Location.Y;
            int blockCount = 0;
            int mapWidth = map.Settings.Width;
            int mapHeight = map.Settings.Height;
            for (int x = gridX - range; x <= gridX + range; x++)
            {
                for (int y = gridY - range; y <= gridY+range; y++)
                {
                    if (x >= 0 && x < mapWidth && y >= 0 && y < mapHeight)
                    {
                        if (x != gridX || y != gridY)
                        {
                            if (map.TotalTiles[(mapWidth * y) + x].Type == blockType)
                            {
                                blockCount++;
                            }

                        }
                    }
                }
            }
            return blockCount;
        }

        public static int GetBlockPercentage(Map map, BlockType type)
        {
            int blockCount = 0;
            foreach (Block b in map.AvailableTiles)
            {
                if (b.Type == type)
                    blockCount++;
            }

            return blockCount / (map.Settings.Size/100);
        }
    }
}
