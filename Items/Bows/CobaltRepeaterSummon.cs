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
    public class CobaltRepeaterSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<CobaltRepeaterSummonBuff>();
            projectile = ModContent.ProjectileType<CobaltRepeaterSummonProjectile>();
            name = "Enchanted Cobalt Repeater";
            damage = 35;
            knockBack = 1.5f;
            mana = 40;
            itemID = ItemID.CobaltRepeater;


            itemDescription = "Summons an enchanted [c/1c8eff:cobalt repeater] to fight for you!";
            abilityDescription = "Fires a random projectile every third shot.";
            abilityNameColor = "1c8eff";
            abilityName = "Ninja's Armaments";
        }

    }
}
