using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Game.GameData;

namespace SimpleBot.Extensions
{
    [SuppressMessage("ReSharper", "UnassignedReadonlyField")]
    public static class MapNames
    {
        [AreaId("MapLeaguePortal")]
        public static readonly string TheRealmgate;

        [AreaId("MapVoidReliquary")]
        public static readonly string TheReliquaryVault;

        [AreaId("MapSpiderJungle")]
        public static readonly string SpiderJungle;

        [AreaId("MapRustbowl")]
        public static readonly string Rustbowl;

        [AreaId("MapBackwash")]
        public static readonly string Backwash;

        [AreaId("MapBurialBog")]
        public static readonly string BurialBog;

        [AreaId("MapInferno")]
        public static readonly string Inferno;

        [AreaId("MapWetlands")]
        public static readonly string Wetlands;

        [AreaId("MapBloomingField")]
        public static readonly string BloomingField;

        [AreaId("MapCrimsonShores")]
        public static readonly string CrimsonShores;

        [AreaId("MapCenotes")]
        public static readonly string Cenotes;

        [AreaId("MapSavanna")]
        public static readonly string Savannah;

        [AreaId("MapFortress")]
        public static readonly string Fortress;

        [AreaId("MapPenitentiary")]
        public static readonly string Penitentiary;

        [AreaId("MapLostTowers")]
        public static readonly string LostTowers;

        [AreaId("MapBloodwood")]
        public static readonly string Bloodwood;

        [AreaId("MapSandspit")]
        public static readonly string Sandspit;

        [AreaId("MapForge")]
        public static readonly string Forge;

        [AreaId("MapSulphuricCaverns")]
        public static readonly string SulphuricCaverns;

        [AreaId("MapMire")]
        public static readonly string Mire;

        [AreaId("MapAugury")]
        public static readonly string Augury;

        [AreaId("MapWoodland")]
        public static readonly string Woodland;

        [AreaId("MapSump")]
        public static readonly string Sump;

        [AreaId("MapWillow")]
        public static readonly string Willow;

        [AreaId("MapHive")]
        public static readonly string Hive;

        [AreaId("MapHeadland")]
        public static readonly string Headland;

        [AreaId("MapLoftySummit")]
        public static readonly string LoftySummit;

        [AreaId("MapNecropolis")]
        public static readonly string Necropolis;

        [AreaId("MapCrypt")]
        public static readonly string Crypt;

        [AreaId("MapHiddenGrotto")]
        public static readonly string HiddenGrotto;

        [AreaId("MapSteamingSprings")]
        public static readonly string SteamingSprings;

        [AreaId("MapSeepage")]
        public static readonly string Seepage;

        [AreaId("MapRiverside")]
        public static readonly string Riverside;

        [AreaId("MapRavine")]
        public static readonly string Ravine;

        [AreaId("MapSpiderWoods")]
        public static readonly string SpiderWoods;

        [AreaId("MapMarrow")]
        public static readonly string Marrow;

        [AreaId("MapGrimhaven")]
        public static readonly string Grimhaven;

        [AreaId("MapVaalVillage")]
        public static readonly string VaalVillage;

        [AreaId("MapVaalOutskirts")]
        public static readonly string VaalOutskirts;

        [AreaId("MapSlick")]
        public static readonly string Slick;

        [AreaId("MapVaalCity")]
        public static readonly string VaalCity;

        [AreaId("MapSteppe")]
        public static readonly string Steppe;

        [AreaId("MapSwampTower")]
        public static readonly string SinkingSpire;

        [AreaId("MapRockpools")]
        public static readonly string Rockpools;

        [AreaId("MapCreek")]
        public static readonly string Creek;

        [AreaId("MapDerelictMansion")]
        public static readonly string DerelictMansion;

        [AreaId("MapOutlands")]
        public static readonly string Outlands;

        [AreaId("MapBastille")]
        public static readonly string Bastille;

        [AreaId("MapDecay")]
        public static readonly string Decay;

        [AreaId("MapMineshaft")]
        public static readonly string Mineshaft;

        [AreaId("MapDeserted")]
        public static readonly string Deserted;

        [AreaId("MapOasis")]
        public static readonly string Oasis;

        [AreaId("MapBastion")]
        public static readonly string Bastion;

        [AreaId("MapRefuge")]
        public static readonly string Refuge;

        [AreaId("MapAlpineRidge")]
        public static readonly string AlpineRidge;

        [AreaId("MapSunTemple")]
        public static readonly string SunTemple;

        [AreaId("MapChannel")]
        public static readonly string Channel;

        [AreaId("MapVaalFoundry")]
        public static readonly string MoltenVault;

        [AreaId("MapVaalFactory")]
        public static readonly string TheAssembly;

        [AreaId("MapMesa")]
        public static readonly string Mesa;

        [AreaId("MapBluff")]
        public static readonly string Bluff;

        [AreaId("MapPerch")]
        public static readonly string Perch;

        [AreaId("MapKarst")]
        public static readonly string Karst;

        [AreaId("MapTerrace")]
        public static readonly string Terrace;

        [AreaId("MapPlantation")]
        public static readonly string Plantation;

        [AreaId("MapAzmerianRanges")]
        public static readonly string AzmerianRanges;

        [AreaId("MapEpitaph")]
        public static readonly string Epitaph;

        [AreaId("MapRupture")]
        public static readonly string Rupture;

        [AreaId("MapOvergrown")]
        public static readonly string Overgrown;

        [AreaId("MapCaldera")]
        public static readonly string Caldera;

        [AreaId("MapChasm")]
        public static readonly string Chasm;

        [AreaId("MapSpring")]
        public static readonly string Spring;

        [AreaId("MapSevenWaters")]
        public static readonly string Confluence;

        [AreaId("MapCavernCity")]
        public static readonly string SacredReservoir;

        [AreaId("MapTrenches")]
        public static readonly string Trenches;

        [AreaId("MapFrozenFalls")]
        public static readonly string FrozenFalls;

        [AreaId("MapWaywardIsle")]
        public static readonly string WaywardIsle;

        [AreaId("MapStronghold")]
        public static readonly string Stronghold;

        [AreaId("MapCrag")]
        public static readonly string Crag;

        [AreaId("MapQimar")]
        public static readonly string Qimar;

        [AreaId("MapDryPassage")]
        public static readonly string DryPassage;

        [AreaId("MapPort")]
        public static readonly string Port;

        [AreaId("MapBoulevard")]
        public static readonly string Boulevard;

        [AreaId("MapCliffside")]
        public static readonly string Cliffside;

        [AreaId("MapSinkhole")]
        public static readonly string Sinkhole;

        [AreaId("MapFlotsam")]
        public static readonly string Flotsam;

        [AreaId("MapUniqueUntaintedParadise")]
        public static readonly string UntaintedParadise;

        [AreaId("MapUniqueVault")]
        public static readonly string VaultsofKamasa;

        [AreaId("MapUniqueCastaway")]
        public static readonly string Castaway;

        [AreaId("MapUniqueMegalith")]
        public static readonly string TheEzomyteMegaliths;

        [AreaId("MapUniqueLake")]
        public static readonly string TheFracturedLake;

        [AreaId("MapUniqueSelenite")]
        public static readonly string TheSilentCave;

        [AreaId("MapUniqueMerchant01_Chimeral")]
        public static readonly string MerchantsCampsite;

        //[AreaId("MapUniqueMerchant01_Oasis")]
        //public static readonly string MerchantsCampsite;

        //[AreaId("MapUniqueMerchant01_Sandswept")]
        //public static readonly string MerchantsCampsite;

        //[AreaId("MapUniqueMerchant02_Crimson")]
        //public static readonly string MerchantsCampsite;

        //[AreaId("MapUniqueMerchant02_Farmland")]
        //public static readonly string MerchantsCampsite;

        //[AreaId("MapUniqueMerchant02_Riverbank")]
        //public static readonly string MerchantsCampsite;

        [AreaId("MapUniqueMerchant03_Beach")]
        public static readonly string MomentofZen;

        //[AreaId("MapUniqueMerchant03_Tropical")]
        //public static readonly string MomentofZen;

        //[AreaId("MapUniqueMerchant03_Raft")]
        //public static readonly string MomentofZen;

        [AreaId("MapUniqueMerchant04_PirateShip")]
        public static readonly string TheVoyage;

        [AreaId("MapUniqueWildwood")]
        public static readonly string TheViridianWildwood;

        [AreaId("MapUniqueFreight")]
        public static readonly string Freight;

        [AreaId("MapUberBoss_IronCitadel")]
        public static readonly string TheIronCitadel;

        [AreaId("MapUberBoss_CopperCitadel")]
        public static readonly string TheCopperCitadel;

        [AreaId("MapUberBoss_StoneCitadel")]
        public static readonly string TheStoneCitadel;

        [AreaId("MapUberBoss_JadeCitadel")]
        public static readonly string TheJadeIsles;

        [AreaId("MapUberBoss_Monolith")]
        public static readonly string TheBurningMonolith;

        [AreaId("MapHideoutFelled_Claimable")]
        public static readonly string FelledHideout;

        [AreaId("MapHideoutLimestone_Claimable")]
        public static readonly string LimestoneHideout;

        [AreaId("MapHideoutShrine_Claimable")]
        public static readonly string ShrineHideout;

        [AreaId("MapHideoutCanal_Claimable")]
        public static readonly string CanalHideout;

        [AreaId("ExpeditionLogBook_Peninsula")]
        public static readonly string CraggyPeninsula;

        [AreaId("ExpeditionLogBook_Tropical")]
        public static readonly string LushIsle;

        [AreaId("ExpeditionLogBook_Tundra")]
        public static readonly string FrigidBluffs;

        [AreaId("ExpeditionLogBook_Atoll")]
        public static readonly string BarrenAtoll;

        [AreaId("ExpeditionLogBook_Digsite")]
        public static readonly string AbandonedExcavation;

        //[AreaId("ExpeditionLogBook_Causeway")]
        //public static readonly string DNT-UNUSEDBasaltCoast;

        [AreaId("ExpeditionSubArea_Cavern")]
        public static readonly string SmugglersDen;

        [AreaId("ExpeditionSubArea_Kalguur")]
        public static readonly string KalguuranTomb;

        //[AreaId("ExpeditionSubArea_OlrothBoss")]
        //public static readonly string KalguuranTomb;

        //[AreaId("ExpeditionSubArea_UhtredBoss")]
        //public static readonly string KalguuranTomb;

        [AreaId("ExpeditionSubArea_Shrike")]
        public static readonly string RancidNest;

        [AreaId("ExpeditionSubArea_Siren")]
        public static readonly string HiddenAquifer;

        [AreaId("ExpeditionSubArea_Volcano")]
        public static readonly string SulphurMines;

        //[AreaId("ExpeditionLeagueBoss")]
        //public static readonly string KalguuranTomb;

        [AreaId("Delirium_Act1Town")]
        public static readonly string ClearfellLumbermill;

        [AreaId("Delirium_Act3Town")]
        public static readonly string SunkenPyramid;

        [AreaId("BreachDomain_01")]
        public static readonly string TwistedDomain;

        [AreaId("RitualLeagueBoss")]
        public static readonly string CruxofNothingness;

        [AreaId("Abyss_Intro")]
        public static readonly string LightlessPassage;

        [AreaId("Abyss_Hub")]
        public static readonly string TheWellofSouls;

        [AreaId("Abyss_Depths1")]
        public static readonly string AbyssalDepths;

        //[AreaId("Abyss_Depths2")]
        //public static readonly string AbyssalDepths;

        //[AreaId("Abyss_Depths3")]
        //public static readonly string AbyssalDepths;

        [AreaId("Abyss_Boss1")]
        public static readonly string LightlessVoid;

        [AreaId("Abyss_Boss2")]
        public static readonly string DarkDomain;

        [AreaId("Abyss_Pinnacle")]
        public static readonly string TheBlackCathedral;

        [AreaId("KaruiBossShowcase")]
        public static readonly string KaruiBossShowcase;

        [AreaId("BossRush_Area1")]
        public static readonly string BossRushArea1;

        [AreaId("BossRush_Area2")]
        public static readonly string BossRushArea2;

        [AreaId("BossRush_Area3")]
        public static readonly string BossRushArea3;

        [AreaId("G_Endgame_Town")]
        public static readonly string TheZigguratRefuge;

        [AreaId("MapHideoutFarmlands_Claimable")]
        public static readonly string FarmlandsHideout;

        [AreaId("MapHideoutPrison_Claimable")]
        public static readonly string PrisonHideout;

        [AreaId("MapHideoutShoreline_Claimable")]
        public static readonly string ShorelineHideout;

        [AreaId("MapArroyo")]
        public static readonly string Arroyo;

        [AreaId("MapOrnateChambers")]
        public static readonly string OrnateChambers;

        [AreaId("MapCanyon")]
        public static readonly string Canyon;

        [AreaId("MapRazedFields")]
        public static readonly string RazedFields;

        [AreaId("MapRugosa")]
        public static readonly string Rugosa;

        [AreaId("MapRiverhold")]
        public static readonly string Riverhold;

        [AreaId("MapExcavation")]
        public static readonly string Digsite;

        [AreaId("MapIceCave")]
        public static readonly string IceCave;

        [AreaId("MapVaalVault")]
        public static readonly string SealedVault;





        static MapNames()
        {
            var areaDict = Dat.WorldAreaDat.Records.ToDictionary(a => a.Id, a => a.Name);
            bool error = false;

            foreach (var field in typeof(MapNames).GetFields())
            {
                var attr = field.GetCustomAttribute<AreaId>();

                if (attr == null)
                    continue;

                if (areaDict.TryGetValue(attr.Id, out var name))
                {
                    field.SetValue(null, name);
                }
                else
                {
                    GlobalLog.Error($"[MapNames] Cannot initialize \"{field.Name}\" field. DatWorldAreas does not contain area with \"{attr.Id}\" id.");
                    error = true;
                }
            }
            if (error) BotManager.Stop();
        }
    }
}