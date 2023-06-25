using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Bows;

namespace Bowmancer.Items.Bows
{
    public class BeeBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BeeBowSummonBuff>();
            projectile = ModContent.ProjectileType<BeeBowSummonProjectile>();
            name = "The Bee's Knees Summon";
            damage = 14;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.BeesKnees;
        }

    }
}
