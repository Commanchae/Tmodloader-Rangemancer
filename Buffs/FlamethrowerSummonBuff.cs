using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class FlamethrowerSummonBuff : SummonBuff
    {

        public FlamethrowerSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Flamethrower";
            this.description = "The flamethrower will fight for you!";
            this.projectile = ModContent.ProjectileType<FlamethrowerSummonProjectile>();

        }
    }
}

