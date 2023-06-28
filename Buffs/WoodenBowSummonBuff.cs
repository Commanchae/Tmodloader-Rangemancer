﻿using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class WoodenBowSummonBuff : SummonBuff
    {

        public WoodenBowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Wooden Bow";
            this.description = "This wooden bow will fight for you!";
            this.projectile = ModContent.ProjectileType<WoodenBowSummonProjectile>();

        }
    }
}