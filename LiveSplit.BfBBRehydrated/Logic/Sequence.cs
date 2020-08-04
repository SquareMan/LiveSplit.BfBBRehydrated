using System;
using System.Collections.Generic;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public enum Sequence
    {
        Any,
        KelpForestPortOHead
    }

    public static class SequenceHelper
    {
        public static readonly Dictionary<Sequence, Tuple<Location,Location>> Bounds = new Dictionary<Sequence, Tuple<Location, Location>>
        {
            {Sequence.KelpForestPortOHead, new Tuple<Location, Location>(new Location(-2969.986f,2207.844f,900f),new Location(-2473.59f,2953.848f,1200f))}
        };
    }
}