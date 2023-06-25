using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Guns;

namespace Bowmancer.Items.Guns
{
    public class FlintlockPistolSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<FlintlockPistolSummonBuff>();
            projectile = ModContent.ProjectileType<FlintlockPistolSummonProjectile>();
            name = "Flintlock Pistol Summon";
            damage = 10;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.FlintlockPistol;
        }

    }
}
