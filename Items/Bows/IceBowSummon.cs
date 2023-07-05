using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class IceBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<IceBowSummonBuff>();
            projectile = ModContent.ProjectileType<IceBowSummonProjectile>();
            name = "Enchanted Ice Bow";
            damage = 35;
            knockBack = 4.5f;
            mana = 55;
            itemID = ItemID.IceBow;

            itemDescription = "Summons an enchanted [c/8ab7ff:ice bow] to fight for you!";
            abilityDescription = "Shoots between 1 to 5 snowflakes every fifth shot.";
            abilityNameColor = "8ab7ff";
            abilityName = "Snowflake";

            //Tooltip.SetDefault("Summons an enchanted, meaty tendon bow to fight for you!\nSpecial ability: Shoots a blood arrow every other shot.");


        }

    }
}