using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Guns;

namespace Bowmancer.Items.Guns
{
    public class MinisharkSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MinisharkSummonBuff>();
            projectile = ModContent.ProjectileType<MinisharkSummonProjectile>();
            name = "Minishark Summon";
            damage = 6;
            knockBack = 0f;
            mana = 10;
            itemID = ItemID.Minishark;
        }

    }
}
