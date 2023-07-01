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
using static Terraria.ModLoader.PlayerDrawLayer;
using Bowmancer.Items.Guns;

namespace Bowmancer.Projectiles.ProjectileWeapons.Guns
{
    public class OnyxBlasterSummonProjectile : SummonProjectile
    {
        Vector2 normalizedShootVel = Vector2.Zero;
        public override void setAttributes()
        {
            buff = ModContent.BuffType<OnyxBlasterSummonBuff>();
            shootSpeed = 14;
            shootCooldown = 48;
            specialShotCooldown = 5;
            Projectile.width = 56;
            Projectile.height = 22;

            percentNonConsume = 0.33f;

            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.OnyxBlaster);


            shootSound = SoundID.Item36;
            specialSound = SoundID.Item31;

            

 
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            // Normalized as it is not affected by other factors, only the gun's shootSpeed.
            normalizedShootVel = shootVel;
            normalizedShootVel.Normalize();
            normalizedShootVel *= shootSpeed;
            for (int i = 0; i < 4; i++)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(10)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
            }
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel, ProjectileID.BlackBolt, Projectile.damage, Projectile.knockBack, Main.myPlayer);

            Terraria.Audio.SoundEngine.PlaySound(shootSound);

            if (heldItem.ModItem is OnyxBlasterSummon)
            {
                if (specialShotCounter >= specialShotCooldown)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedBy(MathHelper.ToRadians(-20)), ProjectileID.BlackBolt, (int) (Projectile.damage * 0.75f), Projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedBy(MathHelper.ToRadians(-10)), ProjectileID.BlackBolt, (int)(Projectile.damage * 1.5f), Projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedBy(MathHelper.ToRadians(10)), ProjectileID.BlackBolt, (int)(Projectile.damage * 0.75f), Projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedBy(MathHelper.ToRadians(20)), ProjectileID.BlackBolt, (int)(Projectile.damage * 1.5f), Projectile.knockBack, Main.myPlayer);

                    specialShotCounter = 0;
                }

                specialShotCounter++;

            }

        }
    }
}
