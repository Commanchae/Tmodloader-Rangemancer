using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
namespace Bowmancer.Buffs
{
    public class AdamantiteRepeaterSummonBuff : SummonBuff
    {

        public AdamantiteRepeaterSummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Adamantite Repeater";
            this.description = "The adamantite repeater will fight for you!";
            this.projectile = ModContent.ProjectileType<AdamantiteRepeaterSummonProjectile>();

        }
    }
}

