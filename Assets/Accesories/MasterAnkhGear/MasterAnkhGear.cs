using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;

namespace JustAQualityOfLife.Assets.Accesories.MasterAnkhGear
{
    public class MasterAnkhGear : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Master Ankh Gear"); //changes the name of the item instead of just using the public class
			Tooltip.SetDefault("Allows dash, wall climbing, and a chance to dodge attacks \nAllows immunity to most debuffs, knockback, and fall damage."); //Sets the tooltip description of the Item
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.defense = 4; //sets defence value
			Item.accessory = true; //Makes this equipment
			Item.rare = ItemRarityID.Cyan; //Cyan Rarity
			Item.value = 750000;// 75/5 = 15 so sell price is 15 and buy price is 15 this also affects reforge price

		}


		public override void UpdateAccessory(Player player, bool hideVisual) //grant immunities
		{
			
			//debuffs
			player.buffImmune[67] = true; //Burning
			player.buffImmune[20] = true; //Posined
			player.buffImmune[30] = true; //Bleeding
			player.buffImmune[36] = true; //Broken Armor
			player.buffImmune[31] = true; //Confused
			player.buffImmune[23] = true; //Cursed
			player.buffImmune[22] = true; //Darkness
			player.buffImmune[35] = true; //Silenced
			player.buffImmune[32] = true; //Slow
			player.buffImmune[33] = true; //Weak
			player.buffImmune[46] = true; //Chilled		

			//World Interaction
			player.noKnockback = true; //Knockback
			player.noFallDmg = true; //FallDmg --New
			player.blackBelt = true;//can dodge like Master Ninja Gear/ Black Belt			
									//Movement
			player.dashType = 1;
			player.spikedBoots = 2;//Can Climb
		}

		public override void AddRecipes()
		{

			CreateRecipe()
				.AddIngredient(ItemID.AnkhShield)
				.AddIngredient(ItemID.MasterNinjaGear)
				.AddTile(TileID.MythrilAnvil)//mod.TileType("CrafterOqualityTile")
				.Register();

		}
	}

}
