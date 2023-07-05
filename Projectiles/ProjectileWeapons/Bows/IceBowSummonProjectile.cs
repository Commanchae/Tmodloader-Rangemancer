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
    public class IceBowSummonProjectile : SummonProjectile
    {

        Vector2 normalizedShootVel = Vector2.Zero;

        public override void setAttributes()
        {
            Projectile.width = 18;
            Projectile.height = 36;

            buff = ModContent.BuffType<IceBowSummonBuff>();
            specialShotCooldown = 5;
            shootSpeed = 20;
            shootCooldown = 14;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item28;

            respectiveItem = new Item(ItemID.IceBow);


        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            // Normalized as it is not affected by other factors, only the gun's shootSpeed.
            normalizedShootVel = shootVel;
            normalizedShootVel.Normalize();
            normalizedShootVel *= shootSpeed; // Ice Bow Not affected by Ammo speed.


            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel, ProjectileID.FrostArrow, damage, Projectile.knockBack, Main.myPlayer);
            Terraria.Audio.SoundEngine.PlaySound(shootSound);
            if (heldItem.ModItem is IceBowSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    int numberOfShots = rand.Next(1, 6);
                    for (int i = 0; i < numberOfShots; i++)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedByRandom(MathHelper.ToRadians(5)), ProjectileID.NorthPoleSnowflake, (int)((damage) *0.75f), Projectile.knockBack, Main.myPlayer);
                        Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    }


                    specialShotCounter = 0;
                }
            }


        }
    }
}
