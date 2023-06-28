using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class OnyxBlasterSummonBuff : SummonBuff
    {

        public OnyxBlasterSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Onyx Blaster";
            this.description = "The onyx blaster will CONQUER YOUR ENEMIES!";
            this.projectile = ModContent.ProjectileType<OnyxBlasterSummonProjectile>();

        }
    }
}

