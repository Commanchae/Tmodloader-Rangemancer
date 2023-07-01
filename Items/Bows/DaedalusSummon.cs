using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
using System.Collections.Generic;
using static Humanizer.In;

namespace Bowmancer.Items.Bows
{
    public class DaedalusSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<DaedalusSummonBuff>();
            projectile = ModContent.ProjectileType<DaedalusSummonProjectile>();
            name = "Enchanted Daedalus Stormbow";
            damage = 38;
            knockBack = 2.25f;
            mana = 50;
            itemID = ItemID.DaedalusStormbow;


            // TooltipLine description = new TooltipLine(this.Mod, "Tooltip1",  );
            itemDescription = "Summons an enchanted [c/adcdff:daedalus stormbow] to fight for you!";
            abilityDescription = "Gain a stack of aerial blessing every 20 shots for a maximum of 4 stacks.\nShoots an extra projectile for every stack of aerial blessing.\nSwitching to another weapon removes all stacks.";
            abilityNameColor = "6ba4ff";
            abilityName = "Aerial Blessing";


        }


    }
}
