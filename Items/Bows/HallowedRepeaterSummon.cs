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
    public class HallowedRepeaterSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<HallowedRepeaterSummonBuff>();
            projectile = ModContent.ProjectileType<HallowedRepeaterSummonProjectile>();
            name = "Enchanted Hallowed Repeater";
            damage = 48;
            knockBack = 2.5f;
            mana = 40;
            itemID = ItemID.HallowedRepeater;


            itemDescription = "Summons an enchanted [c/ffe736:hallowed repeater] to fight for you!";
            abilityDescription = "Grants the player brief invulnerability after every 50th shot.";
            abilityNameColor = "ffe736";
            abilityName = "Holy Shield (Buff)";
        }

    }
}
