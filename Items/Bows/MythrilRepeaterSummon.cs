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
    public class MythrilRepeaterSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MythrilRepeaterSummonBuff>();
            projectile = ModContent.ProjectileType<MythrilRepeaterSummonProjectile>();
            name = "Enchanted Mythril Repeater";
            damage = 38;
            knockBack = 2;
            mana = 40;
            itemID = ItemID.MythrilRepeater;


            itemDescription = "Summons an enchanted [c/46b0ae:mythril repeater] to fight for you!";
            abilityDescription = "Causes the player to dash in the direction the player is moving every 20 shots.";
            abilityNameColor = "46b0ae";
            abilityName = "Occultic Dash";
        }

    }
}
