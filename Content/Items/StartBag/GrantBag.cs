using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using JustAQualityOfLife.Content.Items.StartBag;

namespace JustAQualityOfLife.Content.Items.StartBag
{
    public class GrantBag : ModPlayer
    {

		public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
		{
			return new[] {
				new Item(ModContent.ItemType<StartBag>()),
			};
		}
	}
}
