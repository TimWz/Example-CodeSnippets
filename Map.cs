using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapGeneratorLibrary.MapStructure;
using MapGeneratorLibrary.Extensions;

namespace MapGeneratorLibrary
{
    public class Map
    {
        public List<BlockType> layer1 = new List<BlockType>();
        public List<BlockType> layerRoads = new List<BlockType>();
        public List<BlockType> layer2 = new List<BlockType>();
        public List<BlockType> layer2b = new List<BlockType>();
        public List<BlockType> layer3 = new List<BlockType>();
        public List<BlockType> layer4 = new List<BlockType>();

        MapSettings _settings;
        public MapSettings Settings
        {
            get
            {
                return _settings;
            }
            protected set
            {
                _settings = value;
            }
        }

        public List<Block> _totalTiles = new List<Block>(); //PUBLIC FIELDS NIET TOELATEN
        public List<Block> _availableTiles = new List<Block>();

        public List<Block> TotalTiles
        {
            get
            {
                return _totalTiles;
            }
        }
        public List<Block> AvailableTiles
        {
            get
            {
                return _availableTiles;
            }

        }



        #region constructors
        public Map()
        {
            GenerateMapSettings();
            Create();
            _availableTiles = TotalTiles;

        }

        public Map(MapSettings settings)
        {
            _settings = settings;

            Create();
            _availableTiles = TotalTiles;
        }

        public Map(int redirect)
        {

        }

        #endregion
        protected virtual void Create()
        {

            for (int y = 0; y < Settings.Height; y++)
            {
                for (int x = 0; x < Settings.Width; x++)
                {
                    Block block = new Block(x, y);
                    this.TotalTiles.Add(block);

                }
            }

        }


        public void Populate()
        {
            float mapSizeModifier = Settings.Size / 100f;
            string test;
            List<Block> filledBlockList = this.AvailableTiles;
            //TODO: Werken in "Layers", Layer 1 = Grond, Layer 2 = Water in clusters, Layer 3 = ?

            Random mapRandomizer = new Random();

            #region Map Generation in layers
            #region Layer 1: Ground
            //Layer 1: Grond overal || Verwerkt in de constructor v/d blocks
            foreach (Block block in filledBlockList)
            {
                block.Type = BlockType.Grass;
                //layer1.Add(block.Type);
            }
            foreach (Block b in this.TotalTiles)
                layer1.Add(b.Type);

            //this.layer1Blocks = new List<Block>(filledBlockList.Count);

            //filledBlockList.ForEach((item) =>
            //{
            //    this.layer1Blocks.Add((Block)item.Clone());
            //});

            #endregion

            //Disabled
            #region Layer 4: Roads in kruis
            //if (this.GetType() == typeof(CrossMap))
            //{

            //    List<Block> roadExitsWest = new List<Block>();
            //    List<Block> roadExitsNorth = new List<Block>();
            //    List<Block> roadExitsEast = new List<Block>();
            //    List<Block> roadExitsSouth = new List<Block>();

            //    foreach (Block block in filledBlockList)
            //    {
            //        if (block.Location.X == 0 && block.Type != BlockType.Empty)
            //            roadExitsWest.Add(block);
            //        else
            //        {
            //            if (block.Location.Y == 0 && block.Type != BlockType.Empty)
            //                roadExitsNorth.Add(block);
            //            else
            //            {
            //                if (block.Location.X == this.Settings.Width - 1 && block.Type != BlockType.Empty)
            //                    roadExitsEast.Add(block);
            //                else
            //                {
            //                    if (block.Location.Y == this.Settings.Height - 1 && block.Type != BlockType.Empty)
            //                        roadExitsSouth.Add(block);
            //                }
            //            }
            //        }
            //    }
            //    Block startWest, exitNorth, exitEast, exitSouth;
            //    startWest = TotalTiles[((int)Math.Ceiling(this.Settings.Height / 2f) - 1) * this.Settings.Width];
            //    exitNorth = TotalTiles[((int)Math.Ceiling(this.Settings.Width / 2f) - 1)];
            //    exitEast = TotalTiles[(this.Settings.Size / 2) - 1];
            //    exitSouth = TotalTiles[(this.Settings.Size - (this.Settings.Width / 2)) - 1];
            //    //startWest = roadExitsWest[mapRandomizer.Next(0, roadExitsWest.Count - 1)];
            //    //exitNorth = roadExitsNorth[mapRandomizer.Next(0, roadExitsNorth.Count - 1)];
            //    //exitEast = roadExitsEast[mapRandomizer.Next(0, roadExitsEast.Count - 1)];
            //    //exitSouth = roadExitsSouth[mapRandomizer.Next(0, roadExitsSouth.Count - 1)];

            //    Block roadCenter = TotalTiles[(this.Settings.Size / 2) - (this.Settings.Width / 2) - 1];

            //    Block currentRoadBlock = startWest;
            //    Block nextRoadBlock = null;
            //    List<Block> roadBlocks = new List<Block>();
            //    int mySpot = 0;
            //    int nextSpot = 0;
            //    bool roadFinished = false;
            //    int roadMinMod, roadMaxMod;
            //    if (Settings.RoadSize > 1)
            //    {
            //        roadMinMod = (int)Math.Ceiling((Settings.RoadSize - 1) / 2f);
            //        roadMaxMod = (int)Math.Floor((Settings.RoadSize - 1) / 2f);
            //    }
            //    else
            //    {
            //        roadMinMod = 0;
            //        roadMaxMod = 0;
            //    }


            //    while (!roadFinished)
            //    {

            //        if (!roadBlocks.Contains(currentRoadBlock))
            //        {
            //            roadBlocks.Add(currentRoadBlock);
            //            currentRoadBlock.Type = BlockType.Road;
            //        }
            //        mySpot = (currentRoadBlock.Location.X) + (currentRoadBlock.Location.Y * this.Settings.Width);
            //        if (currentRoadBlock == exitEast)
            //        {
            //            for (int r = 1; r <= roadMinMod; r++)
            //                TotalTiles[mySpot - (Settings.Width * r)].Type = BlockType.Road;
            //            for (int r = 1; r <= roadMaxMod; r++)
            //                TotalTiles[mySpot + (Settings.Width * r)].Type = BlockType.Road;
            //            currentRoadBlock = roadCenter;

            //        }
            //        if (currentRoadBlock == exitNorth || currentRoadBlock == exitSouth)
            //        {
            //            for (int r = 1; r <= roadMinMod; r++)
            //                TotalTiles[mySpot - (1 * r)].Type = BlockType.Road;
            //            for (int r = 1; r <= roadMaxMod; r++)
            //                TotalTiles[mySpot + (1 * r)].Type = BlockType.Road;
            //            currentRoadBlock = roadCenter;


            //        }
            //        mySpot = (currentRoadBlock.Location.X) + (currentRoadBlock.Location.Y * this.Settings.Width);

            //        if (!roadBlocks.Contains(roadCenter))
            //        {
            //            for (int r = 1; r <= roadMinMod; r++)
            //                TotalTiles[mySpot - (Settings.Width * r)].Type = BlockType.Road;
            //            for (int r = 1; r <= roadMaxMod; r++)
            //                TotalTiles[mySpot + (Settings.Width * r)].Type = BlockType.Road;
            //            nextSpot = mySpot + 1;
            //            if (nextSpot < this.Settings.Size - 1)
            //                nextRoadBlock = TotalTiles[nextSpot];
            //        }
            //        else
            //        {
            //            if (!roadBlocks.Contains(exitEast))
            //            {
            //                for (int r = 1; r <= roadMinMod; r++)
            //                    TotalTiles[mySpot - (Settings.Width * r)].Type = BlockType.Road;
            //                for (int r = 1; r <= roadMaxMod; r++)
            //                    TotalTiles[mySpot + (Settings.Width * r)].Type = BlockType.Road;
            //                nextSpot = mySpot + 1;
            //                nextRoadBlock = TotalTiles[nextSpot];

            //            }
            //            else
            //            {
            //                if (!roadBlocks.Contains(exitNorth))
            //                {
            //                    for (int r = 1; r <= roadMinMod; r++)
            //                        TotalTiles[mySpot - (1 * r)].Type = BlockType.Road;
            //                    for (int r = 1; r <= roadMaxMod; r++)
            //                        TotalTiles[mySpot + (1 * r)].Type = BlockType.Road;
            //                    if (nextSpot > this.Settings.Width)
            //                        nextSpot = mySpot - this.Settings.Width;
            //                    nextRoadBlock = TotalTiles[nextSpot];


            //                }
            //                else
            //                {
            //                    if (!roadBlocks.Contains(exitSouth))//So
            //                    {
            //                        for (int r = 1; r <= roadMinMod; r++)
            //                            TotalTiles[mySpot - (1 * r)].Type = BlockType.Road;
            //                        for (int r = 1; r <= roadMaxMod; r++)
            //                            TotalTiles[mySpot + (1 * r)].Type = BlockType.Road;
            //                        nextSpot = mySpot + this.Settings.Width;
            //                        nextRoadBlock = TotalTiles[nextSpot];
            //                    }
            //                    else
            //                    {
            //                        roadFinished = true;
            //                    }
            //                }

            //            }

            //        }
            //        currentRoadBlock = nextRoadBlock;


            //    }
            //}

            #endregion

            #region Layer 4.2: Roads met logica
            if (this.GetType() == typeof(Map))
            {
                List<Block> roadList = new List<Block>();
                for (int roadCounter = 0; roadCounter < this.Settings.RoadCount; roadCounter++)
                {
                    int blockIndexer = 0;
                    bool roadFinished = false;

                    while (!roadFinished)
                    {
                        roadList = new List<Block>();
                        int randomizeStartingLocation = 0;
                        int roadStartSide = mapRandomizer.Next(0, 4);
                        //int roadStartSide = 0;
                        Block roadStart = null;
                        bool startLeft = false, startTop = false, startRight = false, startBot = false;
                        switch (roadStartSide)
                        {
                            case 0://Boven
                                randomizeStartingLocation = mapRandomizer.Next(1, this.Settings.Width - 1);

                                startTop = true;
                                blockIndexer = randomizeStartingLocation;
                                roadStart = TotalTiles[blockIndexer];
                                break;
                            case 1://Onder
                                randomizeStartingLocation = mapRandomizer.Next(1, this.Settings.Width - 1);

                                startBot = true;
                                blockIndexer = (this.Settings.Size - this.Settings.Width) + randomizeStartingLocation;
                                roadStart = TotalTiles[blockIndexer];
                                break;
                            case 2://Links
                                randomizeStartingLocation = mapRandomizer.Next(1, this.Settings.Height - 1);

                                startLeft = true;
                                blockIndexer = (randomizeStartingLocation * this.Settings.Width) - this.Settings.Width;
                                roadStart = TotalTiles[blockIndexer];
                                break;
                            case 3://Rechts
                                randomizeStartingLocation = mapRandomizer.Next(1, this.Settings.Height - 1);

                                startRight = true;
                                blockIndexer = (randomizeStartingLocation * this.Settings.Width) - 1;
                                roadStart = TotalTiles[blockIndexer];
                                break;
                        }

                        Block currentBlock = roadStart;
                        Block nextBlock = null;


                        int nextIndexer = 0;
                        bool constructingRoad = true;
                        bool leftStartSide = false;
                        bool leftBlocked = false, rightBlocked = false, downBlocked = false, upBlocked = false;

                        int amountOfTries = 0;


                        while (constructingRoad)
                        {


                            if (currentBlock != roadStart)

                                leftStartSide = true;


                            //if (currentBlock.Type != BlockType.Road)

                            //    currentBlock.Type = BlockType.Road;


                            if (!roadList.Contains(currentBlock))
                                roadList.Add(currentBlock);

                            //Is Rechts
                            if (currentBlock.Location.X == this.Settings.Width - 1 && leftStartSide)
                            {
                                if (roadList.Count < this.Settings.RoadSize)
                                {
                                    constructingRoad = false;
                                    foreach (Block block in roadList)

                                        block.Type = BlockType.Grass;
                                    break;
                                }
                                else
                                {
                                    constructingRoad = false;
                                    roadFinished = true;
                                    break;
                                }
                            }

                            //Is links
                            if (currentBlock.Location.X == 0 && leftStartSide)
                            {
                                if (roadList.Count < this.Settings.RoadSize)
                                {
                                    constructingRoad = false;
                                    foreach (Block block in roadList)

                                        block.Type = BlockType.Grass;
                                    break;
                                }
                                else
                                {
                                    constructingRoad = false;
                                    roadFinished = true;
                                    break;
                                }
                            }
                            //Is Onder
                            if (currentBlock.Location.Y == this.Settings.Height - 1 && leftStartSide)
                            {
                                if (roadList.Count < this.Settings.RoadSize)
                                {
                                    constructingRoad = false;
                                    foreach (Block block in roadList)

                                        block.Type = BlockType.Grass;
                                    break;
                                }
                                else
                                {
                                    constructingRoad = false;
                                    roadFinished = true;
                                    break;
                                }
                            }
                            //Is Boven
                            if (currentBlock.Location.Y == 0 && leftStartSide)
                            {
                                if (roadList.Count < this.Settings.RoadSize)
                                {
                                    constructingRoad = false;
                                    foreach (Block block in roadList)

                                        block.Type = BlockType.Grass;
                                    break;
                                }
                                else
                                {
                                    constructingRoad = false;
                                    roadFinished = true;
                                    break;
                                }
                            }

                            if (leftBlocked && rightBlocked && upBlocked && downBlocked)
                            {
                                foreach (Block block in roadList)

                                    block.Type = BlockType.Grass;
                                constructingRoad = false;
                            }

                            int direction = mapRandomizer.Next(0, 4);

                            //DIRECTIONS
                            switch (direction)
                            {
                                case 0: // naar Rechts
                                    if (blockIndexer > this.Settings.Width)
                                    {
                                        if (currentBlock.Location.Y < this.Settings.Height - 1 && currentBlock.Location.Y > 0)
                                        {
                                            nextIndexer = blockIndexer + 1;
                                            nextBlock = TotalTiles[nextIndexer];
                                            if (!roadList.Contains(nextBlock))
                                            {
                                                if (!roadList.Contains(TotalTiles[nextIndexer - this.Settings.Width]) && !roadList.Contains(TotalTiles[nextIndexer + this.Settings.Width]))
                                                {
                                                    if (!roadList.Contains(TotalTiles[nextIndexer + 1]))
                                                    {
                                                        blockIndexer = nextIndexer;
                                                        currentBlock = nextBlock;
                                                    }
                                                }
                                                else
                                                {
                                                    rightBlocked = true;
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case 1: // Naar Links
                                    if (currentBlock.Location.X > 0)
                                    {
                                        if (currentBlock.Location.Y < this.Settings.Height - 1 && currentBlock.Location.Y > 0)
                                        {
                                            nextIndexer = blockIndexer - 1;
                                            nextBlock = TotalTiles[nextIndexer];
                                            if (!roadList.Contains(nextBlock))
                                            {
                                                if (!roadList.Contains(TotalTiles[nextIndexer - this.Settings.Width]) && !roadList.Contains(TotalTiles[nextIndexer + this.Settings.Width]))
                                                {
                                                    if (!roadList.Contains(TotalTiles[nextIndexer - 1]))
                                                    {



                                                        blockIndexer = nextIndexer;
                                                        currentBlock = nextBlock;

                                                    }
                                                    else
                                                    {
                                                        leftBlocked = true;
                                                    }

                                                }
                                            }
                                        }
                                    }
                                    break;
                                case 2: // Naar onder
                                    if (blockIndexer < this.Settings.Size - this.Settings.Width)
                                    {
                                        if (currentBlock.Location.X != 0 && currentBlock.Location.X != this.Settings.Height - 1)
                                        {
                                            nextIndexer = blockIndexer + this.Settings.Width;
                                            nextBlock = TotalTiles[nextIndexer];
                                            if (!roadList.Contains(nextBlock))
                                            {
                                                if (!roadList.Contains(TotalTiles[nextIndexer - 1]) && !roadList.Contains(TotalTiles[nextIndexer + 1]))
                                                {
                                                    if (TotalTiles[nextIndexer].Location.Y != this.Settings.Height - 1)
                                                    {
                                                        if (nextIndexer + this.Settings.Width < TotalTiles.Count)
                                                            if (!roadList.Contains(TotalTiles[nextIndexer + this.Settings.Width]))
                                                            {
                                                                blockIndexer = nextIndexer;
                                                                currentBlock = nextBlock;
                                                            }
                                                            else
                                                            {
                                                                downBlocked = true;
                                                            }
                                                    }
                                                    else
                                                    {
                                                        //Finished
                                                        blockIndexer = nextIndexer;
                                                        currentBlock = nextBlock;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                                case 3: // Naar Boven
                                    if (blockIndexer > this.Settings.Width)
                                    {
                                        if (currentBlock.Location.X != 0 && currentBlock.Location.X != this.Settings.Height - 1)
                                        {
                                            nextIndexer = blockIndexer - this.Settings.Width;
                                            nextBlock = TotalTiles[nextIndexer];
                                            if (!roadList.Contains(nextBlock))
                                            {
                                                if (!roadList.Contains(TotalTiles[nextIndexer - 1]) && !roadList.Contains(TotalTiles[nextIndexer + 1]))
                                                {
                                                    if (TotalTiles[nextIndexer].Location.Y != 0)
                                                    {
                                                        if (!roadList.Contains(TotalTiles[nextIndexer - this.Settings.Width]))
                                                        {
                                                            blockIndexer = nextIndexer;
                                                            currentBlock = nextBlock;
                                                        }
                                                        else
                                                        {
                                                            upBlocked = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Finished
                                                        blockIndexer = nextIndexer;
                                                        currentBlock = nextBlock;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    break;
                            }
                            amountOfTries++;
                            if (amountOfTries > this.Settings.Size / 2)
                            {
                                //foreach (Block block in roadList)

                                //        block.Type = BlockType.Grass;


                                constructingRoad = false;
                            }

                        }//while const



                    }//while roadfin
                    foreach (Block roadBlock in roadList)
                    {
                        roadBlock.Type = BlockType.Road;
                        roadBlock.WasEdited = true;
                    }
                }//roadcount
            }//mapcheck
            foreach (Block b in this.TotalTiles)
                layerRoads.Add(b.Type);
            #endregion

            #region Layer 2: Random Water
            //Layer 2: Random water op een paar plaatsen
            for (int waterCounter = 0; waterCounter < Settings.WaterClusters; waterCounter++) 

                foreach (Block block in filledBlockList)
                {
                    int waterNeighbours = MapTools.GetBlockCount(this, block, BlockType.Water, this.Settings.Width / 4);
                    if (waterNeighbours == 0)
                    {
                        var randomNo = mapRandomizer.Next(-1, 101);
                        var randomChecker = Math.Ceiling((double)Settings.WaterClusters / Settings.Size);
                        if (randomNo < randomChecker)
                        {
                            if (block.Type != BlockType.Road)
                            {
                                block.Type = BlockType.Water;
                                
                            }

                        }
                    }
                    //layer2.Add(block.Type);
                }


            foreach (Block b in this.TotalTiles)
                layer2.Add(b.Type);


            #endregion
            #region Layer 2.5: Water+
            //Layer 2.5 Controleer map voor water en maak meer water
            var currentPercentage = 0;
            int waterAttempts = 0;
            while (currentPercentage < Settings.WaterDensity)
            {
                if (waterAttempts > 1000*AvailableTiles.Count)
                    break;
                    foreach (Block block in filledBlockList)
                    {
                        if (block.Type != BlockType.Water)
                        {
                            int sameTypeNeighbours = MapTools.GetBlockCount(this, block, BlockType.Water);
                            if (sameTypeNeighbours >= 7)
                            {
                                if (block.Type != BlockType.Road)
                                    block.Type = BlockType.Water;
                            }
                            else
                            {
                                {
                                    if (mapRandomizer.Next(0, 100) < ((Settings.WaterDensity / 7) * (sameTypeNeighbours * 2)))
                                        if (block.Type != BlockType.Road)
                                            block.Type = BlockType.Water;
                                }
                            }

                        }
                    }
                    currentPercentage = MapTools.GetBlockPercentage(this, BlockType.Water);
                    //layer2b.Add(block.Type);
                    waterAttempts++;
                
            }
            foreach (Block b in this.TotalTiles)
                layer2b.Add(b.Type);

            #endregion
            #region Layer 3: Random Mountains
            //Layer 3: Random bergen op een paar plaatsen

            
            for(int mountainCounter = 0; mountainCounter < Settings.MountainClusters; mountainCounter++)
            

                foreach (Block block in filledBlockList)
                {
                    int mountainNeighbours = MapTools.GetBlockCount(this, block, BlockType.Mountain, this.Settings.Width / 4);
                    if (mountainNeighbours == 0)
                    {
                        var randomNo = mapRandomizer.Next(-1, 101);
                        var randomChecker = Math.Ceiling((double)Settings.MountainClusters / Settings.Size);
                        if (randomNo < randomChecker)
                        {
                            if (block.Type != BlockType.Road || block.Type != BlockType.Water)
                            {
                                block.Type = BlockType.Mountain;
                                
                                
                            }

                        }
                    }
                    //layer2.Add(block.Type);
                }
            //foreach (Block block in filledBlockList)
            //{
            //    if (mapRandomizer.Next(0, 100) < 5)
            //    {
            //        if (block.Type != BlockType.Road)
            //            block.Type = BlockType.Mountain;
            //    }
            //    //layer3.Add(block.Type);
            //}
            foreach (Block b in this.TotalTiles)
                layer3.Add(b.Type);



            #endregion
            #region Layer 3.5: Mountains+
            //Layer 4: Controleer voor bergen en cluster er meer

            //for (int y = 0; y < map.Height; y++)
            //{
            //    for (int x = 0; x < map.Width; x++)
            //    {
            //foreach (Block block in filledBlockList)
            //{

            //    if (block.Type == BlockType.Grass)
            //    {
            //        int sameTypeNeighbours = MapTools.GetBlockCount(this, block, BlockType.Mountain);
            //        if (sameTypeNeighbours >= 6)
            //        {
            //            block.Type = BlockType.Mountain;
            //        }
            //        else
            //        {
            //            if (mapRandomizer.Next(0, 100) < (10 * sameTypeNeighbours))
            //                block.Type = BlockType.Mountain;
            //        }
            //    }

            //    //layer4.Add(block.Type);
            //}

            var mountainPercentage = 0;
            int attemptCounter = 0;
            while (mountainPercentage < Settings.MountainDensity)
            
            {
                if (attemptCounter > 100*AvailableTiles.Count)
                    break;
                attemptCounter++;
                foreach (Block block in filledBlockList)
                    {
                        if (block.Type != BlockType.Mountain)
                        {
                            int sameTypeNeighbours = MapTools.GetBlockCount(this, block, BlockType.Mountain);
                            if (sameTypeNeighbours >= 3)
                            {
                                if (block.Type != BlockType.Road )
                                    block.Type = BlockType.Mountain;
                                //&& block.Type != BlockType.Water
                            }
                            else
                            {
                                {
                                    if (mapRandomizer.Next(0, 100) < (Settings.MountainDensity/2) * (sameTypeNeighbours * 2))
                                        if (block.Type != BlockType.Road)
                                            block.Type = BlockType.Mountain;
                                }
                            }

                        }
                    
                    }
                    mountainPercentage = MapTools.GetBlockPercentage(this, BlockType.Mountain);
                
                
                

            }
            foreach (Block b in this.TotalTiles)
                layer4.Add(b.Type);
            #endregion
            #region #region Layer X: Final
            //Layer X: Controleer map rand en plaatst bergen
            //Dit moet de laatste layer zijn!!!

            //for (int y = 0; y < map.Height; y++)
            //{
            //    for (int x = 0; x < map.Width; x++)
            //    {
            foreach (Block block in filledBlockList)
                {

                    if (block.Location.Y == 0 || block.Location.Y == this.Settings.Height - 1 || block.Location.X == 0 || block.Location.X == this.Settings.Width - 1)
                    {
                        if (block.Type != BlockType.Road)
                            block.Type = BlockType.Mountain;
                    }


                }
                #endregion
                #endregion
            
        }


        protected void GenerateMapSettings()
        {
            _settings = new MapSettings();
        }
    }

}
