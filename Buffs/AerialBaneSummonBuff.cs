using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class AerialBaneSummonBuff : SummonBuff
    {

        public AerialBaneSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Aerial Bane";
            this.description = "The aerial bane will fight for you!";
            this.projectile = ModContent.ProjectileType<AerialBaneSummonProjectile>();

        }
    }
}

