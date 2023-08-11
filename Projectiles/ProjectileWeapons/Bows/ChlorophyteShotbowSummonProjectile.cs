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
using Bowmancer.Projectiles.MiscProjectiles;

namespace Bowmancer.Projectiles.ProjectileWeapons.Bows
{
    public class ChlorophyteShotbowSummonProjectile : SummonProjectile
    {


        public override void setAttributes()
        {
            // Essential
            Projectile.width = 54;
            Projectile.height = 24;

            // Class Specific.
            buff = ModContent.BuffType<ChlorophyteShotbowSummonBuff>();
            shootSpeed = 9;
            shootCooldown = 25;

            specialShotCooldown = 3;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item8;


            specialShotCooldown = 3;
            respectiveItem = new Item(ItemID.ChlorophyteShotbow);



        }
        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            for (int i = 0; i < rand.Next(2, 4); i++)
            {
                var proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(5)), chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(shootSound);
            }


            //Terraria.Audio.SoundEngine.PlaySound(shootSound);

            if (heldItem.ModItem is ChlorophyteShotbowSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    var proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(20)), ModContent.ProjectileType<HomingProjectile>(), damage, Projectile.knockBack, Main.myPlayer);

                    var proj2 = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(-20)), ModContent.ProjectileType<HomingProjectile>(), damage, Projectile.knockBack, Main.myPlayer);


                    HomingProjectile p1 = (HomingProjectile)proj.ModProjectile;
                    p1.SetTarget(targetEnemy);

                    HomingProjectile p2 = (HomingProjectile)proj.ModProjectile;
                    p2.SetTarget(targetEnemy);

                    Terraria.Audio.SoundEngine.PlaySound(specialSound);



                    specialShotCounter = 0;

                }
            }
        }



    }

}
