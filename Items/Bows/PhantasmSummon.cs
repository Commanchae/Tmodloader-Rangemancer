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
    public class PhantasmSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<PhantasmSummonBuff>();
            projectile = ModContent.ProjectileType<PhantasmSummonProjectile>();
            name = "Enchanted Phantasm";
            damage = (int)(50 * 0.5);
            knockBack = 2;
            mana = 40;
            itemID = ItemID.Phantasm;


            itemDescription = "Summons an enchanted [c/4bcfde:phantasm] to fight for you!";
            abilityDescription = "Continuous shooting will make the weapon shoot faster. Phantasm arrows will also be shot.";
            abilityNameColor = "4fedff";
            abilityName = "Lunar's Acceleration";
        }

    }
}
