using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapGeneratorLibrary.MapStructure
{
    public enum BlockType
    {
        Empty,
        Grass,
        Water,
        Mountain,
        Road
    }

    public struct Location
    {
        int x;
        int y;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }

        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }


    public class Block : ICloneable // ENUMs gebruiken voor de types, uitzoeken hoe een property meerdere enum flags kan bevatten!
    {

        bool wasEdited;
        private BlockType type;

        public bool WasEdited { 
            get 
            {
                return wasEdited;
                    } 
            set 
            { 
                wasEdited = value; 
            }

        }
        public BlockType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }


        Location location;

        public Location Location
        {
            get
            {
                return location;
            }

        }


        public Block(int x, int y)
        {
            type = BlockType.Empty;
            location.X = x;
            location.Y = y;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    //TODO: Cloning uitzoeken, blijkt een niet-aangerade methode te zijn!
}
