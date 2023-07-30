using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Items.Guns
{
    public class SniperRifleSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<SniperRifleSummonBuff>();
            projectile = ModContent.ProjectileType<SniperRifleSummonProjectile>();
            name = "Enchanted Sniper Rifle";
            damage = (int) (185 * 0.75f);
            knockBack = 5.5f;
            mana = 50;
            itemID = ItemID.SniperRifle;

            itemDescription = "Summons an enchanted [c/969696:sniper rifle] to fight for you!";
            abilityDescription = "Shoots a bullet that deals double damage every fifth shot.";
            abilityNameColor = "ff1f1f";
            abilityName = "Target Confirmed";

        }

    }
}
