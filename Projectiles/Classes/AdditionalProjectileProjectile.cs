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

namespace Bowmancer.Projectiles
{
    public abstract class AdditionalProjectileProjectile : SummonProjectile
    {
        protected string itemName;
        protected float damageMultiplier = 1f;
        protected int specialAmmoID = ProjectileID.Seed;

        protected int dustID = DustID.Torch;
        protected int noOfAdditionalProjectiles = 2;
        protected int specialShotSpread = 10;
        protected float specialProjectileSpeedMultiplier = 1f;

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            Terraria.Audio.SoundEngine.PlaySound(shootSound);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
            
            if (heldItem.Name.Equals(itemName))
            {
                specialShotCounter++;

                if (specialShotCounter >= specialShotCooldown)
                {
                    
                    for (int i = 0; i < 3; i++)
                    {
                        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustID, Scale: 1.2f);

                    }
                    for (int i = 0; i < noOfAdditionalProjectiles; i++) { 
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, specialProjectileSpeedMultiplier*shootVel.RotatedByRandom(MathHelper.ToRadians(specialShotSpread)), specialAmmoID, (int)(damage), Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    }
                    specialShotCounter = 0;
                }
            }
            else
            {
                specialShotCounter = 0;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(shootSound);
            }
        }

    }
}
