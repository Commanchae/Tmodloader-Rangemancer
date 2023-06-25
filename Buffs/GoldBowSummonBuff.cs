using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.Bows;

namespace Bowmancer.Buffs
{
    public class GoldBowSummonBuff : SummonBuff
    {

        public GoldBowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Gold Bow";
            this.description = "This gold bow will fight for you!";
            this.projectile = ModContent.ProjectileType<GoldBowSummonProjectile>();

        }
    }
}
