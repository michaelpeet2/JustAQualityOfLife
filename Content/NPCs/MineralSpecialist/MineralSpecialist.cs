using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.Bestiary;
using System.Collections.Generic;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.IO;
using Terraria.GameContent;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace JustAQualityOfLife.Content.NPCs.MineralSpecialist
{
    [AutoloadHead]
    public class MineralSpecialist : ModNPC
    {
        public static string VanillaShop = "Shop1";
        public static string ModdedShop = "Shop2";
        public int NumberOfTimesTalkedTo = 0;

        public override void SetStaticDefaults()
        {
           // DisplayName.SetDefault("Mineral Specialist");
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 90;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new(0)
            {
                Velocity = 1f,
                Direction = -1
            };
            //Old Code revide within a revision of MinSpec

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
                .SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love)
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Like)
                .SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Like)
                .SetBiomeAffection<JungleBiome>(AffectionLevel.Hate)
                
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Love)
                .SetNPCAffection(NPCID.DD2Bartender, AffectionLevel.Like)
                .SetNPCAffection(NPCID.Mechanic, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Steampunker, AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Princess, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Angler, AffectionLevel.Hate)
                ;
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

                new FlavorTextBestiaryInfoElement("A useful person who sells ores and gems. Modded mineral shop TBA.")
            });
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
                if (NPC.downedBoss1)
                {
                    return true;
                }
            
            return false;
        }
        
        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Carns Expert",
                "Miner Boy",
                "Cave Crawler",
                "Excavator"
            };
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new();

           /* int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.NextBool(4))
            {
                chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
            }
           */
            // These are things that the NPC has a chance of telling you when you talk to it.
            chat.Add("Sometimes I feel like I'm different from everyone else here.");
            chat.Add("What's your favorite color? My favorite colors are white and black.");
            chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
            chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
            chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
            return chat; // chat is implicitly cast to a string.
        //Can be updated to a Localization file (I think am not sure NPC stuff if not well documented), Example mod uses the following line of code for each line
        //chat.Add(Language.GetTextValue("Mods.ExampleMod.Dialogue.ExamplePerson.RareDialogue"), 0.1); 
        //The last number portion is optional, along with the comma befoire it and it adds weights to the frequency of the dialogue option
        //More reasearch into Localization files and other of these files for text needs to be done
        }

        public override void SetChatButtons(ref string button, ref string button2)
        { // What the chat buttons are when you open up the chat UI
            string shop2 = Language.GetTextValue("LegacyInterface.28") + "2";
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = shop2;
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = VanillaShop; 
            }
            else
            {
                shopName = ModdedShop;
            }



        }

        public override void AddShops()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            //The conditions that will allow us to set when certain items are able to start being sold
            #region VanillaConditions
            Condition downedEoC = Condition.DownedEyeOfCthulhu;
            Condition downedBoss2 = Condition.DownedEowOrBoc;
            Condition downedSkeleboi = Condition.DownedSkeletron;
            Condition hardmode = Condition.Hardmode;
            Condition oneMechKilled = Condition.DownedMechBossAny;
            Condition downedMechBosses = Condition.DownedMechBossAll;
            Condition downedMoonlord = Condition.DownedMoonLord;
            Condition downedPlantera = Condition.DownedPlantera;
            Condition downedGolem = Condition.DownedGolem;
            #endregion

            #region Shop1
            NPCShop shop = new(Type, VanillaShop);
            //Copper & Tin 4 silver per
            shop.Add(new Item(ItemID.CopperOre) { shopCustomPrice = Item.buyPrice(silver: 4) }, downedEoC)
                .Add(new Item(ItemID.TinOre) { shopCustomPrice = Item.buyPrice(silver: 4) }, downedEoC)
                //Lead and Iron
                .Add(new Item(ItemID.LeadOre) { shopCustomPrice = Item.buyPrice(silver: 6) }, downedEoC)
                .Add(new Item(ItemID.IronOre) { shopCustomPrice = Item.buyPrice(silver: 6) }, downedEoC)
                //Tungsten & Silver
                .Add(new Item(ItemID.TungstenOre) { shopCustomPrice = Item.buyPrice(silver: 11) }, downedEoC)
                .Add(new Item(ItemID.SilverOre) { shopCustomPrice = Item.buyPrice(silver: 11) }, downedEoC)
                //Plat and Gold
                .Add(new Item(ItemID.PlatinumOre) { shopCustomPrice = Item.buyPrice(silver: 20) }, downedEoC)
                .Add(new Item(ItemID.GoldOre) { shopCustomPrice = Item.buyPrice(silver: 20) }, downedEoC)
                //Fossils
                .Add(new Item(ItemID.DesertFossil) { shopCustomPrice = Item.buyPrice(silver: 40) }, downedEoC)
                .Add(new Item(ItemID.FossilOre) { shopCustomPrice = Item.buyPrice(silver: 4) }, downedEoC)
                //Crimtaine & Demonite 
                .Add(new Item(ItemID.CrimtaneOre) { shopCustomPrice = Item.buyPrice(silver: 44) }, downedEoC)
                .Add(new Item(ItemID.DemoniteOre) { shopCustomPrice = Item.buyPrice(silver: 44) }, downedEoC)
                //Post EoW or BoC|| meteorites, Hellstone, Obsidian
                .Add(new Item(ItemID.Meteorite) { shopCustomPrice = Item.buyPrice(silver: 17) }, downedBoss2)
                .Add(new Item(ItemID.Obsidian) { shopCustomPrice = Item.buyPrice(silver: 4) }, downedBoss2)
                .Add(new Item(ItemID.Hellstone) { shopCustomPrice = Item.buyPrice(silver: 46) }, downedBoss2)

                //Hardmode Ores
                //Cobalt & palladium
                .Add(new Item(ItemID.CobaltOre) { shopCustomPrice = Item.buyPrice(silver: 35) }, hardmode)
                .Add(new Item(ItemID.PalladiumOre) { shopCustomPrice = Item.buyPrice(silver: 35) }, hardmode)
                //Mythril & Oricalch
                .Add(new Item(ItemID.MythrilOre) { shopCustomPrice = Item.buyPrice(silver: 60) }, hardmode)
                .Add(new Item(ItemID.OrichalcumOre) { shopCustomPrice = Item.buyPrice(silver: 60) }, hardmode)
                //Titanium & Adamantite
                .Add(new Item(ItemID.TitaniumOre) { shopCustomPrice = Item.buyPrice(silver: 75) }, hardmode)
                .Add(new Item(ItemID.AdamantiteOre) { shopCustomPrice = Item.buyPrice(silver: 75) }, hardmode)
                //Hallowed Bars
                .Add(new Item(ItemID.HallowedBar) { shopCustomPrice = Item.buyPrice(silver: 50) }, hardmode, oneMechKilled)
                //Chlorophyte
                .Add(new Item(ItemID.ChlorophyteOre) { shopCustomPrice = Item.buyPrice(gold: 1) }, hardmode, downedMechBosses)
                //Luminite
                .Add(new Item(ItemID.LunarOre) { shopCustomPrice = Item.buyPrice(gold: 2) }, downedMoonlord)

                //Gems
                .Add(new Item(ItemID.Amethyst) { shopCustomPrice = Item.buyPrice(silver: 5) }, downedEoC)
                .Add(new Item(ItemID.Topaz) { shopCustomPrice = Item.buyPrice(silver: 9) }, downedEoC)
                .Add(new Item(ItemID.Sapphire) { shopCustomPrice = Item.buyPrice(silver: 13) }, downedEoC)
                .Add(new Item(ItemID.Emerald) { shopCustomPrice = Item.buyPrice(silver: 16) }, downedEoC)
                .Add(new Item(ItemID.Ruby) { shopCustomPrice = Item.buyPrice(silver: 25) }, downedEoC)
                .Add(new Item(ItemID.Diamond) { shopCustomPrice = Item.buyPrice(silver: 33) }, downedEoC)
                .Add(new Item(ItemID.Amber) { shopCustomPrice = Item.buyPrice(silver: 33) }, downedEoC)
            .Register();
            #endregion

            #region Shop2
            NPCShop Shop2 = new(Type, ModdedShop);

            if (ModLoader.TryGetMod("CalamityMod", out Mod calamityMod)) 
            {
                
                if (calamityMod.TryFind("SeaPrism", out ModItem seaPrism))
                {
                    Shop2.Add(new Item(seaPrism.Type) { shopCustomPrice = Item.buyPrice(silver: 8) });
                }
                if (calamityMod.TryFind("AerialiteOre", out ModItem aerialiteOre))//Hive & Perf
                {
                    Shop2.Add(new Item(aerialiteOre.Type) {shopCustomPrice = Item.buyPrice(silver: 8) }, new Condition("", () => (bool)calamityMod.Call("GetBossDowned", "hivemind")));
                    Shop2.Add(new Item(aerialiteOre.Type) { shopCustomPrice = Item.buyPrice(silver: 8) }, new Condition("", () => (bool)calamityMod.Call("GetBossDowned", "perforator")));
                }
                if (calamityMod.TryFind("InfernalSuevite", out ModItem infernalOre))//1 Mech
                {
                    Shop2.Add(new Item(infernalOre.Type) { shopCustomPrice = Item.buyPrice(silver: 8) }, oneMechKilled);
                }
                if (calamityMod.TryFind("CryonicOre", out ModItem cryonicOre))//Cryogen
                {
                    Shop2.Add(new Item(cryonicOre.Type) { shopCustomPrice = Item.buyPrice(silver: 8) }, new Condition("", () => (bool)calamityMod.Call("GetBossDowned", "cryogen")));
                }
                if (calamityMod.TryFind("HallowedOre", out ModItem hallowedOre))//All Mechs
                {
                    Shop2.Add(new Item(hallowedOre.Type) { shopCustomPrice = Item.buyPrice(silver: 8) }, downedMechBosses);
                }
                if (calamityMod.TryFind("PerennialOre", out ModItem perennialOre))//Plantera
                {
                    Shop2.Add(new Item(perennialOre.Type) { shopCustomPrice = Item.buyPrice(silver: 8) }, downedPlantera);
                }
                if (calamityMod.TryFind("ScoriaOre", out ModItem scoriaOre))//Golem
                {
                    Shop2.Add(new Item(scoriaOre.Type) { shopCustomPrice = Item.buyPrice(silver: 8) }, downedGolem);
                }
                if (calamityMod.TryFind("AstralOre", out ModItem astralOre))//AstrumDeus
                {
                    Shop2.Add(new Item(astralOre.Type) { shopCustomPrice = Item.buyPrice(silver: 8) }, new Condition("", () => (bool)calamityMod.Call("GetBossDowned", "astrumdeus")));
                }
                if (calamityMod.TryFind("ExodiumCluster", out ModItem exodiumOre))//MoonLord
                {
                    Shop2.Add(new Item(exodiumOre.Type) { shopCustomPrice = Item.buyPrice(silver: 8) }, downedMoonlord);
                }
                if (calamityMod.TryFind("UelibloomOre", out ModItem uelibloomOre))//Providence
                {
                    Shop2.Add(new Item(uelibloomOre.Type) { shopCustomPrice = Item.buyPrice(silver: 8) }, new Condition("", () => (bool)calamityMod.Call("GetBossDowned", "providence")));
                }
                if (calamityMod.TryFind("AuricOre", out ModItem auricOre))//yahron
                {
                    Shop2.Add(new Item(auricOre.Type) { shopCustomPrice = Item.buyPrice(silver: 8)},new Condition("", () => (bool)calamityMod.Call("GetBossDowned", "yharon")));
                }

                //calamityMod.Call("GetBossDowned", "yharon")
            }








            Shop2.Register();
            #endregion

            //.Add(new Item(ItemID.) {shopCustomPrice = Item.buyPrice(silver: 5) }, downedEoC)
            //
        }
        //Credit to Calamity devs (code on their GitHub), and absoluteAquarian on the Tmodloader discord for assisting me in my confusion
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }
    }
}
