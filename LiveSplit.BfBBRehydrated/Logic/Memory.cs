using System.Diagnostics;
using System.Linq;
using LiveSplit.ComponentUtil;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public static class Memory
    {
        public static bool IsLoading => IsHooked && _isLoadingDP.Deref<bool>(Game);
        private static readonly DeepPointer _isLoadingDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x0331A650, 0x20, 0x1D0);
        
        public static int SpatulaCount => IsHooked ? _spatulaCountDP.Deref<int>(Game) : 0;
        private static readonly DeepPointer _spatulaCountDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03415DB8, 0x8, 0x6E0);
        
        public static string CurrentMap => IsHooked ? _currentMapDP.DerefString(Game, 150) : "";
        private static readonly DeepPointer _currentMapDP = new DeepPointer("Pineapple-Win64-Shipping.exe", 0x03416E10, 0x8A8, 0x0);
        
        public static Process Game { get; private set; }
        public static bool IsHooked { get; private set; }
        
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
                IsHooked = true;
            }
        }
    }
}