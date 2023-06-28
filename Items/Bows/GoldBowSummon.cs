using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class GoldBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<GoldBowSummonBuff>();
            projectile = ModContent.ProjectileType<GoldBowSummonProjectile>();
            name = "Enchanted Gold Bow";
            damage = 10;
            knockBack = 3f;
            mana = 15;
            itemID = ItemID.GoldBow;

            itemDescription = "Summons an enchanted [c/fac369:gold bow] to fight for you!";
            abilityDescription = "Shoots an arc of 3 jester arrows after every fifth shot.";
            abilityNameColor = "f7f7f7";
            abilityName = "Jester's Gambit";

        }

    }
}