using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class IceBowSummonBuff : SummonBuff
    {

        public IceBowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Ice Bow";
            this.description = "The ice bow will fight for you!";
            this.projectile = ModContent.ProjectileType<IceBowSummonProjectile>();

        }
    }
}

