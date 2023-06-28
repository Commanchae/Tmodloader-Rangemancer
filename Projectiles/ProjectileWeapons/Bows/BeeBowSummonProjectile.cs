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

namespace Bowmancer.Projectiles.ProjectileWeapons.Bows
{
    public class BeeBowSummonProjectile : AdditionalProjectileProjectile
    {
        public override void setAttributes()
        {
            // Essential
            Projectile.width = 30;
            Projectile.height = 56;

            // Class Specific.
            buff = ModContent.BuffType<BeeBowSummonBuff>();
            shootSpeed = 8;
            shootCooldown = 24;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item17;

            specialShotCooldown = 3;
            itemName = "Enchanted Bee's Knees";
            respectiveItem = new Item(ItemID.BeesKnees);
            specialAmmoID = ProjectileID.HornetStinger;
            dustID = DustID.Honey;
            noOfAdditionalProjectiles = 3;
            specialShotSpread = 30;
            specialProjectileSpeedMultiplier = 1f;

            // Bees Knees Specific (Convert wooden to bee arrow), so wooden is nonprojectile
            notProjectileMotion.Add(new Item(ItemID.WoodenArrow));


        }
        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;


            if (chosenAmmo.shoot != 1)
            {

                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(shootSound);
            }
            else
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.BeeArrow, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item97);
            }
            if (heldItem.Name.Equals(itemName))
            {
                specialShotCounter++;

                if (specialShotCounter >= specialShotCooldown)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustID, Scale: 1.2f);

                    }
                    for (int i = 0; i < noOfAdditionalProjectiles; i++)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, specialProjectileSpeedMultiplier * shootVel.RotatedByRandom(MathHelper.ToRadians(specialShotSpread)), specialAmmoID, (int)(Projectile.damage * damageMultiplier), Projectile.knockBack, Main.myPlayer);
                        Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    }
                    specialShotCounter = 0;
                }
            }
            else
            {
                specialShotCounter = 0;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(shootSound);
            }
        }



    }

}
