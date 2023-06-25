using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Guns;
using Bowmancer.Projectiles.Misc;

namespace Bowmancer.Items.Guns
{
    public class SnowballCannonSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<SnowballCannonSummonBuff>();
            projectile = ModContent.ProjectileType<SnowballCannonSummonProjectile>();
            name = "Snowball Cannon Summon";
            damage = 10;
            knockBack = 1;
            mana = 10;
            itemID = ItemID.SnowballCannon;
        }

    }
}
