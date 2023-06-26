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
    public class GrenadeSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<GrenadeSummonBuff>();
            shootSpeed = 5.35f;
            shootCooldown = 90;
            specialShotCooldown = 5;
            Projectile.knockBack = 5.75f;
            Projectile.width = 14;
            Projectile.height = 20;

            percentNonConsume = 0.50f;

            isGun = false;
            shootFromCenter = true;
            useCustomAmmo = true;
            respectiveItem = new Item(ItemID.Grenade);


        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            if (heldItem.ModItem is GrenadeSummon)
            {
                if (specialShotCounter >= specialShotCooldown)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.BouncyGrenade, (int)(Projectile.damage), Projectile.knockBack, Main.myPlayer);
                    specialShotCounter = 0;
                }
                else
                {
                    
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.Grenade, (int)(Projectile.damage), Projectile.knockBack, Main.myPlayer);

                }
                specialShotCounter++;
            }
            else
            {
                specialShotCounter = 0;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.Grenade, (int)(Projectile.damage), Projectile.knockBack, Main.myPlayer);

            }

        }
    }
}
