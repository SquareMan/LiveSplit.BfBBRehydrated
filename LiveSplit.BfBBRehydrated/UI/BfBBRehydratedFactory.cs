using System;
using System.Reflection;
using LiveSplit.Model;
using LiveSplit.UI.Components;

namespace LiveSplit.BfBBRehydrated.UI
{
    public class BfBBRehydratedFactory : IComponentFactory
    {
        public const string AutosplitterName = "Battle for Bikini Bottom: Rehydrated Autosplitter";
        public IComponent Create(LiveSplitState state) => new BfBBRehydratedComponent(state);
        public string ComponentName => $"{AutosplitterName} v{Version.ToString(3)}";
        public string Description => AutosplitterName;
        public ComponentCategory Category => ComponentCategory.Control;
        public string UpdateName => ComponentName;
        public string UpdateURL => "https://raw.githubusercontent.com/SquareMan/LiveSplit.BfBBRehydrated/master/LiveSplit.BfBBRehydrated/";
        public string XMLURL => UpdateURL + "Components/Updates.xml";
        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}