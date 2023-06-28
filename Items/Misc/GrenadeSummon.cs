using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Misc;

namespace Bowmancer.Items.Misc
{
    public class GrenadeSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<GrenadeSummonBuff>();
            projectile = ModContent.ProjectileType<GrenadeSummonProjectile>();
            name = "Enchanted Grenade";
            damage = 17;
            knockBack = 5.75f;
            mana = 10;
            itemID = ItemID.Grenade;


            itemDescription = "Summons an enchanted [c/FF5444:grenade] to fight for you!\nConsumes grenades (50% chance)";
            abilityDescription = "Shoots a bouncy grenade every fifth throw.";
            abilityNameColor = "FF52D6";
            abilityName = "Bouncy Funtime";
        }

    }
}
