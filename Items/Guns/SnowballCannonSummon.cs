using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Items.Guns
{
    public class SnowballCannonSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<SnowballCannonSummonBuff>();
            projectile = ModContent.ProjectileType<SnowballCannonSummonProjectile>();
            name = "Enchanted Snowball Cannon";
            damage = 10;
            knockBack = 1;
            mana = 15;
            itemID = ItemID.SnowballCannon;

            itemDescription = "Summons an enchanted [c/2e7eff:snowball cannon] to fight for you!";
            abilityDescription = "Shoots additional snowballs with every third shot.";
            abilityNameColor = "78D8FF";
            abilityName = "Blizzard";
        }

    }
}
