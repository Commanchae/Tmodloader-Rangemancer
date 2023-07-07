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
    public class PhantomPhoenixSummonProjectile : SummonProjectile
    {

        Vector2 normalizedShootVel = Vector2.Zero;

        private int phoenixShotCooldown = 3;
        private int phoenixShotCounter = 0;


        public override void setAttributes()
        {
            Projectile.width = 28;
            Projectile.height = 58;

            buff = ModContent.BuffType<PhantomPhoenixSummonBuff>();
            specialShotCooldown = 7;
            shootSpeed = 20;
            shootCooldown = 18;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.DD2_PhantomPhoenixShot;

            respectiveItem = new Item(ItemID.IceBow);


        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            // Normalized as it is not affected by other factors, only the gun's shootSpeed.
            normalizedShootVel = shootVel;
            normalizedShootVel.Normalize();
            normalizedShootVel *= shootSpeed; // Phantom Phoenix Not affected by Ammo speed.

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedByRandom(MathHelper.ToRadians(10)), chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedByRandom(MathHelper.ToRadians(10)), chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
            Terraria.Audio.SoundEngine.PlaySound(shootSound);
            if (heldItem.ModItem is PhantomPhoenixSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    int numberOfShots = rand.Next(2, 6);
                    for (int i = 0; i < numberOfShots; i++)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedByRandom(MathHelper.ToRadians(30)), ProjectileID.DD2PhoenixBowShot , (int)((damage) *0.75f), Projectile.knockBack, Main.myPlayer);
                        Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    }


                    specialShotCounter = 0;
                }
            }
            else
            {
                phoenixShotCounter++;
                if (phoenixShotCounter == phoenixShotCooldown)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedByRandom(MathHelper.ToRadians(15)), ProjectileID.DD2PhoenixBowShot, (int)((damage) * 0.75f), Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);

                    phoenixShotCounter = 0;
                }
            }


        }
    }
}
