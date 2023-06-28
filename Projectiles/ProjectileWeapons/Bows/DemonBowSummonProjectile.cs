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
    public class DemonBowSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            // Essential
            Projectile.width = 18;
            Projectile.height = 40;

            buff = ModContent.BuffType<DemonBowSummonBuff>();
            shootSpeed = 6.7f;
            shootCooldown = 25;
            specialShotCooldown = 2;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.NPCHit13;

            respectiveItem = new Item(ItemID.DemonBow);
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            if (heldItem.ModItem is DemonBowSummon)
            {
                specialShotCounter++;

                if (specialShotCounter >= specialShotCooldown)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.UnholyArrow, (int)(Projectile.damage * 1.6f), Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    specialShotCounter = 0;
                }
                else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(shootSound);
                }
            }
            else
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(shootSound);
                specialShotCounter = 0;
            }
            {
            }


        }
    }
}
