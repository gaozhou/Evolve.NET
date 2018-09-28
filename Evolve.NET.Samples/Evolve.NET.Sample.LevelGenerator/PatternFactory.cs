namespace Evolve.NET.Sample.LevelGenerator
{
    public class PatternFactory
    {
        public static readonly int PATTERN_LENGTH = 13;

        public static readonly char PATTERN_NONE = '.';
        public static readonly char PATTERN_GROUND = '#';
        public static readonly char PATTERN_ENEMY = 'M';
        public static readonly char PATTERN_BLOCK_COIN = '?';
        public static readonly char PATTERN_BLOCK_ITEM = '!';
        public static readonly char PATTERN_BLOCK = '@';

        public static readonly string[] Patterns =
        {
            ".............",
            "............#",
            "...........##",
            "..........###",
            ".........####",
            "........#####",
            ".......######",
            "......#######",
            ".....########",
            "........?...#",
            "....?...?...#",
            "........!...#",
            "....!...!...#",
            "........@...#",
            "....@...@...#",
            "....@.......#",
            "....@........",
            "........?....",
            "........!....",
            "........@....",
            "...........M#",
            "........@..M#",
            "........!..M#",
            "........?..M#",
            "...M@.......#",
            "...M@........",
        };

        public static int Count
        {
            get { return Patterns.Length; }
        }
    }
}
