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

namespace Bowmancer.Projectiles.ProjectileWeapons.Guns
{
    public class SniperRifleSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<SniperRifleSummonBuff>();
            shootSpeed = 16f;
            shootCooldown = 36;
            Projectile.width = 62;
            Projectile.height = 24;


            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.SniperRifle);


            shootSound = SoundID.Item40;
            specialSound = SoundID.Item14;
            specialShotCooldown = 5;
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
            if (heldItem.ModItem is SniperRifleSummon)
            {
            // Increment the counter.
            specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    Projectile.NewProjectileDirect(null, position, shootVel, ProjectileID.BulletHighVelocity, (int) (damage * 2.0f), Projectile.knockBack, Main.myPlayer);
                    specialShotCounter = 0;
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);
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
