using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Misc;

namespace Bowmancer.Buffs
{
    public class GrenadeSummonBuff : SummonBuff
    {

        public GrenadeSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Grenade";
            this.description = "The grenade will send its friends to fight for you!";
            this.projectile = ModContent.ProjectileType<GrenadeSummonProjectile>();

        }
    }
}

