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
        private readonly RehydratedSettings _settings;
        private readonly Autosplitter _autosplitter;

        public Component(LiveSplitState state)
        {
            _settings = new RehydratedSettings(state);
            _autosplitter = new Autosplitter(state);
            
            // TODO: This is a workaround for settings form not adding controls if the autosplits are incorrectly deemed to not have changed
            // (Such as when the component is deactivated/reactivated, the static list stays the same, but the form is new. 
            AutosplitterSettings.Autosplits = new List<Split>();
            
            // Make sure the user is using the correct Timing Method
            if (state.CurrentTimingMethod == TimingMethod.RealTime)
            {
                var messageResponse = MessageBox.Show(strings.GameTime_Warning, strings.Component_Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (messageResponse == DialogResult.Yes)
                {
                    state.CurrentTimingMethod = TimingMethod.GameTime;
                }
            }
        }

        public void Dispose()
        {
            _autosplitter.Dispose();
        }
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
            if (settings["ScriptPath"] != null)
            {
                //We have upgraded from the ASL script to this component.
                var messageResponse = MessageBox.Show(strings.Settings_Conversion, strings.Component_Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messageResponse == DialogResult.Yes)
                {
                    _settings.PortSettings(settings);
                    MessageBox.Show
                    (
                        strings.Settings_Conversion_Completed,
                        strings.Component_Caption, MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
                }
            }
            else
            {
                _settings.SetSettings(settings);
            }
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            Memory.HookProcess();
            
            _autosplitter.Update();
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