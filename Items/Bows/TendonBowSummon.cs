using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class TendonBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<TendonBowSummonBuff>();
            projectile = ModContent.ProjectileType<TendonBowSummonProjectile>();
            name = "Enchanted Tendon Bow";
            damage = 12;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.TendonBow;

            itemDescription = "Summons an enchanted [c/cd4b4b:tendon bow] to fight for you!";
            abilityDescription = "Shoots a blood arrow every other shot.";
            abilityNameColor = "dc0600";
            abilityName = "Blood Barrage";

            //Tooltip.SetDefault("Summons an enchanted, meaty tendon bow to fight for you!\nSpecial ability: Shoots a blood arrow every other shot.");


        }

    }
}