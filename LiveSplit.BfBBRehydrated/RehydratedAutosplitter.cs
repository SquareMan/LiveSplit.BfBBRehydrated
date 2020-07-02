
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LiveSplit.ComponentUtil;

namespace LiveSplit.BfBBRehydrated
{
    public class Component : IComponent
    {
        private LiveSplitState _state;

        private Process _game;
        private bool _isHooked = false;
        private readonly DeepPointer _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0331A650, 0x20, 0x1D0);
        
        public Component(LiveSplitState state)
        {
            _state = state;
        }
        
        public void Dispose() {}
        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) {}
        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) {}

        public Control GetSettingsControl(LayoutMode mode)
        {
            return new Control("Control");
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            return new XmlDocument();
        }

        public void SetSettings(XmlNode settings)
        {
            
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            // Logic for hooking the game process (Move to another method/class?)
            if (_game == null)
            {
                _isHooked = false;
            }
            else if (_game.HasExited)
            {
                _isHooked = false;
            }
            else
            {
                _isHooked = _isLoadingDP.Deref<bool>(_game, out var ignore);
            }

            if (!_isHooked)
            {
                _game = Process.GetProcessesByName("Pineapple-Win64-Shipping").First();
                if (_game != null)
                {
                    _isHooked = _isLoadingDP.Deref<bool>(_game, out var ignore);
                }
            }

            if (!_isHooked) return;
            
            // Pause timer when loading
            state.IsGameTimePaused = _isLoadingDP.Deref<bool>(_game);

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