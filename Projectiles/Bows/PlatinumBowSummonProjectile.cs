using System;

using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Bowmancer.Buffs;
using Bowmancer.Items.Bows;

namespace Bowmancer.Projectiles.Bows
{
    public class PlatinumBowSummonProjectile : NewSummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<PlatinumBowSummonBuff>();
            shootSpeed = 6.6f;
            shootCooldown = 25;
            specialShotCooldown = 5;
        }

        protected override void handleShot(Item chosenAmmo, Vector2 position, Vector2 shootVel, float angleOffset, Vector2 targetCenter)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            if (heldItem.ModItem is PlatinumBowSummon)
            {
                specialShotCounter++;

                if (specialShotCounter >= specialShotCooldown)
                {
                    if (specialShotCounter >= specialShotCooldown + 2)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position + new Vector2(0, Projectile.height / 2), Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), ProjectileID.Grenade, (int)(Projectile.damage * 1.5f), Projectile.knockBack, Main.myPlayer);
                        specialShotCounter = 0;
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item4);
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.WhiteTorch);
                            Terraria.Audio.SoundEngine.PlaySound(SoundID.Coins);
                        }


                    }
                }


                else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position + new Vector2(0, Projectile.height / 2), Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
                    // Does not consume ammo if EndlessQuiver is used.
                    if (chosenAmmo.type != 3103)
                    {
                        Main.player[Projectile.owner].ConsumeItem(chosenAmmo.type);
                    }
                }
            }
            else
            {
                specialShotCounter = 0;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position + new Vector2(0, Projectile.height / 2), Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
                // Does not consume ammo if EndlessQuiver is used.
                if (chosenAmmo.type != 3103)
                {
                    Main.player[Projectile.owner].ConsumeItem(chosenAmmo.type);
                }
            }
            {
            }




        }
    }
}
