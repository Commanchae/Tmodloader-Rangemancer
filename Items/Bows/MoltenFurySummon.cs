using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class MoltenFurySummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MoltenFurySummonBuff>();
            projectile = ModContent.ProjectileType<MoltenFurySummonProjectile>();
            name = "Enchanted Molten Fury";
            damage = 20;
            knockBack = 3f;
            mana = 20;
            itemID = ItemID.MoltenFury;


            itemDescription = "Summons an enchanted [c/ea7a55:molten fury] to fight for you!";
            abilityDescription = "Shoots a hellfire arrow after every third shot.";
            abilityNameColor = "FF4500";
            abilityName = "Inferno's Wrath";
        }

    }
}