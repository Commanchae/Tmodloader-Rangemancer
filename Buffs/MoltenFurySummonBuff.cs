using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Buffs
{
    public class MoltenFurySummonBuff : SummonBuff
    {

        public MoltenFurySummonBuff()
        {
        }
        public override void setAttributes()
        {
            this.name = "Molten Fury";
            this.description = "This molten fury will fight for you!";
            this.projectile = ModContent.ProjectileType<MoltenFurySummonProjectile>();

        }
    }
}
