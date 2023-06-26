﻿using System;
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
using IL.Terraria.Audio;
using Bowmancer.Items.Bows;

namespace Bowmancer.Projectiles.Bows
{
    public class BorealBowSummonProjectile : AdditionalProjectileProjectile
    {
        public override void setAttributes()
        {
            // Essential
            Projectile.width = 16;
            Projectile.height = 32;

            // Class Specific.
            buff = ModContent.BuffType<BorealBowSummonBuff>();
            shootSpeed = 6.6f;
            shootCooldown = 30;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item5;

            specialShotCooldown = 3;
            itemName = "Boreal Bow Summon";
            respectiveItem = new Item(ItemID.BorealWoodBow);
            specialAmmoID = ProjectileID.SnowBallFriendly;
            dustID = DustID.Snow;
            noOfAdditionalProjectiles = 3;
            specialShotSpread = 30;
            specialProjectileSpeedMultiplier = 1f;





        }
    }
   
}
