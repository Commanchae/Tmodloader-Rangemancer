using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class VortexBeaterSummonBuff : SummonBuff
    {

        public VortexBeaterSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Vortex Beater";
            this.description = "The vortex beater will fight for you!";
            this.projectile = ModContent.ProjectileType<VortexBeaterSummonProjectile>();

        }
    }
}

