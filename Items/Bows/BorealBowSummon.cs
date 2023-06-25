using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Bows;

namespace Bowmancer.Items.Bows
{
    public class BorealBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BorealBowSummonBuff>();
            projectile = ModContent.ProjectileType<BorealBowSummonProjectile>();
            name = "Boreal Bow Summon";
            damage = 9;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.BorealWoodBow;
        }

    }
}
