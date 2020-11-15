using System;
using System.Collections.Generic;
using LiveSplit.ComponentUtil;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public enum IndividualLevel
    {
        JellyfishFields,
        DowntownBikiniBottom,
        GooLagoon,
        Poseidome,
        RockBottom,
        Mermalair,
        SandMountain,
        IndustrialPark,
        KelpForest,
        FlyingDutchmansGraveyard,
        SpongebobsDream
    }

    public static class IndividualLevelInformation
    {
        // Tuple contains Starting Level, Spatula Count, Sock Count
        public static readonly Dictionary<IndividualLevel, Tuple<Tuple<Vector3f, Vector3f>, int, int>>
            LevelDictionary = new Dictionary<IndividualLevel, Tuple<Tuple<Vector3f, Vector3f>, int, int>>
        {
            {
                IndividualLevel.JellyfishFields,
                Tuple.Create(Tuple.Create(new Vector3f(8200, 1300, 100), new Vector3f(9500, 2500, 800)), 8, 14)
            },
            {
                IndividualLevel.DowntownBikiniBottom,
                Tuple.Create(Tuple.Create(new Vector3f(11800, 610, 280), new Vector3f(12500, 1700, 800)), 8, 9)
            },
            {
                IndividualLevel.GooLagoon,
                Tuple.Create(Tuple.Create(new Vector3f(5100,-6000,240), new Vector3f(6500,-4700,800)),8, 11)
            },
            {
                IndividualLevel.Poseidome,
                Tuple.Create(Tuple.Create(new Vector3f(4000,-3300,180), new Vector3f(5000,-2000,800)),1, 0)
            },
            {
                IndividualLevel.RockBottom,
                Tuple.Create(Tuple.Create(new Vector3f(-2200,1200,750), new Vector3f(-800,2100,1300)),8, 9)
            },
            {
                IndividualLevel.Mermalair,
                Tuple.Create(Tuple.Create(new Vector3f(100,1450,80), new Vector3f(1100,2400,300)),8, 4)
            },
            {
                IndividualLevel.SandMountain,
                Tuple.Create(Tuple.Create(new Vector3f(-1700, -8000, 700), new Vector3f(-400, -7000, 1300)), 8, 10)
            },
            {
                IndividualLevel.IndustrialPark,
                Tuple.Create(Tuple.Create(new Vector3f(-5100, -2400, 750), new Vector3f(-4200, -1000, 1300)), 1, 0)
            },
            {
                IndividualLevel.KelpForest,
                Tuple.Create(Tuple.Create(new Vector3f(-12100,400,0), new Vector3f(-10800,1400,800)),8, 7)
            },
            {
                IndividualLevel.FlyingDutchmansGraveyard,
                Tuple.Create(Tuple.Create(new Vector3f(-11700, -5800, 0), new Vector3f(-10400, -4800, 600)), 8, 3)
            },
            {
                IndividualLevel.SpongebobsDream,
                Tuple.Create(Tuple.Create(new Vector3f(-11900, -3200, 0), new Vector3f(-10200, -1600, 700)), 8, 5)
            }
        };
    }
}