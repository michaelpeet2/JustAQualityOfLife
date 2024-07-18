//Needs a nerf
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using JustAQualityOfLife.Content.Systems;

namespace JustAQualityOfLife.Content.Accesories.UltimateEmblem
{
    public class UltimateEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
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
            player.GetDamage(DamageClass.Generic) += .18f; //Increase 12%
            


            //damage boost
            player.GetCritChance(DamageClass.Generic) += 12; //Crit 12 percent
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("JQL_AnyEmblem")
                .AddIngredient(ItemID.AvengerEmblem)//ingredient
                .AddIngredient(ItemID.DestroyerEmblem)//ingredient
                .AddTile(TileID.TinkerersWorkbench)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}