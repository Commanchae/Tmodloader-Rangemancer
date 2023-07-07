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
    public class FlamethrowerSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<FlamethrowerSummonBuff>();
            shootSpeed = 7f;
            shootCooldown = 6;
            Projectile.width = 54;
            Projectile.height = 16;


            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.Flamethrower);


            shootSound = SoundID.Item34;
            specialSound = SoundID.Item20;
            specialShotCooldown = 12 * 5;

            percentNonConsume = 0.8f;
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            // Add some sound effects.
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            Vector2 normalizedShootVel = shootVel;
            normalizedShootVel.Normalize();
            normalizedShootVel *= shootSpeed;
            // Shoots normal bullet with 2 degree random rotation.

            
            // Plays normal shootingSound.
            Terraria.Audio.SoundEngine.PlaySound(shootSound);

            // After the shot, check for whether the player's holding the summon item.
            if (heldItem.ModItem is FlamethrowerSummon)
            {

                // Increment the counter.
                specialShotCounter++;
                if (specialShotCounter > specialShotCooldown)
                {
                    Projectile proj = Projectile.NewProjectileDirect(null, position, normalizedShootVel, ModContent.ProjectileType<CursedFlamesProjectile>(), damage, Projectile.knockBack, Main.myPlayer);
                    proj.friendly = true;
                    proj.hostile = false;
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);
                }
                else
                {
                    Projectile.NewProjectileDirect(null, position, normalizedShootVel, ProjectileID.Flames, damage, Projectile.knockBack, Main.myPlayer);
                }

            }
            // If player stops holding the weapon, reset the variables.
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    Projectile.NewProjectileDirect(null, position, normalizedShootVel, ProjectileID.Flames, damage, Projectile.knockBack, Main.myPlayer);
                }
                specialShotCounter = 0;

            }

        }


    }
}
