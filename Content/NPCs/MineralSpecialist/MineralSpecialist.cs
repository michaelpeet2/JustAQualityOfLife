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

namespace JustAQualityOfLife.Content.NPCs.MineralSpecialist
{
    [AutoloadHead]
    public class MineralSpecialist : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mineral Specialist");
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

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                if (NPC.downedBoss1)
                {
                    return true;
                }
            }    
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>() {
                "Femboy",
                "Miner Boy",
                "Square boi",
                "UwU overlord"
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
        }

        public override void SetChatButtons(ref string button, ref string button2)
        { // What the chat buttons are when you open up the chat UI
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if(firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.CopperOre);
            shop.item[nextSlot].shopCustomPrice = 75;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.TinOre);
            shop.item[nextSlot].shopCustomPrice = 75;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.IronOre);
            shop.item[nextSlot].shopCustomPrice = 150;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.LeadOre);
            shop.item[nextSlot].shopCustomPrice = 150;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.SilverOre);
            shop.item[nextSlot].shopCustomPrice = 225;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.TungstenOre);
            shop.item[nextSlot].shopCustomPrice = 225;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.GoldOre);
            shop.item[nextSlot].shopCustomPrice = 450;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.PlatinumOre);
            shop.item[nextSlot].shopCustomPrice = 450;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.FossilOre);
            shop.item[nextSlot].shopCustomPrice = 450;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.DesertFossil);
            shop.item[nextSlot].shopCustomPrice = 1300;
            nextSlot++;

            if (NPC.downedBoss1)
            {
                shop.item[nextSlot].SetDefaults(ItemID.DemoniteOre);
                shop.item[nextSlot].shopCustomPrice = 1300;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.CrimtaneOre);
                shop.item[nextSlot].shopCustomPrice = 1300;
                nextSlot++;
            }

            if (NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Meteorite);
                shop.item[nextSlot].shopCustomPrice = 200;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Obsidian);
                shop.item[nextSlot].shopCustomPrice = 200;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Hellstone);
                shop.item[nextSlot].shopCustomPrice = 250;
                nextSlot++;
            }

            if(Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.CobaltOre);
                shop.item[nextSlot].shopCustomPrice = 900;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.PalladiumOre);
                shop.item[nextSlot].shopCustomPrice = 900;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MythrilOre);
                shop.item[nextSlot].shopCustomPrice = 1300;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.OrichalcumOre);
                shop.item[nextSlot].shopCustomPrice = 13000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.AdamantiteOre);
                shop.item[nextSlot].shopCustomPrice = 17000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.TitaniumOre);
                shop.item[nextSlot].shopCustomPrice = 17000;
                nextSlot++;

                if(NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteOre);
                    shop.item[nextSlot].shopCustomPrice = 1500;
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.HallowedBar);
                    shop.item[nextSlot].shopCustomPrice = 4000;
                    nextSlot++;
                }

                if(NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LunarOre);
                    shop.item[nextSlot].shopCustomPrice = 3000;
                    nextSlot++;
                }
            }

            shop.item[nextSlot].SetDefaults(ItemID.Amethyst);
            shop.item[nextSlot].shopCustomPrice = 375;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Topaz);
            shop.item[nextSlot].shopCustomPrice = 750;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Sapphire);
            shop.item[nextSlot].shopCustomPrice = 1125;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Emerald);
            shop.item[nextSlot].shopCustomPrice = 1500;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Ruby);
            shop.item[nextSlot].shopCustomPrice = 2250;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Amber);
            shop.item[nextSlot].shopCustomPrice = 3000;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(ItemID.Diamond);
            shop.item[nextSlot].shopCustomPrice = 3000;
            nextSlot++;
        }

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
