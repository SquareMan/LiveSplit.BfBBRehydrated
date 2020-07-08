using System.ComponentModel;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public enum SplitType
    {
        [Description("Manual Split")] Manual,
        // [Description("Game Start")] GameStart, Not currently implemented
        [Description("Game End")] GameEnd,
        [Description("Load Screen")] LoadScreen,
        [Description("Level Transition")] LevelTransition,
        [Description("Spatula Count")] SpatCount,
        [Description("Spatula Grab")] SpatGrab
    }
    
    public class Split
    {
        public string Name;
        public SplitType Type;
        public int SubType;
    }
}