using System;
using LiveSplit.Model;
using LiveSplit.UI.Components;

namespace LiveSplit.BfBBRehydrated.UI
{
    public class Factory : IComponentFactory
    {
        public const string AutosplitterName = "Battle for Bikini Bottom: Rehydrated Autosplitter";

        public IComponent Create(LiveSplitState state) => new Component(state);
        
        public ComponentCategory Category => ComponentCategory.Control;
        public string ComponentName => AutosplitterName;
        public string Description => "Autosplitter for Battle for Bikini Bottom: Rehydrated";

        public string UpdateName => ComponentName;
        public Version Version { get; }
        public string XMLURL { get; }
        public string UpdateURL { get; }
    }
}