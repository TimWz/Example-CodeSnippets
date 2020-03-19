using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapGeneratorLibrary.MapGeneration;
using MapGeneratorLibrary;
using MapGeneratorLibrary.MapStructure;

namespace Map_Generator_Console_V1
{
    class Program
    {
        static void Main(string[] args)
        {
            MapSettings customMapSettings = new MapSettings(50, 25, 15, 5, 5, 2, 1, 2);
            List<Map> createdMaps = new List<Map>();
            Map currentMap = null;
            Console.WriteLine("Hello, welcome to the Map Generator.");
            Console.ReadLine();
            Map lastMap = null;
            while (true)
            {
                Console.WriteLine("InsertCommand");
                var commandLine = Console.ReadLine();
               
                if (int.TryParse(commandLine, out var commandNo))
                {
                    switch (commandNo)
                    {
                        case 0:
                            Console.WriteLine("Creating new Map");
                            Map firstMap = new Map(new MapSettings());
                            firstMap.Populate();
                            Console.WriteLine("Map created...<Press Enter to Continue>");
                            Console.ReadLine();
                            Console.WriteLine($"Displaying Map with size {firstMap.Settings.Size}...");
                            Console.ReadLine();
                            DrawMap(firstMap);
                            Console.ReadLine();
                            lastMap = firstMap;
                            break;



                        case 1:
                            Console.WriteLine("Creating new Map");
                            Map secondMap = new Map(new MapSettings(40,40,30,4,20,2,1,100));
                            secondMap.Populate();
                            Console.WriteLine("Map created...<Press Enter to Continue>");
                            Console.ReadLine();
                            Console.WriteLine($"Displaying Map with size {secondMap.Settings.Size}...");
                            Console.ReadLine();
                            DrawMap(secondMap);
                            Console.ReadLine();
                            lastMap = secondMap;
                            break;
                        case 2:
                            Console.WriteLine("Creating new Map");

                            Console.WriteLine("Enter Width");
                            int width = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Height");
                            int height = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Water Density");
                            int waterDens = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Water Clusters");
                            int waterClus = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Mountain Density");
                            int mountainDens = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Mountain Clusters");
                            int mountainClus = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Road Count");
                            Console.ReadLine();
                            int roadC = 1;

                            bool verLen = false;
                            int roadLength = 0;
                            while (!verLen)
                            {
                                Console.WriteLine("Enter minimum Road Length");
                                roadLength = Convert.ToInt32(Console.ReadLine());
                                if (roadLength > (width * height) / 4)
                                    Console.WriteLine("Road too long for the size");
                                else
                                    verLen = true;
                            }

                            Map thirdMap = new Map(new MapSettings(width,height,waterDens,waterClus,mountainDens,mountainClus,roadC,roadLength));
                            thirdMap.Populate();
                            Console.WriteLine("Map created...<Press Enter to Continue>");
                            Console.ReadLine();
                            Console.WriteLine($"Displaying Map with size {thirdMap.Settings.Size}...");
                            Console.ReadLine();
                            DrawMap(thirdMap);
                            Console.ReadLine();
                            lastMap = thirdMap;
                            break;
                        case 3:
                            Console.WriteLine("Creating new CrossMap");
                            Map fourthMap = new CrossMap(new MapSettings());
                            fourthMap.Populate();
                            Console.WriteLine("Map created...<Press Enter to Continue>");
                            Console.ReadLine();
                            Console.WriteLine($"Displaying Map with size {fourthMap.Settings.Size}...");
                            Console.ReadLine();
                            DrawMap(fourthMap);
                            Console.ReadLine();
                            lastMap = fourthMap;
                            break;
                        case 4:
                            Console.WriteLine("Creating new LineMap");
                            Map fifthMap = new LinesMap(new MapSettings());
                            fifthMap.Populate();
                            Console.WriteLine("Map created...<Press Enter to Continue>");
                            Console.ReadLine();
                            Console.WriteLine($"Displaying Map with size {fifthMap.Settings.Size}...");
                            Console.ReadLine();
                            DrawMap(fifthMap);
                            Console.ReadLine();
                            lastMap = fifthMap;
                            break;


                        //case 3:
                        //    if (currentMap != null)
                        //    {
                        //        Console.WriteLine($"Displaying Map with size {currentMap.Settings.Size}...");
                        //        Console.ReadLine();
                        //        DrawMap(currentMap);
                        //        Console.ReadLine();
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("No map currently selected");
                        //        Console.ReadLine();
                        //    }
                        //    break;
                        //case 4:
                        //    Console.WriteLine("Creating new Map");
                        //    Console.WriteLine("How big is each side of the map?");
                        //    int inputSize = Convert.ToInt32(Console.ReadLine());
                        //    Map normalMap = new Map(new MapSettings());
                        //    normalMap.Populate();
                        //    Console.WriteLine("Map created...<Press Enter to Continue>");
                        //    createdMaps.Add(normalMap);
                        //    currentMap = normalMap;
                        //    Console.ReadLine();
                        //    break;
                        //case 5:
                        //    Console.WriteLine("Creating & Convert new Map");

                        //    LinesMap convertingMap = new LinesMap(new MapSettings());
                        //    convertingMap.Populate();
                        //    Console.WriteLine("Map created...<Press Enter to Continue>");
                        //    createdMaps.Add(convertingMap);
                        //    currentMap = convertingMap;
                        //    Console.ReadLine();
                        //    Console.WriteLine($"Displaying Map with size {currentMap.Settings.Size}...");
                        //    DrawMap(currentMap);
                        //    Console.ReadLine();
                        //    //Map convertedMap = MapConversion.ConvertToMap(convertingMap);
                        //    Console.WriteLine($"Converting {currentMap.GetType().Name} to a normal map and showing the result!");
                        //    DrawMap(currentMap);
                        //    Console.ReadLine();

                        //    break;
                        //case 6:
                        //    Console.WriteLine("Create Supermap");
                        //    Console.WriteLine("Enter how long a single side of the map should be");
                        //    int mapSize = Convert.ToInt32(Console.ReadLine());
                        //    Console.WriteLine("How many maps do you want to use for the supermap (2, 4 , 8 etc..)?");
                        //    int mapAmount = Convert.ToInt32(Console.ReadLine());
                        //    List<Map> mapList = new List<Map>();
                        //    for (int c = 0; c < mapAmount; c++)
                        //    {
                        //        Map map = new Map(new MapSettings());
                        //        map.Populate();
                        //        mapList.Add(map);
                        //    }
                        //    Console.WriteLine($"Drawing a supermap, consisting of {mapList.Count} maps");
                        //    Console.ReadLine();
                        //    // DrawMultiMap(mapList);
                        //    break;
                        //case 7:
                        //    Console.WriteLine("Creating new LayeredMap");
                        //    LinesMap layeredMap = new LinesMap();
                        //    layeredMap.Populate();
                        //    Console.WriteLine("Map created...<Press Enter to Continue>");
                        //    createdMaps.Add(layeredMap);
                        //    currentMap = layeredMap;
                        //    Console.ReadLine();
                        //    break;
                        //case 8:
                        //    Console.WriteLine("Creating new CrossMap");
                        //    CrossMap crossMap = new CrossMap(new MapSettings());
                        //    crossMap.Populate();
                        //    Console.WriteLine("Map created...<Press Enter to Continue>");
                        //    createdMaps.Add(crossMap);
                        //    currentMap = crossMap;
                        //    Console.ReadLine();
                        //    break;
                        case 8:
                            bool inf = true;
                            while (inf)
                            {
                                Console.WriteLine("Creating new Map");
                                Map infMap = new Map(new MapSettings());
                                infMap.Populate();
                                Console.WriteLine("Map created...<Press Enter to Continue>");
                                currentMap = infMap;
                                Console.WriteLine($"Displaying Map with size {currentMap.Settings.Size}...");

                                DrawMap(currentMap);

                            }
                            break;
                        case 9:
                            Console.WriteLine("Displaying Map Creation Process");
                            if (lastMap != null)
                            {
                                Console.WriteLine($"Displaying Map with size {lastMap.Settings.Size}...");
                                Console.ReadLine();
                                
                                DrawMap(lastMap, lastMap.layer1);
                                Console.ReadLine();
                                DrawMap(lastMap, lastMap.layerRoads);
                                Console.ReadLine();
                                DrawMap(lastMap, lastMap.layer2);
                                Console.ReadLine();
                                DrawMap(lastMap, lastMap.layer2b);
                                Console.ReadLine();
                                DrawMap(lastMap, lastMap.layer3);
                                Console.ReadLine();
                                DrawMap(lastMap, lastMap.layer4);
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("No map currently selected");
                                Console.ReadLine();
                            }
                            break;
                        //case 10:
                        //    bool inf = true;
                        //    while (inf)
                        //    {
                        //        Console.WriteLine("Creating new Map");
                        //        Map infMap = new Map(new MapSettings());
                        //        infMap.Populate();
                        //        Console.WriteLine("Map created...<Press Enter to Continue>");
                        //        currentMap = infMap;
                        //        Console.WriteLine($"Displaying Map with size {currentMap.Settings.Size}...");
                        //        Console.ReadLine();
                        //        DrawMap(currentMap);
                        //        Console.ReadLine();
                        //    }
                        //    break;
                        default:
                            Console.WriteLine("Creating new default Map");
                            Map newMap = new Map();
                            newMap.Populate();
                            Console.WriteLine("Map created...<Press Enter to Continue>");
                            createdMaps.Add(newMap);
                            currentMap = newMap;
                            Console.WriteLine($"Displaying Map with size {currentMap.Settings.Size}...");
                            Console.ReadLine();
                            DrawMap(currentMap);

                            Console.ReadLine();
                            break;
                    }
                }
            }
        }

        private static void DrawMap(Map currentMap)
        {
            Console.BackgroundColor = currentMap.Settings.color;
            for (int y = 0; y < currentMap.Settings.Height; y++)
            {
                //string displayer = y + "  | ";
                // string displayer = String.Empty;
                for (int x = 0; x < currentMap.Settings.Width; x++)
                {
                    Block block = currentMap.TotalTiles[(currentMap.Settings.Width * y) + x];
                    string blockString = string.Empty;
                    switch (block.Type)
                    {
                        case BlockType.Grass:
                            blockString = "X";
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case BlockType.Water:
                            blockString = "~";
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case BlockType.Mountain:
                            blockString = "^";
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case BlockType.Road:
                            blockString = "#";
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        default:
                            blockString = " ";
                            break;
                    }
                    //displayer += currentMap.mapTiles[(currentMap.Width * y) + x].blockType + " ";
                    string blockDisplayString = blockString + " ";
                    Console.Write(blockDisplayString);
                    if (x == currentMap.Settings.Width - 1)
                        Console.WriteLine();

                }
                // Console.WriteLine(displayer);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private static void DrawMap(Map currentMap, List<BlockType> blockTypeList)
        {
            List<Block> fullList = new List<Block>(currentMap.TotalTiles.Count);
                //currentMap.TotalTiles.ForEach((item) =>
                //{
                //    fullList.Add((Block)item.Clone());
                //});
                int listIndexer = 0;
            foreach(Block block in currentMap.TotalTiles)
            {
                //var newBlock = new Block(block.Location.X, block.Location.Y);
                //newBlock.Type = block.Type;
                fullList.Add(block);
            }
                for(int i = 0; i < fullList.Count; i++)
                {
                        for(int j = 0; j < currentMap.AvailableTiles.Count; j++)
                        {
                            if(fullList[i] == currentMap.AvailableTiles[j])
                            {
                        fullList[i] = new Block(fullList[i].Location.X, fullList[i].Location.Y);
                        fullList[i].Type = blockTypeList[listIndexer];

                            listIndexer++;
                            }
                        }
                }
            
                

            Console.BackgroundColor = currentMap.Settings.color;
            for (int y = 0; y < currentMap.Settings.Height; y++)
            {
                for (int x = 0; x < currentMap.Settings.Width; x++)
                {
                    Block block = fullList[(currentMap.Settings.Width * y) + x];
                    string blockString = string.Empty;
                    switch (block.Type)
                    {
                        case BlockType.Grass:
                            blockString = "X";
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case BlockType.Water:
                            blockString = "~";
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case BlockType.Mountain:
                            blockString = "^";
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case BlockType.Road:
                            blockString = "#";
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        default:
                            blockString = " ";
                            break;
                    }
                    //displayer += currentMap.mapTiles[(currentMap.Width * y) + x].blockType + " ";
                    string blockDisplayString = blockString + " ";
                    Console.Write(blockDisplayString);
                    if (x == currentMap.Settings.Width - 1)
                        Console.WriteLine();

                }
                // Console.WriteLine(displayer);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        //private static void DrawMultiMap(List<Map> mapList)
        //{
        //    #region oldMulticode
        //    //int mapCount = mapList.Count;
        //    //int totalWidth, totalHeight;

        //    //totalWidth = Convert.ToInt32(mapList[0].Width * Math.Floor(mapCount / 2f));
        //    //totalHeight = Convert.ToInt32(mapList[0].Height * Math.Ceiling(mapCount / 2f));


        //    //Map mapListSelector = null;

        //    //for (int y = 0; y < totalHeight; y++)
        //    //{
        //    //    //string displayer = y + "  | ";
        //    //    // string displayer = String.Empty;
        //    //    for (int x = 0; x < totalWidth; x++)
        //    //    {
        //    //        if(x >= 0 && x < mapList[0].Width)
        //    //            mapListSelector = mapList[0];
        //    //        if (x >= mapList[0].Width && x < totalWidth)
        //    //            mapListSelector = mapList[1];


        //    //        Block block = mapListSelector.mapTiles[(mapListSelector.Width * y) + x];
        //    //        switch (block.blockType)
        //    //        {
        //    //            case "~":
        //    //                Console.ForegroundColor = ConsoleColor.Blue;
        //    //                break;
        //    //            case "^":
        //    //                Console.ForegroundColor = ConsoleColor.DarkMagenta;
        //    //                break;
        //    //            case "X":
        //    //                Console.ForegroundColor = ConsoleColor.Green;
        //    //                break;
        //    //            default:
        //    //                Console.ForegroundColor = ConsoleColor.White;
        //    //                break;

        //    //        }
        //    //        //displayer += currentMap.mapTiles[(currentMap.Width * y) + x].blockType + " ";
        //    //        string blockDisplayString = block.blockType + " ";
        //    //        Console.Write(blockDisplayString);
        //    //        if (x == mapListSelector.Width - 1)
        //    //            Console.WriteLine();
        //    //    }


        //    //    // Console.WriteLine(displayer);
        //    //    Console.ForegroundColor = ConsoleColor.White;
        //    //}
        //    #endregion
        //    bool isOdd = false;
        //    int mapCount = mapList.Count;
        //    //if (mapCount % 2 == 1)        
        //    //    isOdd = true;
        //    //else
        //    //    isOdd = false;
        //    int mergeIndex = 0;
        //    Map mergedMap = null;
        //    for (int i = 0; i < Math.Floor(mapList.Count / 2f); i++)
        //    {

        //        mergedMap = MapCreation.MergeMaps(mapList[mergeIndex], mapList[mergeIndex + 1], MapCreation.MergeType.HORIZONTAL_R);
        //        mergeIndex += 2;
        //    }
        //    Console.WriteLine($"Created a merged map");
        //    DrawMap(mergedMap);
            
        //}
    }

    //list.ForEach(i => Console.Write("{0}\t", i));
}





//for (int i = 0; i < currentMap.Size; i += 5)
//{
//    //Console.WriteLine($"{currentMap.mapTiles[i].blockType} {currentMap.mapTiles[i + 1].blockType} {currentMap.mapTiles[i + 2].blockType} {currentMap.mapTiles[i + 3].blockType} {currentMap.mapTiles[i + 4].blockType}");
//    Console.WriteLine(currentMap.mapTiles[i].blockType + " " + currentMap.mapTiles[i + 1].blockType + " " + currentMap.mapTiles[i + 2].blockType + " " + currentMap.mapTiles[i + 3].blockType + " " + currentMap.mapTiles[i + 4].blockType);
//}