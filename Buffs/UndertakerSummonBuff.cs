using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Buffs
{
    public class UndertakerSummonBuff : SummonBuff
    {

        public UndertakerSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "The Undertaker";
            this.description = "The undertaker will fight for you!";
            this.projectile = ModContent.ProjectileType<UndertakerSummonProjectile>();

        }
    }
}

