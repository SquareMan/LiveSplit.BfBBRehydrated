﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LiveSplit.ComponentUtil;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public static class Memory
    {
        public struct MemoryState
        {
            public bool IsLoading;
            public bool IsPaused;
            public bool IsCutsceneActive;
            public bool IsInteracting;
            public int SockCount;
            public int SpatulaCount;
            public Level Level;
        }

        public enum Version
        {
            Unsupported = 0,
            Revision600294 = 600294,
            Revision603296 = 603296,
            Revision603442 = 603442,
            Revision603899 = 603899,
            Revision604909 = 604909,
            Revision611616 = 611616
        }
        
        public static Version GameVersion { get; private set; }
        
        public static bool IsLoading => IsHooked && _isLoadingDP != null && _isLoadingDP.Deref<bool>(Game);
        public static bool IsPaused => IsHooked && _isPausedDP != null && _isPausedDP.Deref<bool>(Game);
        public static bool IsCutsceneActive => IsHooked && _isCutsceneActiveDP != null && _isCutsceneActiveDP.Deref<bool>(Game);
        public static bool IsInteracting => IsHooked && _isInteractingDP != null && _isInteractingDP.Deref<bool>(Game);
        public static int SockCount => IsHooked && _sockCountDp != null ? _sockCountDp.Deref<int>(Game) : 0;
        public static int SpatulaCount => IsHooked && _spatulaCountDP != null ? _spatulaCountDP.Deref<int>(Game) : 0;
        public static Level CurrentLevel
        {
            get
            {
                if (!IsHooked || _currentLevelDP == null)
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
        public static Vector3f PlayerLocation => IsHooked && _playerLocationDP != null ? _playerLocationDP.Deref<Vector3f>(Game) : default;

        private static DeepPointer _isLoadingDP;
        private static DeepPointer _isPausedDP;
        private static DeepPointer _isCutsceneActiveDP;
        private static DeepPointer _isInteractingDP;
        private static DeepPointer _sockCountDp;
        private static DeepPointer _spatulaCountDP;
        private static DeepPointer _currentLevelDP;
        private static DeepPointer _playerLocationDP;
        
        public static Process Game { get; private set; }
        public static bool IsHooked { get; private set; }

        private static readonly Dictionary<Version, string> _signatures = new Dictionary<Version, string>()
        {
            {Version.Revision600294, "8865??????7F00000B002800??????0000??????????0000A9FF2A0000000000????????????0000????????????000000020000"},
            {Version.Revision603296, "E805??????7F00000B002800??????0000??????????00003EAC290000000000????????????0000????????????000000020000"},
            {Version.Revision603442, "B8B7??????7F00000B002800??????0000??????????00001FA0290000000000????????????0000????????????000000020000"},
            {Version.Revision603899, "78A4??????7F00000B002800??????0000??????????00001FA0290000000000????????????0000????????????000000020000"},
            {Version.Revision604909, "48DD??????7F00000B002800??????0000??????????000062AD290000000000????????????0000????????????000000020000"},
            {Version.Revision611616, "A838??????7F00000B002800??????0000??????????0000359F2C0000000000????????????0000????????????000000020000"}
        };
        
        private static Task _scanTask;
        private const double HookAttemptDelay = 1.0;
        private static DateTime _nextHookAttemptTime;

        /// <summary>
        /// Create a snapshot of the current memory values
        /// </summary>
        /// <returns></returns>
        public static MemoryState GetState()
        {
            return new MemoryState()
            {
                IsLoading = IsLoading,
                IsPaused = IsPaused,
                IsCutsceneActive = IsCutsceneActive,
                IsInteracting = IsInteracting,
                SockCount = SockCount,
                SpatulaCount = SpatulaCount,
                Level = CurrentLevel
            };
        }
        
        /// <summary>
        /// Attempt to hook the game process (if not already hooked)
        /// </summary>
        public static void HookProcess()
        {
            if (Game != null)
            {
                // Delay Scan for the SoundCue that indicates interaction until the first loading screen to ensure it exists.
                if (_isInteractingDP == null && _scanTask == null && IsLoading)
                {
                    _scanTask = Task.Run(() =>
                    {
                        ScanIsInteracting(_signatures[GameVersion]);
                        _scanTask = null;
                    });
                }
                
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

            Game = Process.GetProcessesByName("Pineapple-Win64-Shipping").FirstOrDefault();

            if (Game?.MainModule == null)
                return;

            // Determine Game Version
            int moduleMemorySize = Game.MainModule.ModuleMemorySize;
            switch (moduleMemorySize)
            {
                // Revision 600294
                case 58716160:
                    _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0336DA90, 0x20, 0x170);
                    _isPausedDP = new DeepPointer("Pineapple-Win64-Shipping.exe",0x0346A250, 0x8A0);
                    _isCutsceneActiveDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0346A250, 0xDC0, 0x628, 0x38);
                    _sockCountDp = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0346A250, 0xDC0, 0x6BC);
                    _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0346A250, 0xDC0, 0x6C0);
                    _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0346A250, 0x8A8, 0x0);
                    _playerLocationDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0346A250, 0xDC0, 0x38, 0x0,
                        0x30, 0x270, 0x158, 0x1D0);
                    GameVersion = Version.Revision600294;
                    IsHooked = true;
                    break;
                // Revision 603296
                case 58867712:
                    _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0338B8D0, 0x20, 0x1A0);
                    _isPausedDP = new DeepPointer("Pineapple-Win64-Shipping.exe",0x03488090, 0x8A0);
                    _isCutsceneActiveDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x031D7808, 0x8, 0x608, 0x38);
                    _sockCountDp = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03487038, 0x8, 0x6DC);
                    _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03487038, 0x8, 0x6E0);
                    _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x3488090, 0x8A8, 0x0);
                    _playerLocationDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03487F90, 0x8, 0x58, 0x98, 0x158, 0x1D0);
                    GameVersion = Version.Revision603296;
                    IsHooked = true;
                    break;
                // Revision 603442
                case 58372096:
                    _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0331A650, 0x20, 0x1D0);
                    _isPausedDP = new DeepPointer("Pineapple-Win64-Shipping.exe",0x03416E10, 0x8A0);
                    _isCutsceneActiveDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03167CB8, 0x8, 0x608, 0x38);
                    _sockCountDp = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03415DB8, 0x8, 0x6DC);
                    _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03415DB8, 0x8, 0x6E0);
                    _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03416E10, 0x8A8, 0x0);
                    _playerLocationDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03416D10, 0x8, 0x58, 0x98, 0x158, 0x1D0);
                    GameVersion = Version.Revision603442;
                    IsHooked = true;
                    break;
                // Revision 603899
                case 58363904:
                    _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03319550, 0x20, 0x170);
                    _isPausedDP = new DeepPointer("Pineapple-Win64-Shipping.exe",0x03415D10, 0x8A0);
                    _isCutsceneActiveDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03166BE8, 0x8, 0x608, 0x38);
                    _sockCountDp = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03166BE8, 0x8, 0x79C);
                    _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03166BE8, 0x8, 0x7A0);
                    _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03415D10, 0x8A8, 0x0);
                    _playerLocationDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03415C10, 0x8, 0x58, 0x98, 0x158, 0x1D0);
                    GameVersion = Version.Revision603899;
                    IsHooked = true;
                    break;
                // Revision 604909
                case 58458112:
                    _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0332E250, 0x20, 0x1A0);
                    _isPausedDP = new DeepPointer("Pineapple-Win64-Shipping.exe",0x0342AA10, 0x8A0);
                    _isCutsceneActiveDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0317B4B8, 0x8, 0x608, 0x38);
                    _sockCountDp = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x317B4B8, 0x8, 0x79C);
                    _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x317B4B8, 0x8, 0x7A0);
                    _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0342AA10, 0x8A8, 0x0);
                    _playerLocationDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0342A910, 0x8, 0x58, 0x98, 0x158, 0x1D0);
                    GameVersion = Version.Revision604909;
                    IsHooked = true;
                    break;
                // Revision 611616
                case 58404864:
                    _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03321F10, 0x20, 0x170);
                    _isPausedDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0341E6E0, 0x8A0);
                    _isCutsceneActiveDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0341E6E0, 0xDC0, 0x618, 0x38);
                    _sockCountDp = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0341E6E0, 0xDC0, 0x7AC);
                    _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0341E6E0, 0xDC0, 0x7B0);
                    _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0341E6E0, 0x8A8, 0x0);
                    _playerLocationDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0341E6E0, 0xDC0, 0x38, 0x0,
                        0x30, 0x270, 0x158, 0x1D0);
                    GameVersion = Version.Revision611616;
                    IsHooked = true;
                    break;
                default:
                    GameVersion = Version.Unsupported;
                    IsHooked = false;
                    break;
            }
        }

        private static void ScanIsInteracting(string signature)
        {
            var target = new SigScanTarget(0x34, signature);
            foreach (var page in Game.MemoryPages())
            {
                var scanner = new SignatureScanner(Game, page.BaseAddress, (int)page.RegionSize);
                var ptr = scanner.Scan(target);

                if (ptr == IntPtr.Zero) continue;
                _isInteractingDP = new DeepPointer(ptr);
                return;
            }
            
        }
    }
}