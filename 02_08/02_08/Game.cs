using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_08
{
    class Game
    {
    }
    class Map
    {
        private Mapssize _size;
        private string _gameName;
        private List<Obstacles> _mapobs;
        private List<Bonuses> _mapbon;
    }
    class Obstacles
    {
        private Position _position;
        private ObstaclesItem _type;
    }
    class Bonuses
    {
        private Position _position;
        private BonuseItem _type;
        public void UpCharacteristic() { }
    }
    public struct Position
    {
        int X;
        int Y;
        Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public enum ObstaclesItem
    {
        Tree,
        Stone,
        Pit
    }
    public enum BonuseItem
    {
        Rune,
        Potion,
        Weapon
    }
    public enum Mapssize
    {
        _16x16,
        _32x32,
        _64x64
    }
}
