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

        private int _currentSplitIndex = -1;
        private Memory.MemoryState _oldMemoryState;
        private Memory.MemoryState _currentMemoryState;

        public Autosplitter(LiveSplitState state)
        {
            _state = state;
            _model = new TimerModel() {CurrentState = _state};

            _state.OnStart += OnStart;
            _state.OnSplit += OnSplit;
            _state.OnSkipSplit += OnSkipSplit;
            _state.OnUndoSplit += OnUndoSplit;
            _state.OnReset += OnReset;
        }

        public void Update()
        {
            if (!Memory.IsHooked) return;
            _oldMemoryState = _currentMemoryState;
            _currentMemoryState = Memory.GetState();
            
            switch (_state.CurrentPhase)
            {
                case TimerPhase.NotRunning:
                    if (ShouldStart())
                    {
                        _model.Start();
                    }
                    break;
                case TimerPhase.Running:
                    // Pause timer when loading
                    _state.IsGameTimePaused = Memory.IsLoading;

                    if (ShouldSplit())
                    {
                        _model.Split();
                    }
                    else if (ShouldReset())
                    {
                        _model.Reset();
                    }
                    break;
            }
        }

        private bool ShouldStart()
        {
            return _oldMemoryState.IsLoading && !_currentMemoryState.IsLoading &&
                   _currentMemoryState.CurrentMap == Map.IntroCutscene;
        }

        private bool ShouldSplit()
        {
            Split currentSplit = AutosplitterSettings.Autosplits[_currentSplitIndex];

            switch (currentSplit.Type)
            {
                case SplitType.GameEnd:
                    return _oldMemoryState.SpatulaCount != _currentMemoryState.SpatulaCount &&
                           _currentMemoryState.CurrentMap == Map.ChumBucketBrain;
                case SplitType.LevelTransition:
                    return _oldMemoryState.CurrentMap != _currentMemoryState.CurrentMap;
                case SplitType.LoadScreen:
                    return !_oldMemoryState.IsLoading && _currentMemoryState.IsLoading;
            }
            return false;
        }

        private bool ShouldReset()
        {
            return _oldMemoryState.CurrentMap != _currentMemoryState.CurrentMap &&
                   _currentMemoryState.CurrentMap == Map.IntroCutscene;
        }

        private void OnStart(object obj, EventArgs e)
        {
            _state.SetGameTime(TimeSpan.FromSeconds(StartOffset));
            _currentSplitIndex = 0;
        }

        private void OnSplit(object obj, EventArgs e)
        {
            _currentSplitIndex++;
        }

        private void OnSkipSplit(object sender, EventArgs e)
        {
            _currentSplitIndex++;
        }

        private void OnUndoSplit(object sender, EventArgs e)
        {
            _currentSplitIndex--;
        }

        private void OnReset(object obj, TimerPhase phase)
        {
            _currentSplitIndex = -1;
        }
        
    }
}