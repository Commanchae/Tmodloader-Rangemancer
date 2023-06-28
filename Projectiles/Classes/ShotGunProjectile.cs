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
using System.Drawing.Text;

namespace Bowmancer.Projectiles
{
    public abstract class ShotGunProjectile : SummonProjectile
    {
        protected string itemName;
        protected float spreadCount;
        protected float spreadShotMultiplier = 1f;
        protected int degreesSpread = 30;
        protected int specialSpread = 60;
        protected int dustID = DustID.Torch;

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            if (heldItem.Name.Equals(itemName))
            {

                float specialShotMultiplier = 1;
                float degreesShotSpread = degreesSpread;
                if (specialShotCounter >= specialShotCooldown)
                {
                    specialShotMultiplier = spreadShotMultiplier;
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    degreesShotSpread = specialSpread;
                    specialShotCounter = 0;

                }
                for (int i = 0; i < spreadCount * specialShotMultiplier; i++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(specialSpread)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                }
                Terraria.Audio.SoundEngine.PlaySound(shootSound);
                specialShotCounter++;
            }
            else
            {
                specialShotCounter = 0;
                for (int i = 0; i < spreadCount; i++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(degreesSpread)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                }
                Terraria.Audio.SoundEngine.PlaySound(shootSound);
            }
        }

    }
}
