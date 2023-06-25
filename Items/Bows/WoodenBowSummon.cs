using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Bows;

namespace Bowmancer.Items.Bows
{
    public class WoodenBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<WoodenBowSummonBuff>();
            projectile = ModContent.ProjectileType<WoodenBowSummonProjectile>();
            name = "Wooden Bow Summon";
            damage = 7;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.WoodenBow;
        }

    }
}