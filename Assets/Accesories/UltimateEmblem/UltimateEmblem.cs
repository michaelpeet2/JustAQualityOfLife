//Needs a nerf
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace JustAQualityOfLife.Assets.Accesories.UltimateEmblem
{
    public class UltimateEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(" 12% Crit Strike Chance \n 15% Damage Increase");
            //Sets the tooltip description of the Item

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
               
        }

        public override void SetDefaults()
        {
            Item.accessory = true; //Makes this equipment
            Item.rare = ItemRarityID.Cyan; //Makes this Cyan rarity
        }

        public override void UpdateAccessory(Player player, bool hideVisual) //Modifiers
        {
            //Damage
            player.GetDamage(DamageClass.Generic) *= 1.15f; //Increase 12%

            //damage boost
            player.GetCritChance(DamageClass.Generic) += 12; //Crit 12 percent
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.WarriorEmblem)//ingredient
                .AddIngredient(ItemID.RangerEmblem)//ingredient
                .AddIngredient(ItemID.SorcererEmblem)//ingredient
                .AddIngredient(ItemID.SummonerEmblem)//ingredient
                .AddIngredient(ItemID.AvengerEmblem)//ingredient
                .AddIngredient(ItemID.DestroyerEmblem)//ingredient

.AddTile(TileID.MythrilAnvil)//mod.TileType("CrafterOqualityTile")
                .Register();
        }
    }
}