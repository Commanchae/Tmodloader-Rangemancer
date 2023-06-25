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

namespace Bowmancer.Projectiles.Bows
{
    public class BeeBowSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BeeBowSummonBuff>();
            shootSpeed = 8;
            shootCooldown = 24;
        }

        protected override void handleShot(Item chosenAmmo, Vector2 position, Vector2 shootVel, float angleOffset, Vector2 targetCenter)
        {
            Vector2 direction = targetCenter - position;
            direction.Normalize();
            if (chosenAmmo.shoot == 1)
            {


                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(direction*shootSpeed, Matrix.CreateRotationX(angleOffset)), ProjectileID.BeeArrow, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item97);
            }
            else
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
            }

            if (specialShotCounter >= specialShotCooldown)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(direction * shootSpeed, Matrix.CreateRotationX(angleOffset - 0.3f)), ProjectileID.HornetStinger, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(direction * shootSpeed, Matrix.CreateRotationX(angleOffset + 0.3f)), ProjectileID.HornetStinger, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                specialShotCounter = 0;
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item17);
            }


            // Does not consume ammo if EndlessQuiver is used.
            if (chosenAmmo.type != 3103)
            {
                Main.player[Projectile.owner].ConsumeItem(chosenAmmo.type);
            }
            specialShotCounter++;
        }
    
    }
}
