using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
using System.Collections.Generic;

namespace Bowmancer.Items.Bows
{
    public class DemonBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<DemonBowSummonBuff>();
            projectile = ModContent.ProjectileType<DemonBowSummonProjectile>();
            name = "Enchanted Demon Bow";
            damage = 12;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.DemonBow;

            itemDescription = "Summons an enchanted [c/8a2be2:demon bow] to fight for you!";
            abilityDescription = "Shoots an unholy arrow every other shot.";
            abilityNameColor = "666999";
            abilityName = "Sinister Shot";
        }

    }
}