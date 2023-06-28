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
    public class UndertakerSummonProjectile : MultishotGunProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<UndertakerSummonBuff>();
            Projectile.width = 46;
            Projectile.height = 24;
            shootSpeed = 6;
            shootCooldown = 20;
            specialShotCooldown = 5;
            itemName = "Enchanted Undertaker";

            nextXShots = 2;
            spreadCount = 5;


            // New Essentials
            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.TheUndertaker);

            shootSound = SoundID.Item11;
            specialSound = SoundID.Item31;
        }
    }
}
