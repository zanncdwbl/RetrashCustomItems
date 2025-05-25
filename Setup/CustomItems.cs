using System;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using ItemAPI;
using MonoMod.RuntimeDetour;

namespace Blunderbeast
{
    [BepInDependency("etgmodding.etg.mtgapi")]
    [BepInPlugin("Retrash", "[Retrash's] Custom Items Collection", "5.0.2")]
    public class CustomItems : BaseUnityPlugin
    {
        public const string GUID = "Retrash";
        public const string NAME = "[Retrash's] Custom Items Collection";
        public const string VERSION = "5.0.2";
        public const string TEXT_COLOR = "#ffbf00";

        public void Awake() {}

        public void Start()
        {
            ETGModMainBehaviour.WaitForGameManagerStart(new Action<GameManager>(this.GMStart));
        }

        public void GMStart(GameManager g)
        {
            FakePrefabHooks.Init();
            ItemBuilder.Init();
            ETGMod.Assets.SetupSpritesFromFolder(Path.Combine(ETGMod.FolderPath(this), "sprites"));
            Blunderbeastblight.Init();
            Beastbloodinjection.Init();
            Panacea.Init();
            Vampirecloak.Init();
            Tabletechstealth.Init();
            Glasssmelter.Init();
            Heartshield.Init();
            Recycloader.Init();
            Dodgicitering.Init();
            Tinybullets.Init();
            Boombox.Init();
            Challengerbelt.Init();
            CrackedEgg.Init();
            LockBullets.Init();
            UnlockedBullets.Init();
            MatryoshkaChest.Init();
            Raccoon.Init();
            BarrelCharger.Init();
            TwinPins.Init();
            Ouroboros.Init();
            MaledictionRounds.Init();
            CrystalBall.Init();
            BlankSpellbook.Init();
            CounterfeitCrown.Init();
            InfinityGuontletPassive.Init();
            DisciplineRing.Init();
            Invoker.Init();
            MindControlDevice.Init();
            SharpGuon.Init();
            Roshambo.Init();
            LootBox.Init();
            WarVase.Init();
            WishCoupon.Init();
            GravityGlove.Init();
            OrnatePistol.Add();
            GravityDisc.Add();
            Leafblower.Add();
            Artemis.Add();
            Alchemiser.Add();
            Craftsman.Add();
            TrapCard.Init();
            BarrierAmmolet.Init();
            NOU.Init();
            Infinigun.Add();
            RageRifle.Add();
            BrittleArmor.Init();
            FragGrenade.Init();
            IcySkull.Init();
            RepositoryDamned.Init();
            BigRedButtonGag.Init();
            GrenadeOnAStick.Add();
            ShopTool.Init();
            Hook hook = new Hook(typeof(StringTableManager).GetMethod("GetSynergyString", BindingFlags.Static | BindingFlags.Public), typeof(CustomItems).GetMethod("SynergyStringHook"));
            foreach (AdvancedSynergyEntry advancedSynergyEntry in GameManager.Instance.SynergyManager.synergies)
            {
                bool flag = advancedSynergyEntry.NameKey == "#RECYCLING";
                if (flag)
                {
                    advancedSynergyEntry.OptionalItemIDs.Add(ETGMod.Databases.Items["Recycloader"].PickupObjectId);
                    bool flag2 = advancedSynergyEntry.MandatoryGunIDs.Contains(507);
                    if (flag2)
                    {
                        advancedSynergyEntry.MandatoryGunIDs.Remove(507);
                    }
                    bool flag3 = !advancedSynergyEntry.OptionalItemIDs.Contains(507);
                    if (flag3)
                    {
                        advancedSynergyEntry.OptionalItemIDs.Add(507);
                    }
                }
                bool flag4 = advancedSynergyEntry.NameKey == "#MINORBLANKABLES1";
                if (flag4)
                {
                    advancedSynergyEntry.OptionalItemIDs.Add(ETGMod.Databases.Items["Barrier Ammolet"].PickupObjectId);
                }
                bool flag5 = advancedSynergyEntry.NameKey == "#RELODESTAR";
                if (flag5)
                {
                    advancedSynergyEntry.OptionalItemIDs.Add(ETGMod.Databases.Items["Barrier Ammolet"].PickupObjectId);
                }
                bool flag6 = advancedSynergyEntry.NameKey == "#CRISISROCK";
                if (flag6)
                {
                    advancedSynergyEntry.OptionalItemIDs.Add(ETGMod.Databases.Items["Barrier Ammolet"].PickupObjectId);
                    bool flag7 = advancedSynergyEntry.MandatoryItemIDs.Contains(634);
                    if (flag7)
                    {
                        advancedSynergyEntry.MandatoryItemIDs.Remove(634);
                    }
                    bool flag8 = !advancedSynergyEntry.OptionalItemIDs.Contains(634);
                    if (flag8)
                    {
                        advancedSynergyEntry.OptionalItemIDs.Add(634);
                    }
                }
                bool flag9 = advancedSynergyEntry.NameKey == "#CEREBRAL_BROS";
                if (flag9)
                {
                    advancedSynergyEntry.OptionalItemIDs.Add(ETGMod.Databases.Items["Mind Control Device"].PickupObjectId);
                }
                bool flag10 = advancedSynergyEntry.NameKey == "#PAPERWORK";
                if (flag10)
                {
                    advancedSynergyEntry.OptionalItemIDs.Add(ETGMod.Databases.Items["Table Tech Stealth"].PickupObjectId);
                }
                bool flag11 = advancedSynergyEntry.NameKey == "#TWOEGGS";
                if (flag11)
                {
                    advancedSynergyEntry.OptionalItemIDs.Add(ETGMod.Databases.Items["Crackling Egg"].PickupObjectId);
                    bool flag12 = advancedSynergyEntry.MandatoryItemIDs.Contains(637);
                    if (flag12)
                    {
                        advancedSynergyEntry.MandatoryItemIDs.Remove(637);
                    }
                    bool flag13 = !advancedSynergyEntry.OptionalItemIDs.Contains(637);
                    if (flag13)
                    {
                        advancedSynergyEntry.OptionalItemIDs.Add(637);
                    }
                }
                bool flag14 = advancedSynergyEntry.NameKey == "#LEAFBUSTER";
                if (flag14)
                {
                    advancedSynergyEntry.OptionalGunIDs.Add(PickupObjectDatabase.GetByEncounterName("Verdant Blaster").PickupObjectId);
                    bool flag15 = advancedSynergyEntry.MandatoryGunIDs.Contains(339);
                    if (flag15)
                    {
                        advancedSynergyEntry.MandatoryGunIDs.Remove(339);
                    }
                    bool flag16 = !advancedSynergyEntry.OptionalGunIDs.Contains(339);
                    if (flag16)
                    {
                        advancedSynergyEntry.OptionalGunIDs.Add(339);
                    }
                }
                bool flag17 = advancedSynergyEntry.NameKey == "#IDOLHANDS";
                if (flag17)
                {
                    advancedSynergyEntry.OptionalItemIDs.Add(PickupObjectDatabase.GetByEncounterName("Exalted Armbow").PickupObjectId);
                    bool flag18 = advancedSynergyEntry.MandatoryItemIDs.Contains(457);
                    if (flag18)
                    {
                        advancedSynergyEntry.MandatoryItemIDs.Remove(457);
                    }
                    bool flag19 = !advancedSynergyEntry.OptionalItemIDs.Contains(457);
                    if (flag19)
                    {
                        advancedSynergyEntry.OptionalItemIDs.Add(457);
                    }
                }
                bool flag20 = advancedSynergyEntry.NameKey == "#YETIDUNK";
                if (flag20)
                {
                    advancedSynergyEntry.OptionalGunIDs.Add(PickupObjectDatabase.GetByEncounterName("Icy Skull").PickupObjectId);
                    bool flag21 = advancedSynergyEntry.MandatoryGunIDs.Contains(387);
                    if (flag21)
                    {
                        advancedSynergyEntry.MandatoryGunIDs.Remove(387);
                    }
                    bool flag22 = !advancedSynergyEntry.OptionalGunIDs.Contains(387);
                    if (flag22)
                    {
                        advancedSynergyEntry.OptionalGunIDs.Add(387);
                    }
                    bool flag23 = advancedSynergyEntry.MandatoryGunIDs.Contains(223);
                    if (flag23)
                    {
                        advancedSynergyEntry.MandatoryGunIDs.Remove(223);
                    }
                    bool flag24 = !advancedSynergyEntry.OptionalGunIDs.Contains(223);
                    if (flag24)
                    {
                        advancedSynergyEntry.OptionalGunIDs.Add(223);
                    }
                }
            }
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.VeryHungrySynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.SmeltingHardSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.TheTinyAndBigSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.StableDodgeciteRingSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.SmallAndStrong()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.ShopkeeperCapsuleSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.DeadlyBulletsSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.ChestFamilySynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.StormChargedSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.TheGoodSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.TheBadSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.SoulFiendSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.MagicTablesSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.BlankEnchanterSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.EvenSharperSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.WarBarrelSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.FourthWishSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.TrapperCardSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.YesRSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.InfinityGuontletSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.TheUglySynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.ArtemisSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.AlchemySynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.CardHeartSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.GForceSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.GreedyJarsSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.EggRollSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.FutureSightSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.TigerGenieSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.SoulTriggerSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.IceAgeSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.GoldenRatioSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.AngerIssuesSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.AbsoluteChaosSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.ArmorMaintenanceSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.FormerGlorySynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.RockPaperCrossBow()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.BatterUpSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.ChuckingNadesSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.RocketPitchSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.FreezePlusSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.FrozenCoreSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.BoneheadSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.ToolKitSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.PotceptionSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.AntiquatedSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.DendrologySynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.PlagueDoctorSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.ControllerSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            GameManager.Instance.SynergyManager.synergies = GameManager.Instance.SynergyManager.synergies.Concat(new AdvancedSynergyEntry[]
            {
                new CustomSynergies.ChickenSeerSynergy()
            }).ToArray<AdvancedSynergyEntry>();
            SynergyFormInitialiser.AddSynergyForms();
            Tools.Print<string>("[Retrash's] Custom Items Collection v5.0.2 started successfully.", "#ffbf00");
        }

        public static string SynergyStringHook(Func<string, int, string> action, string key, int index = -1)
        {
            string value = action(key, index);
            if (string.IsNullOrEmpty(value))
            {
                value = key;
            }
            return value;
        }

        public bool isRetrashCollection;

        public void Exit()
        {
        }
    }
}
