using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class PlatinumBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<PlatinumBowSummonBuff>();
            projectile = ModContent.ProjectileType<PlatinumBowSummonProjectile>();
            name = "Enchanted Platinum Bow";
            damage = 11;
            knockBack = 3f;
            mana = 15;
            itemID = ItemID.PlatinumBow;


            itemDescription = "Summons an enchanted [c/e5e4e2:platinum bow] to fight for you!";
            abilityDescription = "Shoots a grenade after every five shots!";
            abilityNameColor = "C0C0C0";
            abilityName = "Explosive Arsenal";


        }

    }
}