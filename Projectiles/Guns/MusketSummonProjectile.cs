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
    public class MusketSummonProjectile : CritshotGunProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MusketSummonBuff>();
            shootSpeed = 9f;
            shootCooldown = 32;
            specialShotCooldown = 5;
            itemName = "Musket Summon";
            damageMultiplier = 1.5f;
            Projectile.width = 56;
            Projectile.height = 18;
            searchDistance = 700f;

            // New Essentials
            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.Musket);

            shootSound = SoundID.Item11;
            specialSound = SoundID.Item40;
        }
    }
}
