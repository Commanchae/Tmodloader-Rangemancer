using System;

using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Bowmancer.Buffs;
using Bowmancer.Items.Bows;

namespace Bowmancer.Projectiles.ProjectileWeapons.Bows
{
    public class PlatinumBowSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            //Essentials
            Projectile.width = 16;
            Projectile.height = 32;

            buff = ModContent.BuffType<PlatinumBowSummonBuff>();
            shootSpeed = 6.6f;
            shootCooldown = 25;
            specialShotCooldown = 5;

            respectiveItem = new Item(ItemID.PlatinumBow);
            // Bow Specific.
            shootFromCenter = true;
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            consumeAmmoItem = true;
            if (heldItem.ModItem is PlatinumBowSummon)
            {

                if (specialShotCounter >= specialShotCooldown)
                {
                    if (specialShotCounter >= specialShotCooldown + 1)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.Grenade, (int)(Projectile.damage * 1.5f), Projectile.knockBack, Main.myPlayer);
                        specialShotCounter = 0;
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item4);
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch);
                            Terraria.Audio.SoundEngine.PlaySound(SoundID.Coins);
                            consumeAmmoItem = false;
                        }


                    }
                }


                else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);

                }
                specialShotCounter++;
            }
            else
            {
                specialShotCounter = 0;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
            }
            {
            }




        }
    }
}
