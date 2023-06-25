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
            shootSpeed = 5.35f;
            shootCooldown = 40;
            specialShotCooldown = 5;
            itemName = "Boomstick Summon";
            spreadCount = 3f;
            spreadShotMultiplier = 2f;
            Projectile.knockBack = 5.75f;
            Projectile.width = 40;
            Projectile.height = 16;

            degreesSpread = 10;
            specialSpread = 15;
        }
    }
}
