using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.GameContent;
using Microsoft.Xna.Framework;

namespace JustAQualityOfLife.Content.Items.StartBag
{
    public class StartBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Starter Bag");
            //Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}"); //Sets the tooltip description of the Item
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Purple;

        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            var entitySource = player.GetSource_OpenItem(Type);
            player.QuickSpawnItem(entitySource, ItemID.GrapplingHook);
            player.QuickSpawnItem(entitySource, ItemID.IronBroadsword);
            player.QuickSpawnItem(entitySource, ItemID.IronHammer);
            player.QuickSpawnItem(entitySource, ItemID.IronPickaxe);
            player.QuickSpawnItem(entitySource, ItemID.IronAxe);
            player.QuickSpawnItem(entitySource, ItemID.IronBow);
            player.QuickSpawnItem(entitySource, ItemID.BabyBirdStaff);
            player.QuickSpawnItem(entitySource, ItemID.TopazStaff);
            player.QuickSpawnItem(entitySource, ItemID.SpelunkerPotion, 2);
            player.QuickSpawnItem(entitySource, ItemID.MiningPotion, 2);
            player.QuickSpawnItem(entitySource, ItemID.RegenerationPotion, 5);
            player.QuickSpawnItem(entitySource, ItemID.SwiftnessPotion, 5);
            player.QuickSpawnItem(entitySource, ItemID.LifeCrystal, 5);
            player.QuickSpawnItem(entitySource, ItemID.ManaCrystal, 5);
            player.QuickSpawnItem(entitySource, ItemID.FlamingArrow, 200);
            player.QuickSpawnItem(entitySource, ItemID.Torch, 999);
        }
    }
}
