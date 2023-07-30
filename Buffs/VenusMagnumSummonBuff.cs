using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class VenusMagnumSummonBuff : SummonBuff
    {

        public VenusMagnumSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Venus Magnum";
            this.description = "The venus magnum will fight for you!";
            this.projectile = ModContent.ProjectileType<VenusMagnumSummonProjectile>();

        }
    }
}

