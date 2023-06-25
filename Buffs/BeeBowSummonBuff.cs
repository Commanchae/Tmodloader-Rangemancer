using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.Bows;

namespace Bowmancer.Buffs
{
    public class BeeBowSummonBuff : SummonBuff
    {

        public BeeBowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "The Bee's Knees";
            this.description = "The Bee's Knees will fight for you!";
            this.projectile = ModContent.ProjectileType<BeeBowSummonProjectile>();

        }
    }
}

