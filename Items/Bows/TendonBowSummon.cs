using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Bows;

namespace Bowmancer.Items.Bows
{
    public class TendonBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<TendonBowSummonBuff>();
            projectile = ModContent.ProjectileType<TendonBowSummonProjectile>();
            name = "Tendon Bow Summon";
            damage = 12;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.TendonBow;


        }

    }
}