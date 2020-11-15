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
        
        private static readonly TimeSpan _splitDelay = TimeSpan.FromSeconds(0.1f);
        private DateTime _timeUntilNextSplit;

        public Autosplitter(LiveSplitState state)
        {
            _state = state;
            _model = new TimerModel() {CurrentState = _state};
            
            _state.OnSplit += OnSplit;
        }

        public void Dispose()
        {
            _state.OnSplit -= OnSplit;
        }

        public void Update()
        {
            _oldMemoryState = _currentMemoryState;
            _currentMemoryState = Memory.GetState();
            
            switch (_state.CurrentPhase)
            {
                case TimerPhase.NotRunning:
                    if (ShouldStart())
                    {
                        _model.Start();
                        _state.SetGameTime(TimeSpan.FromSeconds(StartOffset));
                    }
                    break;
                case TimerPhase.Running:
                    // Pause timer when loading
                    _state.IsGameTimePaused = _currentMemoryState.IsLoading;

                    if (DateTime.Now > _timeUntilNextSplit && ShouldSplit())
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
            switch (AutosplitterSettings.StartCondition)
            {
                case StartingCondition.NewGame:
                    return _oldMemoryState.IsLoading && !_currentMemoryState.IsLoading &&
                           _currentMemoryState.Level == Level.IntroCutscene;
                case StartingCondition.IndividualLevel:
                    Level targetLevel = AutosplitterSettings.StartLevel;
                    return targetLevel == Level.Any
                        ? _oldMemoryState.Level != _currentMemoryState.Level
                        : _oldMemoryState.Level != targetLevel && _currentMemoryState.Level == targetLevel;
                default:
                    return false;
            }
        }

        private bool ShouldSplit()
        {
            Split currentSplit = AutosplitterSettings.Autosplits[_state.CurrentSplitIndex];

            switch (currentSplit.Type)
            {
                case SplitType.GameEnd:
                    return _oldMemoryState.SpatulaCount < _currentMemoryState.SpatulaCount &&
                           (_currentMemoryState.Level == Level.ChumBucketBrain || _currentMemoryState.Level == Level.Any);
                case SplitType.LevelTransition:
                    Level targetLevel = (Level) currentSplit.SubType;
                    return targetLevel == Level.Any
                        ? _oldMemoryState.Level != _currentMemoryState.Level
                        : _oldMemoryState.Level != targetLevel && _currentMemoryState.Level == targetLevel;
                case SplitType.LoadScreen:
                    return !_oldMemoryState.IsLoading && _currentMemoryState.IsLoading;
                case SplitType.SpatCount:
                    return _oldMemoryState.SpatulaCount != currentSplit.SubType &&
                           _currentMemoryState.SpatulaCount == currentSplit.SubType;
                case SplitType.SpatGrab:
                    return _oldMemoryState.SpatulaCount < _currentMemoryState.SpatulaCount;
                case SplitType.CutsceneStart:
                    Sequence targetSequence = (Sequence) currentSplit.SubType;
                    bool intersects = targetSequence == Sequence.Any || MathHelper.Intersects(Memory.PlayerLocation,
                        SequenceHelper.Bounds[targetSequence].Item1,
                        SequenceHelper.Bounds[targetSequence].Item2);
                    return !_oldMemoryState.IsCutsceneActive && _currentMemoryState.IsCutsceneActive && intersects;
            }
            return false;
        }
        
        private bool ShouldReset()
        {
            switch (AutosplitterSettings.ResetPreference)
            {
                case ResetPreference.NewGame:
                    return _oldMemoryState.Level != _currentMemoryState.Level &&
                           _currentMemoryState.Level == Level.IntroCutscene;
                case ResetPreference.MainMenu:
                    // Map.Any only appears in memory when the game is not hooked (i.e. after a crash)
                    return _oldMemoryState.Level != Level.Any &&
                           _oldMemoryState.Level != _currentMemoryState.Level &&
                           _currentMemoryState.Level == Level.MainMenu;
            }

            return false;
        }

        private void OnSplit(object obj, EventArgs e)
        {
            _timeUntilNextSplit = DateTime.Now + _splitDelay;
        }
    }
}