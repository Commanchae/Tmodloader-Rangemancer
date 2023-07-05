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
using Bowmancer.Items.Bows;

namespace Bowmancer.Projectiles.ProjectileWeapons.Bows
{
    public class DaedalusSummonProjectile : SummonProjectile
    {
        protected int heightOffset = 700;
        protected int numberOfSpecialProjectiles = 0;

        public override void setAttributes()
        {
            // Essential
            Projectile.width = 30;
            Projectile.height = 56;

            // Class Specific.
            buff = ModContent.BuffType<DaedalusSummonBuff>();
            shootSpeed = 12;
            shootCooldown = 19;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item30;

            // Daedalus Specific
            numberOfSpecialProjectiles = 0;

            specialShotCooldown = 20;
            respectiveItem = new Item(ItemID.DaedalusStormbow);



        }
        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            int numberOfProjectiles = 3 + rand.Next(0, 2) + numberOfSpecialProjectiles;

            //targetLocation
            // Arrow start location.

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                int randomXOffset = rand.Next(-10, 11) * 8;
                int randomYOffset = rand.Next(100, 301);
                float randomRotation = rand.Next(-5,5);

                Vector2 arrow1_start = targetLocation - new Vector2(randomXOffset, heightOffset + randomYOffset);

                Vector2 arrow1_velocity = calculateVelocity(shootSpeed + chosenAmmo.shootSpeed, targetLocation - arrow1_start, true);

                arrow1_velocity = arrow1_velocity.RotatedBy(MathHelper.ToRadians(randomRotation));

                // Calculate for rotation.
                calculateVelocity(1, shootVel, false);
                    
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), arrow1_start, arrow1_velocity, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
            
            }
            Terraria.Audio.SoundEngine.PlaySound(shootSound);

            if (heldItem.ModItem is DaedalusSummon)
            {
                specialShotCounter++;
                if (specialShotCounter >= specialShotCooldown)
                {
                    if (numberOfSpecialProjectiles <= 3)
                    {
                        numberOfSpecialProjectiles += 1;

                        for (int i = 0; i < 5; i++)
                        {
                            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.ManaRegeneration, Scale: 1.2f);

                        }
                        Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    }
                    if (numberOfSpecialProjectiles == 4)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch, Scale: 1.5f);

                        }
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item29);
                        numberOfSpecialProjectiles += 1;
                    };
                    
                    specialShotCounter = 0;
                }
            }
            else
            {
                numberOfSpecialProjectiles = 0;
                specialShotCounter = 0;
            }


        }



    }

}
