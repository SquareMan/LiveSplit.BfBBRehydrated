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
        private Autosplitter _autosplitter;

        public Component(LiveSplitState state)
        {
            _state = state;
            _settings = new RehydratedSettings(state);
            _autosplitter = new Autosplitter(state);
            
            // Make sure the user is using the correct Timing Method
            if (_state.CurrentTimingMethod == TimingMethod.RealTime)
            {        
                var timingMessage = MessageBox.Show
                (
                    "This game uses Time without Loads (Game Time) as the main timing method.\n"+
                    "LiveSplit is currently set to show Real Time (RTA).\n"+
                    "Would you like to set the timing method to Game Time?",
                    "LiveSplit | BFBB Rehydrated",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question
                );
                if (timingMessage == DialogResult.Yes)
                {
                    _state.CurrentTimingMethod = TimingMethod.GameTime;
                }
            }
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
            if (settings["ScriptPath"] != null)
            {
                //We have upgraded from the ASL script to this component.
                if (MessageBox.Show
                (
                "The autosplitter has been updated, would you like to have your settings converted?", "LiveSplit | BFBB Rehydrated",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question
                ) == DialogResult.Yes)
                {
                    _settings.PortSettings(settings);
                    MessageBox.Show
                    (
                        "The conversion process has completed. You may want to check your settings to make sure everything is still correct.\n\n" +
                        "If you previously used the delay split option, you will need to manually setup Level Transition splits to achieve the same behavior.\n\n" +
                        "If you previously used a mixture of manual and automatic splits you will need to manually reorder your split settings.",
                        "LiveSplit | BFBB Rehydrated", MessageBoxButtons.OK, MessageBoxIcon.Information
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