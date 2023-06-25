using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Bows;

namespace Bowmancer.Items.Bows
{
    public class GoldBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<GoldBowSummonBuff>();
            projectile = ModContent.ProjectileType<GoldBowSummonProjectile>();
            name = "Gold Bow Summon";
            damage = 10;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.GoldBow;
        }

    }
}