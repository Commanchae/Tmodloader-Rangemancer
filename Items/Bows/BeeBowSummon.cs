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
    public class BeeBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BeeBowSummonBuff>();
            projectile = ModContent.ProjectileType<BeeBowSummonProjectile>();
            name = "Enchanted Bee's Knees";
            damage = 14;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.BeesKnees;


            // TooltipLine description = new TooltipLine(this.Mod, "Tooltip1",  );
            itemDescription = "Summons an enchanted [c/fac369:Bee's Knees] to fight for you!";
            abilityDescription = "Shoots two stingers along with every third shot.";
            abilityNameColor = "5ac85a";
            abilityName = "Venomous Barrage";


        }


    }
}
