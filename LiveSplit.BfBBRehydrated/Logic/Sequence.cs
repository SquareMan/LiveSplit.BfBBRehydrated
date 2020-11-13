using System;
using System.Collections.Generic;
using LiveSplit.ComponentUtil;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public enum Sequence
    {
        Any,
        KelpForestPortOHead
    }

    public static class SequenceHelper
    {
        public static readonly Dictionary<Sequence, Tuple<Vector3f,Vector3f>> Bounds = new Dictionary<Sequence, Tuple<Vector3f, Vector3f>>
        {
            {Sequence.KelpForestPortOHead, new Tuple<Vector3f, Vector3f>(new Vector3f(-2969.986f,2207.844f,900f),new Vector3f(-2473.59f,2953.848f,1200f))}
        };
    }
}