using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
namespace Bowmancer.Buffs
{
    public class HallowedRepeaterSummonBuff : SummonBuff
    {

        public HallowedRepeaterSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Hallowed Repeater";
            this.description = "The hallowed repeater will fight for you!";
            this.projectile = ModContent.ProjectileType<HallowedRepeaterSummonProjectile>();

        }
    }
}

