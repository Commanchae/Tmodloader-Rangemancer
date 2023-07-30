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

namespace Bowmancer.Projectiles.ProjectileWeapons.Guns
{
    public class ChainGunSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<ChainGunSummonBuff>();
            shootSpeed = 14f;
            shootCooldown = 4;
            specialShotCooldown = 20;
            Projectile.width = 56;
            Projectile.height = 20;

            percentNonConsume = 0.50f;

            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.ChainGun);


            shootSound = SoundID.Item41;
            specialSound = SoundID.Item42;

 
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(15)), chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);

            specialShotCounter++;
            if (specialShotCounter == specialShotCooldown)
            {
                var proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(30))*0.35f, ProjectileID.Present, damage, Projectile.knockBack, Main.myPlayer);
                proj.friendly = true;
                proj.hostile = false;
                specialShotCounter = 0;

            }


        }
    }
}
