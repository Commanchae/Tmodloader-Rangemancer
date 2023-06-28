using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class WoodenBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<WoodenBowSummonBuff>();
            projectile = ModContent.ProjectileType<WoodenBowSummonProjectile>();
            name = "Enchanted Wooden Bow";
            damage = 7;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.WoodenBow;


            itemDescription = "Summons an enchanted [c/cd4b4b:wooden bow] to fight for you!";
            abilityDescription = "Shoots additional seeds every three shots.";
            abilityNameColor = "8DB600";
            abilityName = "Seed Burst";

            //Tooltip.SetDefault("Summons an enchanted wooden bow to fight for you!\nSpecial ability: Shoots additional seeds every three shots.");
        }

    }
}