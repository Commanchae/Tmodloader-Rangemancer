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
            shootSpeed = 5;
            shootCooldown = 16;
            specialShotCooldown = 5;
            itemName = "Flintlock Pistol Summon";
            numberofShots = 3;
            nextXShots = 3;
            spreadCount = 3;
            Projectile.width = 36;
            Projectile.height = 22;
        }
    }
}
