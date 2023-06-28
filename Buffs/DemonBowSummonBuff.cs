using Terraria.ModLoader;
using Terraria;
using System.ComponentModel.DataAnnotations;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class DemonBowSummonBuff : SummonBuff
    {

        public DemonBowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Demon Bow";
            this.description = "This demon bow will fight for you!";
            this.projectile = ModContent.ProjectileType<DemonBowSummonProjectile>();

        }
    }
}