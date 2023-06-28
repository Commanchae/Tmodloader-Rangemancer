using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;
namespace Bowmancer.Buffs
{
    public class MusketSummonBuff : SummonBuff
    {

        public MusketSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Musket";
            this.description = "The musket will fight for you!";
            this.projectile = ModContent.ProjectileType<MusketSummonProjectile>();

        }
    }
}

