﻿using System.Diagnostics;
using System.Linq;
using LiveSplit.ComponentUtil;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public static class Memory
    {
        public struct MemoryState
        {
            public bool IsLoading;
            public int SpatulaCount;
            public Level Level;
        }

        public enum Version
        {
            Revision603296 = 603296,
            Revision603442 = 603442
        }
        
        public static Version GameVersion { get; private set; }
        
        public static bool IsLoading => IsHooked && _isLoadingDP.Deref<bool>(Game);
        private static DeepPointer _isLoadingDP;
        
        public static int SpatulaCount => IsHooked ? _spatulaCountDP.Deref<int>(Game) : 0;
        private static DeepPointer _spatulaCountDP;
        
        public static Level CurrentLevel => IsHooked ? MapsHelper.Paths[_currentLevelDP.DerefString(Game, 150)] : Level.Any;
        private static DeepPointer _currentLevelDP;
        
        public static Process Game { get; private set; }
        public static bool IsHooked { get; private set; }

        /// <summary>
        /// Create a snapshot of the current memory values
        /// </summary>
        /// <returns></returns>
        public static MemoryState GetState()
        {
            return new MemoryState() {IsLoading = IsLoading, SpatulaCount = SpatulaCount, Level = CurrentLevel};
        }
        
        /// <summary>
        /// Attempt to hook the game process (if not already hooked)
        /// </summary>
        public static void HookProcess()
        {
            IsHooked = Game != null && !Game.HasExited;
            if (!IsHooked)
            {
                Process[] processes = Process.GetProcessesByName("Pineapple-Win64-Shipping");
                
                if (processes.Length <= 0)
                    return;
                
                Game = processes.First();
                
                //Determine Game Version
                int moduleMemorySize = Game.MainModule.ModuleMemorySize;
                switch (moduleMemorySize)
                {
                    //Revision 603296
                    case 58867712:
                        _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0338B8D0, 0x20, 0x1A0);
                        _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03487038, 0x8, 0x6E0);
                        _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x3488090, 0x8A8, 0x0);
                        GameVersion = Version.Revision603296;
                        break;
                    //Revision 603442
                    case 58372096:
                        _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0331A650, 0x20, 0x1D0);
                        _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03415DB8, 0x8, 0x6E0);
                        _currentLevelDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03416E10, 0x8A8, 0x0);
                        GameVersion = Version.Revision603442;
                        break;
                }
                
                IsHooked = true;
            }
        }
    }
}