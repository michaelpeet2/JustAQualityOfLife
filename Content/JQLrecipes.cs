using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace JustAQualityOfLife.Content
{
    public class JQLrecipes : ModSystem
    {
        public override void AddRecipes()
        {

            Recipe.Create(ItemID.HermesBoots)
                .AddIngredient(ItemID.WoodGreaves)
                .AddIngredient(ItemID.Silk, 12)
                .AddIngredient(ItemID.SwiftnessPotion)
                .AddTile(TileID.Anvils)
                .Register();

            Recipe.Create(ItemID.Extractinator)
                .AddIngredient(ItemID.IronBar, 15)
                .AddTile(TileID.Anvils)
                .Register();
        }

        #region PostAddRecipes
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];

                // Iron and Lead
                if (recipe.TryGetIngredient(ItemID.IronOre, out Item ingredient))
                {
                    ingredient.stack = 1;
                }

                if (recipe.TryGetIngredient(ItemID.LeadOre, out Item ingredient1))
                {
                    ingredient1.stack = 1;
                }
                //Copper and Tin
                if (recipe.TryGetIngredient(ItemID.CopperOre, out Item ingredient2))
                {
                    ingredient2.stack = 1;
                }

                if (recipe.TryGetIngredient(ItemID.TinOre, out Item ingredient3))
                {
                    ingredient3.stack = 1;
                }
                //Plat and Gold
                if (recipe.TryGetIngredient(ItemID.PlatinumOre, out Item ingredient4))
                {
                    ingredient4.stack = 1;
                }

                if (recipe.TryGetIngredient(ItemID.GoldOre, out Item ingredient5))
                {
                    ingredient5.stack = 1;
                }
                //Tungston and Silver
                if (recipe.TryGetIngredient(ItemID.TungstenOre, out Item ingredient6))
                {
                    ingredient6.stack = 1;
                }

                if (recipe.TryGetIngredient(ItemID.SilverOre, out Item ingredient7))
                {
                    ingredient7.stack = 1;
                }

                //Mythril & Orical
                if (recipe.TryGetIngredient(ItemID.MythrilOre, out Item ingredient8))
                {
                    ingredient8.stack = 1;
                }

                if (recipe.TryGetIngredient(ItemID.OrichalcumOre, out Item ingredient9))
                {
                    ingredient9.stack = 1;
                }

                //Cobalt & Palladium
                if (recipe.TryGetIngredient(ItemID.CobaltOre, out Item ingredient10))
                {
                    ingredient10.stack = 1;
                }

                if (recipe.TryGetIngredient(ItemID.PalladiumOre, out Item ingredient11))
                {
                    ingredient11.stack = 1;
                }

                //Titanium & Admantite
                if (recipe.TryGetIngredient(ItemID.TitaniumOre, out Item ingredient12))
                {
                    ingredient12.stack = 1;
                }

                if (recipe.TryGetIngredient(ItemID.AdamantiteOre, out Item ingredient13))
                {
                    ingredient13.stack = 1;
                }

                //Hellstone Ore
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                if (recipe.TryGetIngredient(ItemID.Hellstone, out Item ingredient14) && recipe.TryGetIngredient(ItemID.Obsidian, out Item ingredient15))
                {
                    ingredient14.stack = 1;
                }
#pragma warning restore IDE0059 // Unnecessary assignment of a value

                //Demonite & Crimtaine
                if (recipe.TryGetIngredient(ItemID.CrimtaneOre, out Item ingredient16))
                {
                    ingredient16.stack = 1;
                }

                if (recipe.TryGetIngredient(ItemID.DemoniteOre, out Item ingredient17))
                {
                    ingredient17.stack = 1;
                }

                //Attempt for Shroomite
#pragma warning disable IDE0059 // Unnecessary assignment of a value
                if (recipe.TryGetIngredient(ItemID.ChlorophyteBar, out Item ingredient18) && recipe.TryGetIngredient(ItemID.GlowingMushroom, out Item ingredient19))
                {
                    ingredient19.stack = 1;
                }
#pragma warning restore IDE0059 // Unnecessary assignment of a value

                //meteorite
                if (recipe.TryGetIngredient(ItemID.Meteorite, out Item ingredient20))
                {
                    ingredient20.stack = 1;
                }

                //Luminite
                if (recipe.TryGetIngredient(ItemID.LunarOre, out Item ingredient21))
                {
                    ingredient21.stack = 1;
                }

                //Chlorophyte
                if (recipe.TryGetIngredient(ItemID.ChlorophyteOre, out Item ingredient22))
                {
                    ingredient22.stack = 1;
                }
            }
            #endregion
        }
    }
}
