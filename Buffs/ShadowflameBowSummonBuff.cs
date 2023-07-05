using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class ShadowflameBowSummonBuff : SummonBuff
    {

        public ShadowflameBowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Shadowflame Bow";
            this.description = "The shadowflame bow will fight for you!";
            this.projectile = ModContent.ProjectileType<ShadowflameBowSummonProjectile>();

        }
    }
}

