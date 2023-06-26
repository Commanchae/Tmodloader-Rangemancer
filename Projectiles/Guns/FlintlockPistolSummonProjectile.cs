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

namespace Bowmancer.Projectiles.Guns
{
    public class FlintlockPistolSummonProjectile : MultishotGunProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<FlintlockPistolSummonBuff>();
            Projectile.width = 36;
            Projectile.height = 22;
            shootSpeed = 5;
            shootCooldown = 16;
            specialShotCooldown = 5;
            itemName = "Flintlock Pistol Summon";

            nextXShots = 1;
            spreadCount = 3;


            // New Essentials
            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.FlintlockPistol);

            shootSound = SoundID.Item11;
            specialSound = SoundID.Item31;
        }
    }
}
