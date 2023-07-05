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
    public class MarrowSummonProjectile : SummonProjectile
    {

        Vector2 normalizedShootVel = Vector2.Zero;

        public override void setAttributes()
        {
            Projectile.width = 22;
            Projectile.height = 36;

            buff = ModContent.BuffType<MarrowSummonBuff>();
            specialShotCooldown = 5;
            shootSpeed = 11;
            shootCooldown = 19;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.NPCHit2;

            respectiveItem = new Item(ItemID.Marrow);


        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            // Normalized as it is not affected by other factors, only the gun's shootSpeed.
            normalizedShootVel = shootVel;
            normalizedShootVel.Normalize();
            normalizedShootVel *= shootSpeed + chosenAmmo.shootSpeed;


            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel, ProjectileID.BoneArrow, damage, Projectile.knockBack, Main.myPlayer);
            Terraria.Audio.SoundEngine.PlaySound(shootSound);
            if (heldItem.ModItem is MarrowSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    int numberOfShots = rand.Next(2, 11);
                    for (int i = 0; i < numberOfShots; i++)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, normalizedShootVel.RotatedByRandom(6.28), ProjectileID.Bone, (int)((damage) *0.25f), Projectile.knockBack, Main.myPlayer);
                        Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    }


                    specialShotCounter = 0;
                }
            }


        }
    }
}
