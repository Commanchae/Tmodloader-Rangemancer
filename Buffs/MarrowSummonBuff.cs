using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class MarrowSummonBuff : SummonBuff
    {

        public MarrowSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Marrow";
            this.description = "The marrow will fight for you!";
            this.projectile = ModContent.ProjectileType<MarrowSummonProjectile>();

        }
    }
}

