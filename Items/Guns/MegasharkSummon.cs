using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Items.Guns
{
    public class MegasharkSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MegasharkSummonBuff>();
            projectile = ModContent.ProjectileType<MegasharkSummonProjectile>();
            name = "Enchanted Megashark";
            damage = 25;
            knockBack = 1f;
            mana = 50;
            itemID = ItemID.Megashark;

            // Change
            itemDescription = "Summons an enchanted [c/4262ff:megashark] to fight for you!\n55% chance to not consume ammo";
            abilityDescription = "Gain a stack of hydrostorm every 43 shots for a maximum of 4 stacks. \nShoots an additional stream of water for each stack of hydrostorm.\nSwitching to another weapon removes all stacks.";
            abilityNameColor = "1940ff";
            abilityName = "Hydrostorm";
        }

    }
}
