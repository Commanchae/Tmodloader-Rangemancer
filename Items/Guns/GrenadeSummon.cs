using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Guns;

namespace Bowmancer.Items.Guns
{
    public class GrenadeSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<GrenadeSummonBuff>();
            projectile = ModContent.ProjectileType<GrenadeSummonProjectile>();
            name = "Grenade Summon";
            damage = 17;
            knockBack = 5.75f;
            mana = 10;
            itemID = ItemID.Grenade;
        }

    }
}
