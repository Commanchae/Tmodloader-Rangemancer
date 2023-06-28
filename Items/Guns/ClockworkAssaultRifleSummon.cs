using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;
namespace Bowmancer.Items.Guns
{
    public class ClockworkAssaultRifleSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<ClockworkAssaultRifleSummonBuff>();
            projectile = ModContent.ProjectileType<ClockworkAssaultRifleSummonProjectile>();
            name = "Enchanted Clockwork Assault Rifle";
            damage = 19;
            knockBack = 0f;
            mana = 30;
            itemID = ItemID.ClockworkAssaultRifle;

            itemDescription = "Summons an enchanted [c/FFE41E:clockwork assault rifle] to fight for you!";
            abilityDescription = "Shoots three streams of bullets after threshold reached.";
            abilityNameColor = "FF5200";
            abilityName = "Hell's Barrage";
        }

    }
}
