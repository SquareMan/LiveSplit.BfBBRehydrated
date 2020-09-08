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
    public class Component : LogicComponent
    {
        public override string ComponentName => Factory.AutosplitterName;
        
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

        public override void Dispose()
        {
            _autosplitter.Dispose();
        }
        
        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            Memory.HookProcess();
            
            _autosplitter.Update();
        }

        public override Control GetSettingsControl(LayoutMode mode)
        {
            return _settings;
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return _settings.GetSettings(document);
        }

        public override void SetSettings(XmlNode settings)
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
    }
}