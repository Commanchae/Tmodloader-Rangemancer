using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;
namespace Bowmancer.Items.Guns
{
    public class OnyxBlasterSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<OnyxBlasterSummonBuff>();
            projectile = ModContent.ProjectileType<OnyxBlasterSummonProjectile>();
            name = "Enchanted Onyx Blaster";
            damage = 28;
            knockBack = 6.5f;
            mana = 50;
            itemID = ItemID.OnyxBlaster;

            itemDescription = "Summons an enchanted [c/8B00A8:onyx blaster] to fight for you!";
            abilityDescription = "Shoots four additional onyx projectiles every fifth shot.";
            abilityNameColor = "8B00A8";
            abilityName = "Shadowstorm";
        }

    }
}
