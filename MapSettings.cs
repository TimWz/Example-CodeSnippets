using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneratorLibrary.MapStructure
{
    public class MapSettings
    {
        int _height;
        int _width;
        int _size;

        bool _hasWater;
        int _waterDensity;
        int _waterClusters;

        bool _hasMountains;
        int _mountainDensity;
        int _mountainClusters;

        bool _hasRoad;
        int _roadCount;
        int _roadSize;
        

        #region Properties
        public int Height
        {
            get
            {
                return _height;
            }

        }
        public int Width
        {
            get
            {
                return _width;
            }
        }
        public int Size
        {
            get
            {
                return _size;
            }
        }
        public bool HasWater
        {
            get
            {
                return _hasWater;
            }
        }
        public int WaterDensity
        {
            get
            {
                return _waterDensity;
            }
        }
        public int WaterClusters
        {
            get
            {
                return _waterClusters;
            }
        }
        public bool HasMountains
        {
            get
            {
                return _hasMountains;
            }
        }
        public int MountainDensity
        {
            get
            {
                return _mountainDensity;
            }
        }
        public int MountainClusters
        {
            get
            {
                return _mountainClusters;
            }
        }
        public bool HasRoad
        {
            get
            {
                return _hasRoad;
            }
        }
        public int RoadCount
        {
            get
            {
                return _roadCount;
            }
        }
        public int RoadSize
        {
            get
            {
                return _roadSize;
            }
        }
#endregion


        public ConsoleColor color; //Property van maken! (Private, of publieke property, GEEN PUBLIC FIELDS)
        public MapSettings()
        {
            _width = 60;
            _height = 40;
            _size = Width * Height;
            color = ConsoleColor.Black;
            _hasWater = true;
            _waterDensity = 30;
            _waterClusters = 8;
            _roadCount = 1;
            _roadSize = 50;
            _hasMountains = true;
            _mountainDensity = 10;
            _mountainClusters = 4;

            _hasRoad = false;
        }

        public MapSettings(int size)
        {
            _width = _width = size;
            color = ConsoleColor.Black;
            _hasWater = true;
            _waterDensity = 15;
            _waterClusters = 2;

            _hasMountains = true;
            _mountainDensity = 5;
            _mountainClusters = 1;

            _hasRoad = false;
        }

        public MapSettings(int width, int height, int waterDensity, int waterClusters, int mountainDensity, int mountainClusters, int roadCount, int roadSize)
        {
            if (_waterDensity > 0)
                _hasWater = true;
            else
                _hasWater = false;

            if (_mountainDensity > 0)
                _hasMountains = true;
            else
                _hasMountains = false;

            if (_roadCount > 0)
                _hasRoad = true;
            else
               _hasRoad = false;

        

            _width = width;
            _height = height;
            _size = Width * Height;
            _waterDensity = waterDensity;
            _waterClusters = waterClusters;
            _mountainDensity = mountainDensity;
            _mountainClusters = mountainClusters;
            _roadCount = roadCount;
            _roadSize = roadSize;

        }
    }
}
