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
using Bowmancer.Items.Misc;

namespace Bowmancer.Projectiles.ProjectileWeapons.Misc
{
    public class ShurikenSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<ShurikenSummonBuff>();
            shootSpeed = 6f;
            shootCooldown = 40;
            specialShotCooldown = 5;
            Projectile.knockBack = 5.75f;
            Projectile.width = 22;
            Projectile.height = 22;

            percentNonConsume = 0.35f;

            isGun = false;
            shootFromCenter = true;
            useCustomAmmo = true;
            respectiveItem = new Item(ItemID.Shuriken);


        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            if (heldItem.ModItem is ShurikenSummon)
            {
                if (specialShotCounter >= specialShotCooldown && shootCooldown >= 20)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item37);
                    for (int i = 0; i < 10; i++)
                    {

                        Dust.NewDust(position, Projectile.width, Projectile.height, DustID.Torch);

                    }
                    specialShotCounter = 0;
                    if (shootCooldown >= 20)
                    {
                        shootCooldown -= 5;
                    }
                    if (shootCooldown < 20)
                    {
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item20);
                        for (int i = 0; i < 3; i++)
                        {
                            Dust.NewDust(position, Projectile.width, Projectile.height, DustID.RedTorch, Scale: 3f);
                        }
                    }
                }
                else if (specialShotCounter >= specialShotCooldown && shootCooldown < 20)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item20);
                    for (int i = 0; i < 3; i++)
                    {
                        Dust.NewDust(position, Projectile.width, Projectile.height, DustID.RedTorch);
                    }
                }
                else
                {

                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.Shuriken, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                }
                specialShotCounter++;
            }
            else
            {
                shootCooldown = 60;
                specialShotCounter = 0;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

            }

        }
    }
}
