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
    public class OrichalcumRepeaterSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<OrichalcumRepeaterSummonBuff>();
            projectile = ModContent.ProjectileType<OrichalcumRepeaterSummonProjectile>();
            name = "Enchanted Orichalcum Repeater";
            damage = 40;
            knockBack = 2;
            mana = 40;
            itemID = ItemID.OrichalcumRepeater;


            itemDescription = "Summons an enchanted [c/ff4fea:orichalcum repeater] to fight for you!";
            abilityDescription = "Fires an additional flower petal every third shot.";
            abilityNameColor = "ff4fea";
            abilityName = "Blossom's Edge";
        }

    }
}
