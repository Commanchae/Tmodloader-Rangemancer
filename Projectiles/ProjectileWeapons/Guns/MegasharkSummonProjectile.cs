using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
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
    public class MegasharkSummonProjectile : SummonProjectile
    {
        int waterStreamCount = 0;

        public override void setAttributes()
        {
            buff = ModContent.BuffType<MegasharkSummonBuff>();
            shootSpeed = 10f;
            shootCooldown = 7;
            Projectile.width = 70;
            Projectile.height = 28;

            percentNonConsume = 0.55f;

            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.Megashark);


            shootSound = SoundID.Item11;
            specialSound = SoundID.Item13;
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            // Add some sound effects.
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            // Shoots normal bullet with 2 degree random rotation.
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(2)), chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
            
            // Plays normal shootingSound.
            Terraria.Audio.SoundEngine.PlaySound(shootSound);

            // After the shot, check for whether the player's holding the summon item.
            if (heldItem.ModItem is MegasharkSummon)
            {

                // Increment the counter.
                specialShotCounter++;

                // Every 43 shots, add a stream and reset the counter. (Add stream only if streamCount is lower than 4).
                if (specialShotCounter > 43 && waterStreamCount < 4)
                {
                    waterStreamCount++;
                    specialShotCounter = 0;

                    // Plays the aqua scepter water sound.
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item29);

                    // Display water particles to signify enhancement.
                    for (int i = 0; i < 5; i++)
                    {
                        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Water, Scale: 1.5f);

                    }


                }


                // If stream count is at different levels, start shooting more projectiles.
                if (waterStreamCount >= 1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    }
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(10)), ProjectileID.WaterStream, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                }
                if (waterStreamCount >= 2)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(-10)), ProjectileID.WaterStream, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                }
                if (waterStreamCount >= 3)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(25)), ProjectileID.WaterStream, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                }
                if (waterStreamCount >= 4)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(-25)), ProjectileID.WaterStream, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                }

            }
            // If player stops holding the weapon, reset the variables.
            else
            {
                specialShotCounter = 0;
                waterStreamCount = 0;
            }

        }


    }
}
