using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
namespace Bowmancer.Buffs
{
    public class PalladiumRepeaterSummonBuff : SummonBuff
    {

        public PalladiumRepeaterSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Palladium Repeater";
            this.description = "The palladium repeater will fight for you!";
            this.projectile = ModContent.ProjectileType<PalladiumRepeaterSummonProjectile>();

        }
    }
}

