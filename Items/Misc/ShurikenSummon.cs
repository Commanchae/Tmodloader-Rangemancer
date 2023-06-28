using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Misc;

namespace Bowmancer.Items.Misc
{
    public class ShurikenSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<ShurikenSummonBuff>();
            projectile = ModContent.ProjectileType<ShurikenSummonProjectile>();
            name = "Enchanted Shuriken";
            damage = 10;
            knockBack = 0;
            mana = 10;
            itemID = ItemID.Shuriken;

            itemDescription = "Summons an enchanted [c/FF5444:shuriken] to fight for you!\nConsumes shurikens (35% chance to not consume)";
            abilityDescription = "Increases attack speed every five shots (maximum of 5 stacks)";
            abilityNameColor = "FF0000";
            abilityName = "Relentless Fury";
        }

    }
}
