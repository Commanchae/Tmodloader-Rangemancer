using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class PlatinumBowSummonBuff : SummonBuff
    {

        public PlatinumBowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Platinum Bow";
            this.description = "This platinum bow will fight for you!";
            this.projectile = ModContent.ProjectileType<PlatinumBowSummonProjectile>();

        }
    }
}
