using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class ShadowflameBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<ShadowflameBowSummonBuff>();
            projectile = ModContent.ProjectileType<ShadowflameBowSummonProjectile>();
            name = "Enchanted Shadowflame Bow";
            damage = 42;
            knockBack = 4.5f;
            mana = 40;
            itemID = ItemID.ShadowFlameBow;

            itemDescription = "Summons an enchanted [c/bb00ff:shadowflame bow] to fight for you!";
            abilityDescription = "Shoots two shadowflame knives every seventh shot.";
            abilityNameColor = "bb00ff";
            abilityName = "Shadowflame Edge";

            //Tooltip.SetDefault("Summons an enchanted, meaty tendon bow to fight for you!\nSpecial ability: Shoots a blood arrow every other shot.");


        }

    }
}