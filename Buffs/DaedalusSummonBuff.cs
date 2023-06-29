using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class DaedalusSummonBuff : SummonBuff
    {

        public DaedalusSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Daedalus Stormbow";
            this.description = "The daedalus stormbow will fight for you!";
            this.projectile = ModContent.ProjectileType<DaedalusSummonProjectile>();

        }
    }
}

