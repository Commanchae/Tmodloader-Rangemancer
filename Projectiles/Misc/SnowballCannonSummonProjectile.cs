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
using Bowmancer.Items.Bows;

namespace Bowmancer.Projectiles.Misc
{
    public class SnowballCannonSummonProjectile : MultishotGunProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<SnowballCannonSummonBuff>();
            shootSpeed = 11f;
            shootCooldown = 19;
            specialShotCooldown = 5;
            respectiveItem = new Item(ItemID.SnowballCannon);
            itemName = "Snowball Cannon Summon";
            Projectile.width = 50;
            Projectile.height = 26;

            nextXShots = 1;
            spreadCount = 3;

            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
        }
    }
}
