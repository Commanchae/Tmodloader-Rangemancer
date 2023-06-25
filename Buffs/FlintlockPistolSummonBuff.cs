using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.Guns;

namespace Bowmancer.Buffs
{
    public class FlintlockPistolSummonBuff : SummonBuff
    {

        public FlintlockPistolSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Flintlock Pistol";
            this.description = "The flintlock pistol will fight for you!";
            this.projectile = ModContent.ProjectileType<FlintlockPistolSummonProjectile>();

        }
    }
}

