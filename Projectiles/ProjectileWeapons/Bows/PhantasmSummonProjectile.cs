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
    public class PhantasmSummonProjectile : SummonProjectile
    {


        public override void setAttributes()
        {
            // Essential
            Projectile.width = 54;
            Projectile.height = 32;

            // Class Specific.
            buff = ModContent.BuffType<PhantasmSummonBuff>();
            shootSpeed = 20;
            shootCooldown = 34;

            specialShotCooldown = 5;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item91;

            percentNonConsume = 0.667f;
            specialShotCooldown = 3;
            respectiveItem = new Item(ItemID.Phantasm);



        }
        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            for (int i = 0; i < 4; i++)
            {
                var proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(5)), chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
            }
            Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<PhantasmHomingProjectile>(), (int)(0.5 * damage), Projectile.knockBack, Main.myPlayer);

            Terraria.Audio.SoundEngine.PlaySound(shootSound);


            //Terraria.Audio.SoundEngine.PlaySound(shootSound);

            if (heldItem.ModItem is PhantasmSummon)     
            {
                    var proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<PhantasmHomingProjectile>(), (int) (0.5*damage), Projectile.knockBack, Main.myPlayer);

                    var proj2 = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(-20)), ModContent.ProjectileType<PhantasmHomingProjectile>(), (int) (0.5*damage), Projectile.knockBack, Main.myPlayer);


                    PhantasmHomingProjectile p1 = (PhantasmHomingProjectile)proj.ModProjectile;
                    p1.SetTarget(targetEnemy);

                    PhantasmHomingProjectile p2 = (PhantasmHomingProjectile)proj2.ModProjectile;
                    p2.SetTarget(targetEnemy);


                    Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    specialShotCounter++;
                if (specialShotCounter >= specialShotCooldown && shootCooldown > 18)
                {
                    shootCooldown -= 2;
                    specialShotCounter = 0;
                }

                }
            }
        }



    

}
