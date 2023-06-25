using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Guns;

namespace Bowmancer.Items.Guns
{
    public class MusketSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MusketSummonBuff>();
            projectile = ModContent.ProjectileType<MusketSummonProjectile>();
            name = "Musket Summon";
            damage = 30;
            knockBack = 5.25f;
            mana = 10;
            itemID = ItemID.Musket;
        }

    }
}
