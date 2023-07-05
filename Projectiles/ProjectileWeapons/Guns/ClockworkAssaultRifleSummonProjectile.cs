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
using static Terraria.ModLoader.PlayerDrawLayer;
using Bowmancer.Items.Guns;

namespace Bowmancer.Projectiles.ProjectileWeapons.Guns
{
    public class ClockworkAssaultRifleSummonProjectile : SummonProjectile
    {

        bool bursting = false;
        int burstCounter = 0;
        int burstLimit = 2;
        bool reset = false;
        public override void setAttributes()
        {
            buff = ModContent.BuffType<ClockworkAssaultRifleSummonBuff>();
            shootSpeed = 7.75f;
            shootCooldown = 24;
            specialShotCooldown = 20;
            Projectile.width = 56;
            Projectile.height = 20;

            percentNonConsume = 0.33f;

            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.ClockworkAssaultRifle);


            shootSound = SoundID.Item31;
            specialSound = SoundID.Item31;

 
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
            if (bursting)
            {
                burstCounter++;
                consumeAmmoItem = false;
            }
            if (!bursting)
            {
                shootCooldown = 6;
                bursting = true;
                consumeAmmoItem = true;
                Terraria.Audio.SoundEngine.PlaySound(shootSound);
                specialShotCounter++;

                // Enhanced sound effect.

            }

            if (burstCounter >= burstLimit)
            {
                shootCooldown = 24;
                burstCounter = 0;
                bursting = false;
            }

            if (heldItem.ModItem is ClockworkAssaultRifleSummon)
            {
                if (specialShotCounter == specialShotCooldown)
                {
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item20);
                    for (int i = 0; i < 3; i++)
                    {
                        Dust.NewDust(position, Projectile.width, Projectile.height, DustID.RedTorch);
                    }
                }

                if (specialShotCounter >= specialShotCooldown)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(5)), chosenAmmo.shoot, (int)(damage * 0.30), Projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(-5)), chosenAmmo.shoot, (int) (damage * 0.30), Projectile.knockBack, Main.myPlayer);

                }
            }
            else
            {
                specialShotCounter = 0;
            }
        }
    }
}
