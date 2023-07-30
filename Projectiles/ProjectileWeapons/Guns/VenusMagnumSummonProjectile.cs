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
using Bowmancer.Projectiles.MiscProjectiles;
using Bowmancer.Buffs.MiscBuffs;

namespace Bowmancer.Projectiles.ProjectileWeapons.Guns
{
    public class VenusMagnumSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<VenusMagnumSummonBuff>();
            shootSpeed = 13.5f;
            shootCooldown = 9;
            Projectile.width = 52;
            Projectile.height = 28;


            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.VenusMagnum);


            shootSound = SoundID.Item41;
            specialSound = SoundID.Grass;
            specialShotCooldown = 10;
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            // Add some sound effects.
            Item heldItem = Main.player[Projectile.owner].HeldItem;


            // Plays normal shootingSound.
            Terraria.Audio.SoundEngine.PlaySound(shootSound);
            if (chosenAmmo.shoot == ProjectileID.Bullet)
            {
                Projectile.NewProjectileDirect(null, position, shootVel, ProjectileID.BulletHighVelocity, damage, Projectile.knockBack, Main.myPlayer);
            }
            else
            {
                Projectile.NewProjectileDirect(null, position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);

            }
            // After the shot, check for whether the player's holding the summon item.
            if (heldItem.ModItem is VenusMagnumSummon)
            {
            // Increment the counter.
            specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    Projectile planteraProjectile =  Projectile.NewProjectileDirect(null, position, shootVel, ProjectileID.SeedPlantera, damage, Projectile.knockBack, Main.myPlayer);
                    planteraProjectile.friendly = true;
                    planteraProjectile.hostile = false;
                    specialShotCounter = 0;
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);

                    Main.player[Projectile.owner].AddBuff(ModContent.BuffType<AmmoSavingBuff>(), 18000);

                }

            }
            // If player stops holding the weapon, reset the variables.
            else
            {
                specialShotCounter = 0;

            }

        }


    }
}
