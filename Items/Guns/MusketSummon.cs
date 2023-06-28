using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Items.Guns
{
    public class MusketSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MusketSummonBuff>();
            projectile = ModContent.ProjectileType<MusketSummonProjectile>();
            name = "Enchanted Musket";
            damage = 30;
            knockBack = 5.25f;
            mana = 25;
            itemID = ItemID.Musket;

            itemDescription = "Summons an enchanted [c/8D0000:musket] to fight for you!";
            abilityDescription = "Shoots a shot dealing 50% more damage every fifth shot.";
            abilityNameColor = "FFEC08";
            abilityName = "Critical Strike";
        }

    }
}
