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
    public class TitaniumRepeaterSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<TitaniumRepeaterSummonBuff>();
            projectile = ModContent.ProjectileType<TitaniumRepeaterSummonProjectile>();
            name = "Enchanted Titanium Repeater";
            damage = 42;
            knockBack = 2.5f;
            mana = 45;
            itemID = ItemID.TitaniumRepeater;


            itemDescription = "Summons an enchanted [c/a7a6a3:titanium repeater] to fight for you!";
            abilityDescription = "Fires two additional arrows every third shot.";
            abilityNameColor = "a7a6a3";
            abilityName = "Triple Volley";
        }

    }
}
