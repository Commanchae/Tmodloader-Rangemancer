using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
namespace Bowmancer.Buffs
{
    public class OrichalcumRepeaterSummonBuff : SummonBuff
    {

        public OrichalcumRepeaterSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Orichalcum Repeater";
            this.description = "The orichalcum repeater will fight for you!";
            this.projectile = ModContent.ProjectileType<OrichalcumRepeaterSummonProjectile>();

        }
    }
}

