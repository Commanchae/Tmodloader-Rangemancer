using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Items.Guns
{
    public class VortexBeaterSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<VortexBeaterSummonBuff>();
            projectile = ModContent.ProjectileType<VortexBeaterSummonProjectile>();
            name = "Enchanted Vortex Beater";
            damage = (int) (50 * 0.50f);
            knockBack = 5.5f;
            mana = 50;
            itemID = ItemID.VortexBeater;

            itemDescription = "Summons an enchanted [c/52ffee:vortex beater] to fight for you!";
            abilityDescription = "Shoots out a barrage of missiles every 10 shots.";
            abilityNameColor = "52ffee";
            abilityName = "Vortex Barrage";

        }

    }
}
