﻿using System.ComponentModel;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public enum SplitType
    {
        [Description("Manual Split")]
        Manual,
        GameStart,
        GameEnd,
        LevelTransition,
        LoadScreen,
        SpatCount
    }
    
    public class Split
    {
        public string Name;
        public SplitType Type;
        public int SubType;
    }
}