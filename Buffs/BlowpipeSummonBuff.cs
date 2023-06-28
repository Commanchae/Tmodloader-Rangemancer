using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class BlowpipeSummonBuff : SummonBuff
    {

        public BlowpipeSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Blowpipe";
            this.description = "The blowpipe will fight for you!";
            this.projectile = ModContent.ProjectileType<BlowpipeSummonProjectile>();

        }
    }
}

