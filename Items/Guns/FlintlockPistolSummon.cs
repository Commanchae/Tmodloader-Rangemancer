using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;
namespace Bowmancer.Items.Guns
{
    public class FlintlockPistolSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<FlintlockPistolSummonBuff>();
            projectile = ModContent.ProjectileType<FlintlockPistolSummonProjectile>();
            name = "Enchanted Flintlock Pistol";
            damage = 11;
            knockBack = 3f;
            mana = 15;
            itemID = ItemID.FlintlockPistol;

            itemDescription = "Summons an enchanted [c/B0B0B0:flintlock pistol] to fight for you!";
            abilityDescription = "Shoots additional bullets every fifth shot.";
            abilityNameColor = "B0B0B0";
            abilityName = "Quickdraw";
        }

    }
}
