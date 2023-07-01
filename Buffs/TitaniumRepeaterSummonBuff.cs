using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
namespace Bowmancer.Buffs
{
    public class TitaniumRepeaterSummonBuff : SummonBuff
    {

        public TitaniumRepeaterSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Titanium Repeater";
            this.description = "The titanium repeater will fight for you!";
            this.projectile = ModContent.ProjectileType<TitaniumRepeaterSummonProjectile>();

        }
    }
}

