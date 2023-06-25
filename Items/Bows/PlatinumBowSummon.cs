using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Bows;

namespace Bowmancer.Items.Bows
{
    public class PlatinumBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<PlatinumBowSummonBuff>();
            projectile = ModContent.ProjectileType<PlatinumBowSummonProjectile>();
            name = "Platinum Bow Summon";
            damage = 11;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.PlatinumBow;
        }

    }
}