using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class CoinGunSummonBuff : SummonBuff
    {

        public CoinGunSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Coin Gun";
            this.description = "The coin gun will fight for you!";
            this.projectile = ModContent.ProjectileType<CoinGunSummonProjectile>();

        }
    }
}

