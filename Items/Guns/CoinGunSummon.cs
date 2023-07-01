using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;
namespace Bowmancer.Items.Guns
{
    public class CoinGunSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<CoinGunSummonBuff>();
            projectile = ModContent.ProjectileType<CoinGunSummonProjectile>();
            name = "Enchanted Coin Gun";
            damage = 0;
            knockBack = 2f;
            mana = 30;
            itemID = ItemID.CoinGun;

            itemDescription = "Summons an enchanted [c/fbff00:coin gun] to fight for you!";
            abilityDescription = "After every ten shots, curses the target to drop more coins for 3 seconds.";
            abilityNameColor = "fdff69";
            abilityName = "The Curse of Midas";
        }

    }
}
