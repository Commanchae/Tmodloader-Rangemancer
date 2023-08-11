using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Items.Guns
{
    public class UndertakerSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<UndertakerSummonBuff>();
            projectile = ModContent.ProjectileType<UndertakerSummonProjectile>();
            name = "Enchanted Undertaker";
            damage = (int) (18 * 0.75f);
            knockBack = 2f;
            mana = 15;
            itemID = ItemID.TheUndertaker;

            itemDescription = "Summons an enchanted [c/FF5444:undertaker] to fight for you!";
            abilityDescription = "Shoots additional bullets after every fifth shot.";
            abilityNameColor = "B0B0B0";
            abilityName = "Multishot";

        }

    }
}
