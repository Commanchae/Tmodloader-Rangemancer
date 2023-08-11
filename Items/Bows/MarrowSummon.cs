using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class MarrowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MarrowSummonBuff>();
            projectile = ModContent.ProjectileType<MarrowSummonProjectile>();
            name = "Enchanted Marrow";
            damage = 48;
            knockBack = 4.7f;
            mana = 40;
            itemID = ItemID.Marrow;

            itemDescription = "Summons an enchanted [c/bfbfbf:marrow] to fight for you!";
            abilityDescription = "Shoots between 2 - 10 bones in random directions every fifth shot, doing 25% damage each.";
            abilityNameColor = "bfbfbf";
            abilityName = "Bone Shatter";

            //Tooltip.SetDefault("Summons an enchanted, meaty tendon bow to fight for you!\nSpecial ability: Shoots a blood arrow every other shot.");


        }

    }
}