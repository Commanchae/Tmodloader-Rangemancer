using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;
namespace Bowmancer.Items.Guns
{
    public class ChainGunSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<ChainGunSummonBuff>();
            projectile = ModContent.ProjectileType<ChainGunSummonProjectile>();
            name = "Enchanted Chain Gun";
            damage = (int) (31 * 0.75f);
            knockBack = 0f;
            mana = 30;
            itemID = ItemID.ChainGun;

            itemDescription = "Summons an enchanted [c/FFE41E:chain gun] to fight for you!";
            abilityDescription = "Summons St. Nick's present every 20th shot!";
            abilityNameColor = "5fff03";
            abilityName = "St. Nick's Regards";
        }

    }
}
