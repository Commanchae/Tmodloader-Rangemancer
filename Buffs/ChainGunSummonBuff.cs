using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class ChainGunSummonBuff : SummonBuff
    {

        public ChainGunSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Chain Gun";
            this.description = "The chain gun will fight for you!";
            this.projectile = ModContent.ProjectileType<ChainGunSummonProjectile>();

        }
    }
}

