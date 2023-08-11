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
    public class PalladiumRepeaterSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<PalladiumRepeaterSummonBuff>();
            projectile = ModContent.ProjectileType<PalladiumRepeaterSummonProjectile>();
            name = "Enchanted Palladium Repeater";
            damage = 35;
            knockBack = 1.75f;
            mana = 40;
            itemID = ItemID.PalladiumRepeater;


            itemDescription = "Summons an enchanted [c/f27b52:palladium repeater] to fight for you!";
            abilityDescription = "Imbues the player with rapid healing every 20th shot.";
            abilityNameColor = "f27b52";
            abilityName = "Knight's Respite (Buff)";
        }

    }
}
