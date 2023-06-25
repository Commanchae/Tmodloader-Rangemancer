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
using static Terraria.ModLoader.PlayerDrawLayer;
using Bowmancer.Items.Guns;

namespace Bowmancer.Projectiles.Guns
{
    public class MinisharkSummonProjectile : MultishotGunProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MinisharkSummonBuff>();
            shootSpeed = 7f;
            shootCooldown = 8;
            specialShotCooldown = 20;
            Projectile.width = 54;
            Projectile.height = 20;
            itemName = "Minishark Summon";
            numberofShots = 3;
            nextXShots = 3;
            spreadCount = 5;
            percentNonConsume = 0.33f;
        }

       
    }
}
