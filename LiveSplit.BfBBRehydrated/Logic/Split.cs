using System.ComponentModel;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public enum SplitType
    {
        [Description("Manual Split")] Manual,
        [Description("Game End")] GameEnd,
        [Description("Individual Level Complete")] IndividualLevelComplete,
        [Description("Load Screen")] LoadScreen,
        [Description("Level Transition")] LevelTransition,
        [Description("Spatula Count")] SpatCount,
        [Description("Spatula Grab")] SpatGrab,
        [Description("Cutscene Start")] CutsceneStart
    }
    
    public class Split
    {
        public string Name;
        public SplitType Type;
        public int SubType;
    }
}