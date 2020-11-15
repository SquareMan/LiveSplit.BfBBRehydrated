using System;
using System.Collections.Generic;

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
        public static readonly Dictionary<IndividualLevel, Tuple<Level, int, int>> LevelDictionary = new Dictionary<IndividualLevel, Tuple<Level, int, int>>
        {
            {IndividualLevel.JellyfishFields, Tuple.Create(Level.JellyfishRock, 8, 14)},
            {IndividualLevel.DowntownBikiniBottom, Tuple.Create(Level.DowntownStreets, 8, 9)},
            {IndividualLevel.GooLagoon, Tuple.Create(Level.GooLagoonBeach, 8, 11)},
            {IndividualLevel.Poseidome, Tuple.Create(Level.Poseidome, 1, 0)},
            {IndividualLevel.RockBottom, Tuple.Create(Level.RockBottomDowntown, 8, 9)},
            {IndividualLevel.Mermalair, Tuple.Create(Level.MermalairEntranceArea, 8, 4)},
            {IndividualLevel.SandMountain, Tuple.Create(Level.SandMountainHub, 8, 10)},
            {IndividualLevel.IndustrialPark, Tuple.Create(Level.IndustrialPark, 1, 0)},
            {IndividualLevel.KelpForest, Tuple.Create(Level.KelpForest, 8, 7)},
            {IndividualLevel.FlyingDutchmansGraveyard, Tuple.Create(Level.GraveyardLake, 8, 3)},
            {IndividualLevel.SpongebobsDream, Tuple.Create(Level.SpongebobsDream, 8, 5)}
        };
    }
}