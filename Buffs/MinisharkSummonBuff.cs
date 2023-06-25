using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.Guns;

namespace Bowmancer.Buffs
{
    public class MinisharkSummonBuff : SummonBuff
    {

        public MinisharkSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Minishark";
            this.description = "The minishark will fight for you!";
            this.projectile = ModContent.ProjectileType<MinisharkSummonProjectile>();

        }
    }
}

