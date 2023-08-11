using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Items.Guns
{
    public class FlamethrowerSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<FlamethrowerSummonBuff>();
            projectile = ModContent.ProjectileType<FlamethrowerSummonProjectile>();
            name = "Enchanted Flamethrower";
            damage = (int) (35 * 0.75f);
            knockBack = 0.3f;
            mana = 50;
            itemID = ItemID.Flamethrower;

            // Change
            itemDescription = "Summons an enchanted [c/ff6a3d:flamethrower] to fight for you!";
            abilityDescription = "Shoots out cursed flames after ability is activated.\nConsumes a lot more gel than the standard flamethrower model.";
            abilityNameColor = "00f018";
            abilityName = "Cursed Flamethrower";
        }

    }
}
