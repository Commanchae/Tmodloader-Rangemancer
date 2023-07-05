using System;

using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Bowmancer.Buffs;
using Bowmancer.Items.Bows;

namespace Bowmancer.Projectiles.ProjectileWeapons.Bows
{
    public class GoldBowSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            //Essentials
            Projectile.width = 16;
            Projectile.height = 32;

            buff = ModContent.BuffType<GoldBowSummonBuff>();
            shootSpeed = 6.6f;
            specialShotCooldown = 5;
            shootCooldown = 26;

            respectiveItem = new Item(ItemID.GoldBow);
            // Bow Specific.
            shootFromCenter = true;
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            if (heldItem.ModItem is GoldBowSummon)
            {


                if (specialShotCounter >= specialShotCooldown)
                {
                    if (specialShotCounter >= specialShotCooldown + 2)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.JestersArrow, (int)(damage * 1.5f), Projectile.knockBack, Main.myPlayer);
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(-20)), ProjectileID.JestersArrow, (int)(damage * 1.5f), Projectile.knockBack, Main.myPlayer);
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(-10)), ProjectileID.JestersArrow, (int)(damage * 1.5f), Projectile.knockBack, Main.myPlayer);
                        specialShotCounter = 0;
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item4);
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.YellowTorch);
                            Terraria.Audio.SoundEngine.PlaySound(SoundID.Coins);
                        }


                    }
                }


                else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
                }
                specialShotCounter++;
            }
            else
            {
                specialShotCounter = 0;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
            }


        }
    }
}
