using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
using System.Collections.Generic;

namespace Bowmancer.Items.Bows
{
    public class ChlorophyteShotbowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<ChlorophyteShotbowSummonBuff>();
            projectile = ModContent.ProjectileType<ChlorophyteShotbowSummonProjectile>();
            name = "Enchanted Chlorophyte Shotbow";
            damage = (int) (34 * 0.75);
            knockBack = 1.5f;
            mana = 40;
            itemID = ItemID.ChlorophyteShotbow;


            itemDescription = "Summons an enchanted [c/52ab26:chlorophyte shotbow] to fight for you!";
            abilityDescription = "Shoots chlorophyte arrows that home in on enemies and shoots an extra arrow from the player.";
            abilityNameColor = "52ab26";
            abilityName = "Chlorophyte's Spread";
        }

    }
}
