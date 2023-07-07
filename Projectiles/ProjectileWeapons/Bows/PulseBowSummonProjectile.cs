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
    public class PulseBowSummonProjectile : SummonProjectile
    {

        Vector2 normalizedShootVel = Vector2.Zero;
        Vector2 directShotVel = Vector2.Zero;

        public override void setAttributes()
        {
            Projectile.width = 28;
            Projectile.height = 46;

            buff = ModContent.BuffType<PulseBowSummonBuff>();
            specialShotCooldown = rand.Next(10,20);
            shootSpeed = 8;
            shootCooldown = 20;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item75;
            specialSound = SoundID.Item28;

            respectiveItem = new Item(ItemID.PulseBow);


        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            // Normalized as it is not affected by other factors, only the gun's shootSpeed.
            normalizedShootVel = shootVel;
            normalizedShootVel.Normalize();
            normalizedShootVel *= shootSpeed; // Ice Bow Not affected by Ammo speed.

            directShotVel = targetLocation - position;
            directShotVel.Normalize();
            directShotVel *= shootSpeed;

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, directShotVel, ProjectileID.PulseBolt, damage, Projectile.knockBack, Main.myPlayer);
            Terraria.Audio.SoundEngine.PlaySound(shootSound);
            if (heldItem.ModItem is PulseBowSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedByRandom(MathHelper.ToRadians(5)), chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
                        Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    }


                    specialShotCounter = 0;
                    specialShotCooldown = rand.Next(10, 20);
                }
            }


        }
    }
}
