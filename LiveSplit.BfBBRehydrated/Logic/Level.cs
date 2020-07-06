using System.Collections.Generic;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public enum Level
    {
	    //For Splitting Logic
	    Any,
	    
	    // Menu
	    MainMenu,
	    IntroCutscene,
	    
	    // Bikini Bottom
	    BikiniBottom,
	    SpongebobHouse,
	    SquidwardHouse,
	    PatrickHouse,
	    Treedome,
	    ShadyShoals,
	    PoliceStation,
	    KrustyKrab,
	    ChumBucket,
	    Theater,
	    
	    // Hub Bosses
	    Poseidome,
	    IndustrialPark,

	    // Jellyfish Fields
	    JellyfishRock,
	    JellyfishCaves,
	    JellyfishLake,
	    JellyfishMountain,

	    // Downtown Bikini Bottom
	    DowntownStreets,
	    DowntownRooftops,
	    DowntownLighthouse,
	    DowntownSeaNeedle,
	    
	    // Goo Lagoon
	    GooLagoonBeach,
	    GooLagoonCaves,
	    GooLagoonPier,
	    
	    // Mermalair
	    MermalairEntranceArea,
	    MermalairMainChamber,
	    MermalairSecurityTunnel,
	    MermalairBallroom,
	    MermalairVillainContainment,
	    
	    // Rock Bottom
	    RockBottomDowntown,
	    RockBottomMuseum,
	    RockBottomTrench,
	    
	    // Sand Mountain
	    SandMountainHub,
	    SandMountainSlide1,
	    SandMountainSlide2,
	    SandMountainSlide3,
	    
	    // Kelp Forest
	    KelpForest,
	    KelpForestSwamps,
	    KelpForestCaves,
	    KelpForestSlide,
	    
	    // Flying Dutchman's Graveyard
	    GraveyardLake,
	    GraveyardShipwreck,
	    GraveyardShip,
	    GraveyardBoss,
	    
	    // Spongebob's Dream
	    SpongebobsDream,
	    SandysDream,
	    SquidwardsDream,
	    KrabsDream,
	    PatricksDream,
	    
	    //Chum Bucket Labs
	    ChumBucketLab,
	    ChumBucketBrain,
	    
	    //Endgame
	    SpongeballArena
    }

    public static class MapsHelper
    {
        public static readonly Dictionary<string, Level> Paths = new Dictionary<string, Level>()
        {
	        {"/Game/Maps/MainMenu/MainMenu_P", Level.MainMenu},
	        {"/Game/Maps/IntroCutscene/IntroCutscene_P", Level.IntroCutscene},
	        
	        {"/Game/Maps/BikiniBottom/BikiniBottom_P", Level.BikiniBottom},
	        {"/Game/Maps/BikiniBottom/SpongeBobHouse/SpongeBobHouse_P", Level.SpongebobHouse},
	        {"/Game/Maps/BikiniBottom/SquidwardHouse/SquidwardHouse_P", Level.SquidwardHouse},
	        {"/Game/Maps/BikiniBottom/PatrickHouse/PatrickHouse_P", Level.PatrickHouse},
	        {"/Game/Maps/BikiniBottom/RestHome/RestHome_P", Level.ShadyShoals},
	        {"/Game/Maps/BikiniBottom/PoliceStation/PoliceStation_P", Level.PoliceStation},
	        {"/Game/Maps/BikiniBottom/SandyHouse/SandyHouse_P", Level.Treedome},
	        {"/Game/Maps/BikiniBottom/KrustyKrab/KrustyKrab_P", Level.KrustyKrab},
	        {"/Game/Maps/BikiniBottom/ChumBucket/ChumBucket_P", Level.ChumBucket},
	        {"/Game/Maps/BikiniBottom/Theater/Theater_P", Level.Theater},

	        {"/Game/Maps/Poseidome/Poseidome_01_P", Level.Poseidome},
	        {"/Game/Maps/IndustrialPark/IndustrialPark_01_P", Level.IndustrialPark},

	        {"/Game/Maps/JellyfishFields/Part1/JellyfishFields_01_P", Level.JellyfishRock},
			{"/Game/Maps/JellyfishFields/Part2/JellyfishFields_02_P", Level.JellyfishCaves},
			{"/Game/Maps/JellyfishFields/Part3/JellyfishFields_03_P", Level.JellyfishLake},
			{"/Game/Maps/JellyfishFields/Part4/JellyfishFields_04_P", Level.JellyfishMountain},
			
			{"/Game/Maps/DownTownBikiniBottom/Part1/DownTownBikiniBottom_01_P", Level.DowntownStreets},
			{"/Game/Maps/DownTownBikiniBottom/Part2/DownTownBikiniBottom_02_P", Level.DowntownRooftops},
			{"/Game/Maps/DownTownBikiniBottom/Part3/DownTownBikiniBottom_03_P", Level.DowntownLighthouse},
			{"/Game/Maps/DownTownBikiniBottom/Part4/DownTownBikiniBottom_04_P", Level.DowntownSeaNeedle},
			
			{"/Game/Maps/GooLagoon/Part1/GooLagoon_01_P", Level.GooLagoonBeach},
			{"/Game/Maps/GooLagoon/Part2/GooLagoon_02_P", Level.GooLagoonCaves},
			{"/Game/Maps/GooLagoon/Part3/GooLagoon_03_P", Level.GooLagoonPier},
			
			{"/Game/Maps/Mermalair/Part1/Mermalair_01_P", Level.MermalairEntranceArea},
			{"/Game/Maps/Mermalair/Part2/Mermalair_02_P", Level.MermalairMainChamber},
			{"/Game/Maps/Mermalair/Part3/Mermalair_03_P", Level.MermalairSecurityTunnel},
			{"/Game/Maps/Mermalair/Part4/Mermalair_04_P", Level.MermalairBallroom},
			{"/Game/Maps/Mermalair/Part5/Mermalair_05_P", Level.MermalairVillainContainment},
			
			{"/Game/Maps/RockBottom/Part1/RockBottom_01_P", Level.RockBottomDowntown},
			{"/Game/Maps/RockBottom/Part1/RockBottom_02_P", Level.RockBottomMuseum},
			{"/Game/Maps/RockBottom/Part1/RockBottom_03_P", Level.RockBottomTrench},
			
			{"/Game/Maps/SandMountain/Part1/SandMountain_01_P", Level.SandMountainHub},
			{"/Game/Maps/SandMountain/Part2/SandMountain_02_P", Level.SandMountainSlide1},
			{"/Game/Maps/SandMountain/Part3/SandMountain_03_P", Level.SandMountainSlide2},
			{"/Game/Maps/SandMountain/Part4/SandMountain_04_P", Level.SandMountainSlide3},
			
			{"/Game/Maps/KelpForest/Part1/KelpForest_01_P", Level.KelpForest},
			{"/Game/Maps/KelpForest/Part1/KelpForest_02_P", Level.KelpForestSwamps},
			{"/Game/Maps/KelpForest/Part1/KelpForest_03_P", Level.KelpForestCaves},
			{"/Game/Maps/KelpForest/Part1/KelpForest_04_P", Level.KelpForestSlide},
			
			{"/Game/Maps/DutchmanGraveyard/Part1/DutchmanGraveyard_01_P", Level.GraveyardLake},
			{"/Game/Maps/DutchmanGraveyard/Part2/DutchmanGraveyard_02_P", Level.GraveyardShipwreck},
			{"/Game/Maps/DutchmanGraveyard/Part3/DutchmanGraveyard_03_P", Level.GraveyardShip},
			{"/Game/Maps/DutchmanGraveyard/Part4/DutchmanGraveyard_04_P", Level.GraveyardBoss},
			
			{"/Game/Maps/SpongeBobDream/Part1/SpongeBobDream_01_P", Level.SpongebobsDream},
			{"/Game/Maps/SpongeBobDream/Part2/SpongeBobDream_02_P", Level.SandysDream},
			{"/Game/Maps/SpongeBobDream/Part3/SpongeBobDream_03_P", Level.SquidwardsDream},
			{"/Game/Maps/SpongeBobDream/Part4/SpongeBobDream_04_P", Level.KrabsDream},
			{"/Game/Maps/SpongeBobDream/Part6/SpongeBobDream_06_P", Level.PatricksDream},
			
			{"/Game/Maps/ChumBucketLab/Part2/ChumBucketLab_02_P", Level.ChumBucketLab},
			{"/Game/Maps/ChumBucketLab/Part3/ChumBucketLab_03_P", Level.ChumBucketBrain},
			
			{"/Game/Maps/SkatePark/SkatePark_01_P", Level.SpongeballArena}
        };
    }
}