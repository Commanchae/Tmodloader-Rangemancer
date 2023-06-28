using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Misc;

namespace Bowmancer.Buffs
{
    public class ShurikenSummonBuff : SummonBuff
    {

        public ShurikenSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Shuriken";
            this.description = "The shuriken will send its friends to fight for you!";
            this.projectile = ModContent.ProjectileType<ShurikenSummonProjectile>();

        }
    }
}

