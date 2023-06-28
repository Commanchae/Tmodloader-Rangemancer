using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class BoomstickSummonBuff : SummonBuff
    {

        public BoomstickSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Boomstick";
            this.description = "The boomstick will fight for you!";
            this.projectile = ModContent.ProjectileType<BoomstickSummonProjectile>();

        }
    }
}

