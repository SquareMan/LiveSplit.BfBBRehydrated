using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using LiveSplit.ComponentUtil;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public static class Memory
    {
        public struct MemoryState
        {
            public bool IsLoading;
            public int SockCount;
            public int SpatulaCount;
            public Level Level;
        }

        public enum Version
        {
            Unsupported = 0,
            Revision603296 = 603296,
            Revision603442 = 603442,
            Revision603899 = 603899
        }
        
        public static Version GameVersion { get; private set; }
        
        public static bool IsLoading => IsHooked && _isLoadingDP.Deref<bool>(Game);
        public static int SockCount => IsHooked ? _sockCountDp.Deref<int>(Game) : 0;
        public static int SpatulaCount => IsHooked ? _spatulaCountDP.Deref<int>(Game) : 0;
        public static Level CurrentLevel
        {
            get
            {
                if (!IsHooked)
                {
                    return Level.Any;
                }
                
                string levelString = _currentLevelDP.DerefString(Game, 150, "");
                if (MapsHelper.Paths.TryGetValue(levelString, out var currentLevel))
                {
                    return currentLevel;
                }

                // TODO: Unkown level, log error?
                return Level.Any;
            }
        }

        private static DeepPointer _isLoadingDP;
        private static DeepPointer _sockCountDp;
        private static DeepPointer _spatulaCountDP;
        private static DeepPointer _currentLevelDP;
        
        public static Process Game { get; private set; }
        public static bool IsHooked { get; private set; }

        private const double HookAttemptDelay = 1.0;
        private static DateTime _nextHookAttemptTime;

        /// <summary>
        /// Create a snapshot of the current memory values
        /// </summary>
        /// <returns></returns>
        public static MemoryState GetState()
        {
            return new MemoryState {IsLoading = IsLoading, SockCount = SockCount, SpatulaCount = SpatulaCount, Level = CurrentLevel};
        }
        
        /// <summary>
        /// Attempt to hook the game process (if not already hooked)
        /// </summary>
        public static void HookProcess()
        {
            if (Game != null)
            {
                if(!Game.HasExited) return;

                // The game has exited and we need to clean up
                Game.Dispose();
                Game = null;
            
                IsHooked = false;
                return;
            }

            // Only attempt to hook process once per second.
            if (DateTime.Now < _nextHookAttemptTime)
            {
                return;
            }
            _nextHookAttemptTime = DateTime.Now.AddSeconds(HookAttemptDelay);

            Process[] processes = Process.GetProcessesByName("Pineapple-Win64-Shipping");
                
            if (processes.Length <= 0)
                return;
                
            Game = processes.First();
                
            // Determine Game Version
            int moduleMemorySize = Game.MainModule.ModuleMemorySize;
            switch (moduleMemorySize)
            {
                // Revision 603296
                case 58867712:
                    _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0338B8D0, 0x20, 0x1A0);
                    _sockCountDp = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03487038, 0x8, 0x6DC);
                    _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03487038, 0x8, 0x6E0);
                    _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x3488090, 0x8A8, 0x0);
                    GameVersion = Version.Revision603296;
                    IsHooked = true;
                    break;
                // Revision 603442
                case 58372096:
                    _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0331A650, 0x20, 0x1D0);
                    _sockCountDp = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03415DB8, 0x8, 0x6DC);
                    _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03415DB8, 0x8, 0x6E0);
                    _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03416E10, 0x8A8, 0x0);
                    GameVersion = Version.Revision603442;
                    IsHooked = true;
                    break;
                // Revision 603899
                case 58363904:
                    _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03319550, 0x20, 0x170);
                    _sockCountDp = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03166BE8, 0x8, 0x79C);
                    _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03166BE8, 0x8, 0x7A0);
                    _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03415D10, 0x8A8, 0x0);
                    GameVersion = Version.Revision603899;
                    IsHooked = true;
                    break;
                default:
                    GameVersion = Version.Unsupported;
                    IsHooked = false;
                    break;
            }
        }
    }
}