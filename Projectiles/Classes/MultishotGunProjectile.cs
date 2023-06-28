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
    public abstract class MultishotGunProjectile : SummonProjectile
    {
        protected string itemName;
        protected int numberofShots;
        protected int spreadCount;
        protected int nextXShots;

        protected int dustID = DustID.Torch;

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            if (heldItem.Name.Equals(itemName))
            {

                if (specialShotCounter >= specialShotCooldown)
                {
                    if (specialShotCounter >= specialShotCooldown + nextXShots)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                        specialShotCounter = 0;
                        Terraria.Audio.SoundEngine.PlaySound(shootSound);
                    }
                    else
                    {

                            Dust.NewDust(position, Projectile.width, Projectile.height, dustID);
                            Dust.NewDust(position, Projectile.width, Projectile.height, dustID);
                            Dust.NewDust(position, Projectile.width, Projectile.height,  dustID);

                            for (int j = 0; j < spreadCount; j++)
                            {
                                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(10)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                            }

                            Terraria.Audio.SoundEngine.PlaySound(specialSound);
                            Terraria.Audio.SoundEngine.PlaySound(shootSound);
                        


                    }
                }


                else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(shootSound);
                }
                specialShotCounter++;
            }
            else
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                specialShotCounter = 0;
                Terraria.Audio.SoundEngine.PlaySound(shootSound);
            }
        }
    }

}
