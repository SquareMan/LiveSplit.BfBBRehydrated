using System;
using LiveSplit.ComponentUtil;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public static class MathHelper
    {
        public static bool Intersects(Vector3f playerLocation, Vector3f cornerA, Vector3f cornerB)
        {
            return playerLocation.X > Math.Min(cornerA.X,cornerB.X) && playerLocation.X < Math.Max(cornerA.X,cornerB.X)
                && playerLocation.Y > Math.Min(cornerA.Y,cornerB.Y) && playerLocation.Y < Math.Max(cornerA.Y,cornerB.Y)
                && playerLocation.Z > Math.Min(cornerA.Z,cornerB.Z) && playerLocation.Z < Math.Max(cornerA.Z,cornerB.Z);
        }
    }
}