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
    public abstract class CritshotGunProjectile : GunSummonProjectile
    {
        protected string itemName;
        protected float damageMultiplier = 1f;

        protected int dustID = DustID.Torch;

        protected override void handleShot(Item chosenAmmo, Vector2 position, Vector2 shootVel, float angleOffset, Vector2 targetCenter)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            if (heldItem.Name.Equals(itemName))
            {
                specialShotCounter++;

                if (specialShotCounter >= specialShotCooldown)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke);
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Smoke);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, (int)(Projectile.damage * damageMultiplier), Projectile.knockBack, Main.myPlayer);

                    specialShotCounter = 0;
                }
                else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                }

                consumeAmmo(chosenAmmo.type);
                specialShotCounter++;
            }
            else
            {
                specialShotCounter = 0;
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                consumeAmmo(chosenAmmo.type);
            }
        }

    }
}
