using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneratorLibrary.MapStructure
{
    public class LinesMap : Map
    {
        int layerCount = 1;
        bool isVertical;
        bool startsEmpty;

        public int LayerCount { get; set; }

        public LinesMap() : base(0)
        {
            GenerateMapSettings();
            layerCount = 2;
            isVertical = false;
            startsEmpty = false;
            
            Create();

        }

        public LinesMap(MapSettings _settings) : base(0)
        {
            GenerateMapSettings();
            Settings = _settings; //MEER 
            layerCount = 2;
            Create();
        }

        public LinesMap(MapSettings _settings, int _layerCount)
        {
            Settings = _settings; //MEER 
            layerCount = 2;
            Create();
        }

        protected override void Create()
        {
            base.Create();
            int layerSize = Settings.Height / (layerCount * 2);
            for (int y = 0; y < Settings.Height; y++)
            {
                for (int x = 0; x < Settings.Width; x++)
                {

                }
            }
            if (!isVertical)
            {

                foreach (Block block in TotalTiles)
                {
                    for (int i = 0; i < layerCount; i++)
                    {
                        if (startsEmpty)
                        {
                            if (block.Location.Y >= (i * (2 * layerSize))+layerSize && block.Location.Y < ((i * (2 * layerSize)) + layerSize)+layerSize)
                            {
                                AvailableTiles.Add(block);
                            }
                        }
                        else
                        {
                            if (block.Location.Y >= i * (2 * layerSize) && block.Location.Y < (i * (2 * layerSize)) + layerSize)
                            {
                                AvailableTiles.Add(block);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Block block in TotalTiles)
                {
                    for (int i = 0; i < layerCount; i++)
                    {
                        if (startsEmpty)
                        {
                            if (block.Location.X >= (i * (2 * layerSize)) + layerSize && block.Location.X < ((i * (2 * layerSize)) + layerSize) + layerSize)
                            {
                                AvailableTiles.Add(block);
                            }
                        }
                        else
                        {
                            if (block.Location.X >= i * (2 * layerSize) && block.Location.X < (i * (2 * layerSize)) + layerSize)
                            {
                                AvailableTiles.Add(block);
                            }
                        }
                    }
                }
            }

        }
    }
}
