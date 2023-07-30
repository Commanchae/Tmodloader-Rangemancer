using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class SniperRifleSummonBuff : SummonBuff
    {

        public SniperRifleSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Sniper Rifle";
            this.description = "The sniper rifle will fight for you!";
            this.projectile = ModContent.ProjectileType<SniperRifleSummonProjectile>();

        }
    }
}

