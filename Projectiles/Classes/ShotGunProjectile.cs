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
    public abstract class ShotGunProjectile : GunSummonProjectile
    {
        protected string itemName;
        protected float spreadCount;
        protected float spreadShotMultiplier = 1f;
        protected int degreesSpread = 30;
        protected int specialSpread = 60;

        protected int dustID = DustID.Torch;

        protected override void handleShot(Item chosenAmmo, Vector2 position, Vector2 shootVel, float angleOffset, Vector2 targetCenter)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            if (heldItem.Name.Equals(itemName))
            {
                specialShotCounter++;
                float specialShotMultiplier = 1;
                float degreesShotSpread = degreesSpread;
                if (specialShotCounter >= specialShotCooldown)
                {
                    specialShotMultiplier = spreadShotMultiplier;
                    degreesShotSpread = specialSpread;
                    specialShotCounter = 0;

                }
                for (int i = 0; i < spreadCount * specialShotMultiplier; i++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(degreesShotSpread)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                }
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item36);
                consumeAmmo(chosenAmmo.type);
            }
            else
            {
                specialShotCounter = 0;
                for (int i = 0; i < spreadCount; i++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(degreesSpread)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                }
            }
        }

    }
}
