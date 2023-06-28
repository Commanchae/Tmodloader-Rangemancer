using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Bowmancer.Buffs;
using System.Collections.Specialized;
using Bowmancer.Items;
using IL.Terraria.Audio;
using Bowmancer.Items.Bows;

namespace Bowmancer.Projectiles.ProjectileWeapons.Bows
{
    public class WoodenBowSummonProjectile : AdditionalProjectileProjectile
    {
        public override void setAttributes()
        {
            // Essential
            Projectile.width = 16;
            Projectile.height = 32;

            // Class Specific.
            buff = ModContent.BuffType<WoodenBowSummonBuff>();
            shootSpeed = 6.1f;
            shootCooldown = 30;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Dig;

            specialShotCooldown = 3;
            itemName = "Enchanted Wooden Bow";
            respectiveItem = new Item(ItemID.WoodenBow);
            specialAmmoID = ProjectileID.Seed;
            dustID = DustID.Dirt;
            noOfAdditionalProjectiles = 2;
            specialShotSpread = 30;
            specialProjectileSpeedMultiplier = 1f;





        }
    }
}
