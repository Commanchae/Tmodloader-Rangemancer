using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class BorealBowSummonBuff : SummonBuff
    {

        public BorealBowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Boreal Bow";
            this.description = "This boreal bow will fight for you!";
            this.projectile = ModContent.ProjectileType<BorealBowSummonProjectile>();

        }
    }
}
