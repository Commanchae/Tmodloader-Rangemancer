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
using Bowmancer.Items.Guns;

namespace Bowmancer.Projectiles
{
    public abstract class MultishotGunProjectile : GunSummonProjectile
    {
        protected string itemName;
        protected int numberofShots;
        protected int spreadCount;
        protected int nextXShots;

        protected int dustID = DustID.Torch;

        protected override void handleShot(Item chosenAmmo, Vector2 position, Vector2 shootVel, float angleOffset, Vector2 targetCenter)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            if (heldItem.Name.Equals(itemName))
            {
                specialShotCounter++;
                
                if (specialShotCounter >= specialShotCooldown)
                {
                    if (specialShotCounter >= specialShotCooldown + nextXShots)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                        specialShotCounter = 0;
                        Terraria.Audio.SoundEngine.PlaySound(SoundID.Item11);
                    }
                    else
                    {
                        for (int i = 0; i < numberofShots; i++)
                        {
                            Dust.NewDust(position, Projectile.width, Projectile.height, dustID);
                            Dust.NewDust(position, Projectile.width, Projectile.height, dustID);
                            Dust.NewDust(position, Projectile.width, Projectile.height, dustID);

                            for (int j = 0; j < spreadCount; j++)
                            {
                                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset + (float) rand.Next(-1,2))), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                            }

                            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item31);
                            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item11);
                        }


                    }
                }


                else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item11);
                }
            }
            else
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                specialShotCounter = 0;
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item11);
            }
            consumeAmmo(chosenAmmo.type);
            specialShotCounter++;
        }
    }

}
