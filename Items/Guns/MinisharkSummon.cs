using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Items.Guns
{
    public class MinisharkSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MinisharkSummonBuff>();
            projectile = ModContent.ProjectileType<MinisharkSummonProjectile>();
            name = "Enchanted Minishark";
            damage = 7;
            knockBack = 0f;
            mana = 12;
            itemID = ItemID.Minishark;

            itemDescription = "Summons an enchanted [c/B0B0B0:minishark] to fight for you!\n33% chance to not consume ammo";
            abilityDescription = "Shoots additional bullets every 20th shot.";
            abilityNameColor = "B0B0B0";
            abilityName = "Multishot";
        }

    }
}
