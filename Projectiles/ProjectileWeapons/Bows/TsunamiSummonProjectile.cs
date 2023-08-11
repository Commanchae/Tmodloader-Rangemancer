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
    public class TsunamiSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            Projectile.width = 28;
            Projectile.height = 58;

            buff = ModContent.BuffType<TsunamiSummonBuff>();
            specialShotCooldown = 8;
            shootSpeed = 10;
            shootCooldown = 24;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.NPCHit13;

            respectiveItem = new Item(ItemID.Tsunami);
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            // Calculate perpendicular vector.
            Vector2 perpendicularVector = new Vector2(0, 8);
            perpendicularVector.X = (-perpendicularVector.Y * shootVel.Y) / (shootVel.X+1 );

            perpendicularVector.Normalize();
            perpendicularVector *= 10;


            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position+ perpendicularVector, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);


            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position+ 2*perpendicularVector, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position - perpendicularVector, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position - 2*perpendicularVector, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);

            Terraria.Audio.SoundEngine.PlaySound(shootSound);

            if (heldItem.ModItem is TsunamiSummon)
            {
                specialShotCounter++;

                if (specialShotCounter >= specialShotCooldown)
                {
                    var proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.Typhoon, damage, Projectile.knockBack, Main.myPlayer);
                    proj.friendly = true;
                    proj.hostile = false;
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item84);
                    specialShotCounter = 0;
                }
            }
/*
            if (heldItem.ModItem is TendonBowSummon)
            {
                specialShotCounter++;

                if (specialShotCounter >= specialShotCooldown)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.BloodArrow, (int)(damage * 1.6f), Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit13);
                    specialShotCounter = 0;
                }
                else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
                }
            }
            else
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);

                specialShotCounter = 0;
            }
            {
            }*/



        }
    }
}
