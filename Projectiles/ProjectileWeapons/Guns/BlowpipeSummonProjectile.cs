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

namespace Bowmancer.Projectiles.ProjectileWeapons.Guns
{
    public class BlowpipeSummonProjectile : MultishotGunProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BlowpipeSummonBuff>();
            Projectile.width = 46;
            Projectile.height = 24;
            shootSpeed = 6;
            shootCooldown = 20;
            specialShotCooldown = 5;
            itemName = "Enchanted Blowpipe";

            nextXShots = 3;
            spreadCount = 2;


            // New Essentials
            isGun = false;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.Blowpipe);

            shootSound = SoundID.Item63;
            dustID = DustID.Dirt;
            specialSound = SoundID.Item63;

        }
    }
}
