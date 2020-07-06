using System.Collections.Generic;

namespace LiveSplit.BfBBRehydrated.Logic
{
    public enum Map
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
        public static readonly Dictionary<string, Map> Paths = new Dictionary<string, Map>()
        {
	        {"/Game/Maps/MainMenu/MainMenu_P", Map.MainMenu},
	        {"/Game/Maps/IntroCutscene/IntroCutscene_P", Map.IntroCutscene},
	        
	        {"/Game/Maps/BikiniBottom/BikiniBottom_P", Map.BikiniBottom},
	        {"/Game/Maps/BikiniBottom/SpongeBobHouse/SpongeBobHouse_P", Map.SpongebobHouse},
	        {"/Game/Maps/BikiniBottom/SquidwardHouse/SquidwardHouse_P", Map.SquidwardHouse},
	        {"/Game/Maps/BikiniBottom/PatrickHouse/PatrickHouse_P", Map.PatrickHouse},
	        {"/Game/Maps/BikiniBottom/RestHome/RestHome_P", Map.ShadyShoals},
	        {"/Game/Maps/BikiniBottom/PoliceStation/PoliceStation_P", Map.PoliceStation},
	        {"/Game/Maps/BikiniBottom/SandyHouse/SandyHouse_P", Map.Treedome},
	        {"/Game/Maps/BikiniBottom/KrustyKrab/KrustyKrab_P", Map.KrustyKrab},
	        {"/Game/Maps/BikiniBottom/ChumBucket/ChumBucket_P", Map.ChumBucket},
	        {"/Game/Maps/BikiniBottom/Theater/Theater_P", Map.Theater},

	        {"/Game/Maps/Poseidome/Poseidome_01_P", Map.Poseidome},
	        {"/Game/Maps/IndustrialPark/IndustrialPark_01_P", Map.IndustrialPark},

	        {"/Game/Maps/JellyfishFields/Part1/JellyfishFields_01_P", Map.JellyfishRock},
			{"/Game/Maps/JellyfishFields/Part2/JellyfishFields_02_P", Map.JellyfishCaves},
			{"/Game/Maps/JellyfishFields/Part3/JellyfishFields_03_P", Map.JellyfishLake},
			{"/Game/Maps/JellyfishFields/Part4/JellyfishFields_04_P", Map.JellyfishMountain},
			
			{"/Game/Maps/DownTownBikiniBottom/Part1/DownTownBikiniBottom_01_P", Map.DowntownStreets},
			{"/Game/Maps/DownTownBikiniBottom/Part2/DownTownBikiniBottom_02_P", Map.DowntownRooftops},
			{"/Game/Maps/DownTownBikiniBottom/Part3/DownTownBikiniBottom_03_P", Map.DowntownLighthouse},
			{"/Game/Maps/DownTownBikiniBottom/Part4/DownTownBikiniBottom_04_P", Map.DowntownSeaNeedle},
			
			{"/Game/Maps/GooLagoon/Part1/GooLagoon_01_P", Map.GooLagoonBeach},
			{"/Game/Maps/GooLagoon/Part2/GooLagoon_02_P", Map.GooLagoonCaves},
			{"/Game/Maps/GooLagoon/Part3/GooLagoon_03_P", Map.GooLagoonPier},
			
			{"/Game/Maps/Mermalair/Part1/Mermalair_01_P", Map.MermalairEntranceArea},
			{"/Game/Maps/Mermalair/Part2/Mermalair_02_P", Map.MermalairMainChamber},
			{"/Game/Maps/Mermalair/Part3/Mermalair_03_P", Map.MermalairSecurityTunnel},
			{"/Game/Maps/Mermalair/Part4/Mermalair_04_P", Map.MermalairBallroom},
			{"/Game/Maps/Mermalair/Part5/Mermalair_05_P", Map.MermalairVillainContainment},
			
			{"/Game/Maps/RockBottom/Part1/RockBottom_01_P", Map.RockBottomDowntown},
			{"/Game/Maps/RockBottom/Part1/RockBottom_02_P", Map.RockBottomMuseum},
			{"/Game/Maps/RockBottom/Part1/RockBottom_03_P", Map.RockBottomTrench},
			
			{"/Game/Maps/SandMountain/Part1/SandMountain_01_P", Map.SandMountainHub},
			{"/Game/Maps/SandMountain/Part2/SandMountain_02_P", Map.SandMountainSlide1},
			{"/Game/Maps/SandMountain/Part3/SandMountain_03_P", Map.SandMountainSlide2},
			{"/Game/Maps/SandMountain/Part4/SandMountain_04_P", Map.SandMountainSlide3},
			
			{"/Game/Maps/KelpForest/Part1/KelpForest_01_P", Map.KelpForest},
			{"/Game/Maps/KelpForest/Part1/KelpForest_02_P", Map.KelpForestSwamps},
			{"/Game/Maps/KelpForest/Part1/KelpForest_03_P", Map.KelpForestCaves},
			{"/Game/Maps/KelpForest/Part1/KelpForest_04_P", Map.KelpForestSlide},
			
			{"/Game/Maps/DutchmanGraveyard/Part1/DutchmanGraveyard_01_P", Map.GraveyardLake},
			{"/Game/Maps/DutchmanGraveyard/Part2/DutchmanGraveyard_02_P", Map.GraveyardShipwreck},
			{"/Game/Maps/DutchmanGraveyard/Part3/DutchmanGraveyard_03_P", Map.GraveyardShip},
			{"/Game/Maps/DutchmanGraveyard/Part4/DutchmanGraveyard_04_P", Map.GraveyardBoss},
			
			{"/Game/Maps/SpongeBobDream/Part1/SpongeBobDream_01_P", Map.SpongebobsDream},
			{"/Game/Maps/SpongeBobDream/Part2/SpongeBobDream_02_P", Map.SandysDream},
			{"/Game/Maps/SpongeBobDream/Part3/SpongeBobDream_03_P", Map.SquidwardsDream},
			{"/Game/Maps/SpongeBobDream/Part4/SpongeBobDream_04_P", Map.KrabsDream},
			{"/Game/Maps/SpongeBobDream/Part6/SpongeBobDream_06_P", Map.PatricksDream},
			
			{"/Game/Maps/ChumBucketLab/Part2/ChumBucketLab_02_P", Map.ChumBucketLab},
			{"/Game/Maps/ChumBucketLab/Part3/ChumBucketLab_03_P", Map.ChumBucketBrain},
			
			{"/Game/Maps/SkatePark/SkatePark_01_P", Map.SpongeballArena}
        };
    }
}