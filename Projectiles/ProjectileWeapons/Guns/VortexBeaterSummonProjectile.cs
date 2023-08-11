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
    public class VortexBeaterSummonProjectile : SummonProjectile
    {
        public int rocketCooldown = 3;
        public int rocketCounter = 0;
        public override void setAttributes()
        {
            buff = ModContent.BuffType<VortexBeaterSummonBuff>();
            shootSpeed = 14f;
            shootCooldown = 8;
            Projectile.width = 66;
            Projectile.height = 28;


            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.VortexBeater);

            percentNonConsume = 0.667f;
            shootSound = SoundID.Item41;
            specialSound = SoundID.Grass;
            specialShotCooldown = 10;

            // For vortex beater.

        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            // Add some sound effects.
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            Projectile.NewProjectileDirect(null, position, shootVel.RotatedByRandom(MathHelper.ToRadians(20)), chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
            Projectile.rotation += rand.Next(1, 11) * 0.02f;
            rocketCounter++;

            if (rocketCounter >= rocketCooldown)
            {
                Projectile.NewProjectileDirect(null, position, shootVel.RotatedByRandom(MathHelper.ToRadians(25)), ProjectileID.VortexBeaterRocket, (int) (0.75f *damage), Projectile.knockBack, Main.myPlayer);
                rocketCounter = 0;
            }
            // Plays normal shootingSound.
            Terraria.Audio.SoundEngine.PlaySound(shootSound);
            if (heldItem.ModItem is VortexBeaterSummon)
            {
                specialShotCounter++;
                if (specialShotCounter >= specialShotCooldown)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Projectile.NewProjectileDirect(null, position, shootVel.RotatedByRandom(MathHelper.ToRadians(25)), ProjectileID.VortexBeaterRocket, (int)(0.55f * damage), Projectile.knockBack, Main.myPlayer);

                    }
                    specialShotCounter = 0;
                }
            }
       

        }


    }
}
