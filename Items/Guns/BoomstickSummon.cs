using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Guns;

namespace Bowmancer.Items.Guns
{
    public class BoomstickSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BoomstickSummonBuff>();
            projectile = ModContent.ProjectileType<BoomstickSummonProjectile>();
            name = "Boomstick Summon";
            damage = 13;
            knockBack = 5.75f;
            mana = 10;
            itemID = ItemID.Boomstick;
        }

    }
}
