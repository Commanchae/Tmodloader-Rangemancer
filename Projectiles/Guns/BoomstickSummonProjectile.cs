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
using Bowmancer.Items.Guns;

namespace Bowmancer.Projectiles.Guns
{
    public class BoomstickSummonProjectile : ShotGunProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BoomstickSummonBuff>();
            // Essentials
            Projectile.width = 40;
            Projectile.height = 16;
            Projectile.knockBack = 5.75f;
            shootSpeed = 5.35f;
            shootCooldown = 40;
            specialShotCooldown = 5;
            itemName = "Boomstick Summon";

            // ShotGunProjectile
            spreadCount = 3f;
            spreadShotMultiplier = 2f;
            degreesSpread = 10;
            specialSpread = 15;

            // New Essentials
            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.Boomstick);

            // Sounds
            shootSound = SoundID.Item36;
            specialSound = SoundID.Item31;
        }
    }
}
