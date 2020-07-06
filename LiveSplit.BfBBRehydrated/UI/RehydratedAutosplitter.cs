using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.BfBBRehydrated.Logic;
using LiveSplit.ComponentUtil;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.BfBBRehydrated.UI
{
    public class Component : IComponent
    {
        private LiveSplitState _state;
        private RehydratedSettings _settings;
        private TextComponent _debugText;

        public Component(LiveSplitState state)
        {
            _state = state;
            _settings = new RehydratedSettings(state);
        }
        
        public void Dispose() {}
        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) {}
        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) {}

        public Control GetSettingsControl(LayoutMode mode)
        {
            return _settings;
        }

        /// <summary>
        /// Called continuously by LiveSplit
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public XmlNode GetSettings(XmlDocument document)
        {
            return _settings.GetSettings(document);
        }

        /// <summary>
        /// Called by LiveSplit on startup and after closing the Edit Layout menu (even if nothing is changed)
        /// </summary>
        /// <param name="settings"></param>
        public void SetSettings(XmlNode settings)
        {
            _settings.SetSettings(settings);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            Memory.HookProcess();
            
            // Pause timer when loading
            state.IsGameTimePaused = Memory.IsLoading;
            
            UpdateDebug();
        }

        /// <summary>
        /// Find Debug text component to write output to it.
        /// </summary>
        private void UpdateDebug()
        {
            if(_debugText == null)
            {
                foreach (var layoutComponent in _state.Layout.LayoutComponents)
                {
                    if (layoutComponent.Component is TextComponent text)
                    {
                        if (text.Settings.Text1.IndexOf("DEBUG", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            _debugText = text;
                            break;
                        }
                    }
                }
            }
            else
            {
                _debugText.Settings.Text1 = $"IsHooked: {Memory.IsHooked.ToString()}";
            }
        }

        public string ComponentName => Factory.AutosplitterName;
        public float HorizontalWidth => 0;
        public float MinimumHeight => 0;
        public float VerticalHeight => 0;
        public float MinimumWidth => 0;
        public float PaddingTop => 0;
        public float PaddingBottom => 0;
        public float PaddingLeft => 0;
        public float PaddingRight => 0;
        public IDictionary<string, Action> ContextMenuControls { get; }
    }
}