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
using Bowmancer.Items.Bows;

namespace Bowmancer.Projectiles.ProjectileWeapons.Bows
{
    public class ShadowflameBowSummonProjectile : SummonProjectile
    {

        Vector2 normalizedShootVel = Vector2.Zero;

        public override void setAttributes()
        {
            Projectile.width = 20;
            Projectile.height = 40;

            buff = ModContent.BuffType<ShadowflameBowSummonBuff>();
            specialShotCooldown = 7;
            shootSpeed = 11;
            shootCooldown = 20;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item102;
            specialSound = SoundID.Item8;

            respectiveItem = new Item(ItemID.ShadowFlameBow);


        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            // Normalized as it is not affected by other factors, only the gun's shootSpeed.
            normalizedShootVel = shootVel;
            normalizedShootVel.Normalize();
            normalizedShootVel *= shootSpeed + chosenAmmo.shootSpeed;

            Terraria.Audio.SoundEngine.PlaySound(shootSound);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel, ProjectileID.ShadowFlameArrow, damage, Projectile.knockBack, Main.myPlayer);

            if (heldItem.ModItem is ShadowflameBowSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedBy(MathHelper.ToRadians(8)), ProjectileID.ShadowFlameKnife, (int)(damage * 0.75f), Projectile.knockBack, Main.myPlayer);

                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedBy(MathHelper.ToRadians(-8)), ProjectileID.ShadowFlameKnife, (int)(damage * 0.75f), Projectile.knockBack, Main.myPlayer);
                    specialShotCounter = 0;
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);
                }
            }


        }
    }
}
