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
    public class AerialBaneSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<AerialBaneSummonBuff>();
            projectile = ModContent.ProjectileType<AerialBaneSummonProjectile>();
            name = "Enchanted Aerial Bane";
            damage = (int)(39 * 0.75);
            knockBack = 4.5f;
            mana = 40;
            itemID = ItemID.DD2BetsyBow;


            itemDescription = "Summons an enchanted [c/882134:aerial bane] to fight for you!";
            abilityDescription = "Sends meteors from above crashing down every fifth shot.";
            abilityNameColor = "9c2400";
            abilityName = "Justice from Above";
        }

    }
}
