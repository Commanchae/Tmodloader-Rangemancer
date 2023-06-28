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
    public class BorealBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BorealBowSummonBuff>();
            projectile = ModContent.ProjectileType<BorealBowSummonProjectile>();
            name = "Enchanted Boreal Bow";
            damage = 9;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.BorealWoodBow;


            itemDescription = "Summons an enchanted [c/7D6437:boreal bow] to fight for you!";
            abilityDescription = "Shoots two snowballs with every third shot!";
            abilityNameColor = "c3f5fa";
            abilityName = "Frostbite Volley";
        }

    }
}
