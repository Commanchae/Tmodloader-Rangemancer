using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class MegasharkSummonBuff : SummonBuff
    {

        public MegasharkSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Megashark";
            this.description = "The megashark will fight for you!";
            this.projectile = ModContent.ProjectileType<MegasharkSummonProjectile>();

        }
    }
}

