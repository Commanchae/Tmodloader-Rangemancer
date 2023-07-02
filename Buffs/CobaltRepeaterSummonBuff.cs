using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
namespace Bowmancer.Buffs
{
    public class CobaltRepeaterSummonBuff : SummonBuff
    {

        public CobaltRepeaterSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Cobalt Repeater";
            this.description = "The cobalt repeater will fight for you!";
            this.projectile = ModContent.ProjectileType<CobaltRepeaterSummonProjectile>();

        }
    }
}

