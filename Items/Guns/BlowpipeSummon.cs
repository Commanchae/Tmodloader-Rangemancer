using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Guns;

namespace Bowmancer.Items.Guns
{
    public class BlowpipeSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BlowpipeSummonBuff>();
            projectile = ModContent.ProjectileType<BlowpipeSummonProjectile>();
            name = "Enchanted Blowpipe";
            damage = 10;
            knockBack = 3.5f;
            mana = 10;
            itemID = ItemID.Blowpipe;

            itemDescription = "Summons an enchanted [c/2AF34D:blowpipe] to fight for you!";
            abilityDescription = "Shoots additional projectiles for two shots after every three shots.";
            abilityNameColor = "FF5200";
            abilityName = "Multishot";
        }

    }
}
