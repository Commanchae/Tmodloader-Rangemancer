using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class PhantomPhoenixSummonBuff : SummonBuff
    {

        public PhantomPhoenixSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Phantom Phoenix";
            this.description = "The phantom phoenix will fight for you!";
            this.projectile = ModContent.ProjectileType<PhantomPhoenixSummonProjectile>();

        }
    }
}

