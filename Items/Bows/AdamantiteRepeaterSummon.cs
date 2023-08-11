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
    public class AdamantiteRepeaterSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<AdamantiteRepeaterSummonBuff>();
            projectile = ModContent.ProjectileType<AdamantiteRepeaterSummonProjectile>();
            name = "Enchanted Adamantite Repeater";
            damage = 42;
            knockBack = 2.5f;
            mana = 40;
            itemID = ItemID.AdamantiteRepeater;


            itemDescription = "Summons an enchanted [c/d1003f:adamantite repeater] to fight for you!";
            abilityDescription = "Buffs the player with Wrath for 3 seconds every 20th shot, boosting the damage of all weapons.";
            abilityNameColor = "d1003f";
            abilityName = "Wrathful Honor (Buff)";
        }

    }
}
