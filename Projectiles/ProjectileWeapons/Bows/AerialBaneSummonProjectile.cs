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
    public class AerialBaneSummonProjectile : SummonProjectile
    {

        Vector2 normalizedShootVel = Vector2.Zero;

        public override void setAttributes()
        {
            Projectile.width = 28;
            Projectile.height = 58;

            buff = ModContent.BuffType<AerialBaneSummonBuff>();
            specialShotCooldown = 5;
            shootSpeed = 22f;
            shootCooldown = 30;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item75;
            specialSound = SoundID.Item88;

            respectiveItem = new Item(ItemID.DD2BetsyBow);


        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            // Normalized as it is not affected by other factors, only the gun's shootSpeed.


            for (int i = 0; i < 5; i++)
            {
                normalizedShootVel = shootVel;
                normalizedShootVel.Normalize();
                normalizedShootVel *= (shootSpeed - 3*i); // Ice Bow Not affected by Ammo speed.
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel, ProjectileID.DD2BetsyArrow, damage, Projectile.knockBack, Main.myPlayer);

            }
            Terraria.Audio.SoundEngine.PlaySound(shootSound);
            if (heldItem.ModItem is AerialBaneSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {

                    for (int i = 0; i < 5; i++)
                    {
                        int randomXOffset = rand.Next(-10, 11) * 8;
                        int randomYOffset = rand.Next(100, 301);
                        float randomRotation = rand.Next(-5, 5);

                        Vector2 arrow1_start = targetLocation - new Vector2(randomXOffset, 700 + randomYOffset);

                        Vector2 arrow1_velocity = calculateVelocity(shootSpeed, targetLocation - arrow1_start, true);

                        arrow1_velocity = arrow1_velocity.RotatedBy(MathHelper.ToRadians(randomRotation));

                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), arrow1_start, arrow1_velocity, ProjectileID.Meteor1, damage, Projectile.knockBack, Main.myPlayer);
                    }
                        Terraria.Audio.SoundEngine.PlaySound(specialSound);


                    specialShotCounter = 0;
                }
            }


        }
    }
}
