using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class ClockworkAssaultRifleSummonBuff : SummonBuff
    {

        public ClockworkAssaultRifleSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Clockwork Assault Rifle";
            this.description = "The clockwork assault rifle will fight for you!";
            this.projectile = ModContent.ProjectileType<ClockworkAssaultRifleSummonProjectile>();

        }
    }
}

