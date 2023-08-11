using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class PhantasmSummonBuff : SummonBuff
    {

        public PhantasmSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Phantasm";
            this.description = "The phantasm will fight for you!";
            this.projectile = ModContent.ProjectileType<PhantasmSummonProjectile>();

        }
    }
}

