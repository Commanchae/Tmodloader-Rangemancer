﻿using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class SnowballCannonSummonBuff : SummonBuff
    {

        public SnowballCannonSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Snowball Cannon";
            this.description = "The snowball cannon will fight for you!";
            this.projectile = ModContent.ProjectileType<SnowballCannonSummonProjectile>();

        }
    }
}

