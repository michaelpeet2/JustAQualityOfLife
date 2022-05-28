using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace JustAQualityOfLife.Content.Items
{
    public class StartBag :ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starter Bag"); 
			Tooltip.SetDefault("Bag"); //Sets the tooltip description of the Item
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{

			Item.rare = ItemRarityID.Cyan; //Cyan Rarity
			Item.value = 750000;// 75/5 = 15 so sell price is 15 and buy price is 15 this also affects reforge price

		}
	}
}
