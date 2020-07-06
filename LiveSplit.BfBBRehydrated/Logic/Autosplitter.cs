using System;
using LiveSplit.Model;
using UpdateManager;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public class Autosplitter
    {
        public const float StartOffset = 138f/60f;
        
        private LiveSplitState _state;
        private TimerModel _model;

        private Memory.MemoryState _oldMemoryState;
        private Memory.MemoryState _currentMemoryState;

        public Autosplitter(LiveSplitState state)
        {
            _state = state;
            _model = new TimerModel() {CurrentState = _state};
        }

        public void Update()
        {
            if (!Memory.IsHooked) return;
            _oldMemoryState = _currentMemoryState;
            _currentMemoryState = Memory.GetState();
            
            switch (_state.CurrentPhase)
            {
                case TimerPhase.NotRunning:
                    TryStart();
                    break;
                case TimerPhase.Running:
                    // Pause timer when loading
                    _state.IsGameTimePaused = Memory.IsLoading;
                    
                    TrySplit();
                    TryReset();
                    break;
            }
        }

        private bool TryStart()
        {
            if (_oldMemoryState.IsLoading && !_currentMemoryState.IsLoading &&
                _currentMemoryState.CurrentMap == Map.IntroCutscene)
            {
                _model.Start();
                _state.SetGameTime(TimeSpan.FromSeconds(StartOffset));
                return true;
            }
            
            return false;
        }

        private bool TrySplit()
        {
            return false;
        }

        private bool TryReset()
        {
            if (_oldMemoryState.CurrentMap != _currentMemoryState.CurrentMap &&
                _currentMemoryState.CurrentMap == Map.IntroCutscene)
            {
                _model.Reset();
                return true;
            }
            return false;
        }
        
    }
}