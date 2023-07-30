using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Items.Guns
{
    public class VenusMagnumSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<VenusMagnumSummonBuff>();
            projectile = ModContent.ProjectileType<VenusMagnumSummonProjectile>();
            name = "Enchanted Venus Magnum";
            damage = (int) (50 * 0.75f);
            knockBack = 5.5f;
            mana = 70;
            itemID = ItemID.VenusMagnum;

            itemDescription = "Summons an enchanted [c/2fff05:venus magnum] to fight for you!";
            abilityDescription = "Shoots a plantera seed every tenth shot.";
            abilityNameColor = "f34aff";
            abilityName = "Plantera's Presence";

        }

    }
}
