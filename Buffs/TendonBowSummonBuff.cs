using Terraria.ModLoader;
using Terraria;
using System.ComponentModel.DataAnnotations;
using Bowmancer.Projectiles.Bows;

namespace Bowmancer.Buffs
{
    public class TendonBowSummonBuff : SummonBuff
    {

        public TendonBowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Tendon Bow";
            this.description = "This tendon bow will fight for you!";
            this.projectile = ModContent.ProjectileType<TendonBowSummonProjectile>();

        }
    }
}
