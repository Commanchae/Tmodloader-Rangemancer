using Terraria.ModLoader;
using Terraria;
using System.ComponentModel.DataAnnotations;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class TsunamiSummonBuff : SummonBuff
    {

        public TsunamiSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Tsunami";
            this.description = "This tsunami will fight for you!";
            this.projectile = ModContent.ProjectileType<TsunamiSummonProjectile>();

        }
    }
}
