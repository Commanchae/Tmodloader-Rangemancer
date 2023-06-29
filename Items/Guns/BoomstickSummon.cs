using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;
namespace Bowmancer.Items.Guns
{
    public class BoomstickSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BoomstickSummonBuff>();
            projectile = ModContent.ProjectileType<BoomstickSummonProjectile>();
            name = "Enchanted Boomstick";
            damage = 14;
            knockBack = 5.75f;
            mana = 15;
            itemID = ItemID.Boomstick;


            itemDescription = "Summons an enchanted [c/b33b00:boomstick] to fight for you!";
            abilityDescription = "Shoots additional bursts of projectiles every five shots.";
            abilityNameColor = "FF5200";
            abilityName = "Rapid Blitz";
        }

    }
}
