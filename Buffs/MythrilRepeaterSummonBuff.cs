using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
namespace Bowmancer.Buffs
{
    public class MythrilRepeaterSummonBuff : SummonBuff
    {

        public MythrilRepeaterSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Mythril Repeater";
            this.description = "The mythril repeater will fight for you!";
            this.projectile = ModContent.ProjectileType<MythrilRepeaterSummonProjectile>();

        }
    }
}

