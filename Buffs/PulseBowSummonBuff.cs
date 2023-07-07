using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class PulseBowSummonBuff : SummonBuff
    {

        public PulseBowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Pulse Bow";
            this.description = "The pulse bow will fight for you!";
            this.projectile = ModContent.ProjectileType<PulseBowSummonProjectile>();

        }
    }
}

