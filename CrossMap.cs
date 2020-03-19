using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneratorLibrary.MapStructure
{
    public class CrossMap : Map
    {
        
        int crossSize = 1;
        int crossXOffset = 0;
        int crossYOffset = 0;
        public CrossMap() : base(0)
        {
            GenerateMapSettings();
            crossSize = 2;
            Create();
            
        }

        public CrossMap(MapSettings settings) : base(0)
        {
            GenerateMapSettings();
            crossSize = 2;
            Settings = settings;
            Create();
        }

        protected override void Create()
        {
            base.Create();

            int xStartLocation = ((int)Math.Ceiling((Settings.Width / 2f))-1)+crossXOffset;
            int yStartLocation = ((int)Math.Ceiling((Settings.Height / 2f)) - 1)+crossYOffset;
            int xLow = xStartLocation - (int)Math.Ceiling((crossSize / 2f));
            int xHigh = xStartLocation + (int)Math.Floor((crossSize / 2f));
            int yLow = yStartLocation - (int)Math.Ceiling((crossSize / 2f));
            int yHigh = yStartLocation + (int)Math.Floor((crossSize / 2f));
            
            foreach (Block block in _totalTiles)
            {
                if (block.Location.X > xLow && block.Location.X <= xHigh)
                {
                    if (!AvailableTiles.Contains(block))
                        AvailableTiles.Add(block);
                }
                else
                {
                    if (block.Location.Y > yLow && block.Location.Y <= yHigh)
                    {
                        if (!AvailableTiles.Contains(block))
                            AvailableTiles.Add(block);
                    }
                }
            }

        }
    }
}
