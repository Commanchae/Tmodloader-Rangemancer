using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class ChlorophyteShotbowSummonBuff : SummonBuff
    {

        public ChlorophyteShotbowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Chlorophyte Shotbow";
            this.description = "The chlorophyte shotbow will fight for you!";
            this.projectile = ModContent.ProjectileType<ChlorophyteShotbowSummonProjectile>();

        }
    }
}

