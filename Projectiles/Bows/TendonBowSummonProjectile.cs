﻿using System;
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

namespace Bowmancer.Projectiles.Bows
{
    public class TendonBowSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<TendonBowSummonBuff>();
            specialShotCooldown = 2;
            shootSpeed = 6.7f;
            shootCooldown = 30;
        }

        protected override void handleShot(Item chosenAmmo, Vector2 position, Vector2 shootVel, float angleOffset, Vector2 targetCenter)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;


            if (heldItem.ModItem is TendonBowSummon)
            {
                specialShotCounter++;

                if (specialShotCounter >= specialShotCooldown)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position + new Vector2(0, Projectile.height / 2), Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), ProjectileID.BloodArrow, (int)(Projectile.damage * 1.6f), Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCHit13);
                    specialShotCounter = 0;
                }
                else
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position + new Vector2(0, Projectile.height / 2), Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
                }
            }
            else
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position + new Vector2(0, Projectile.height / 2), Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                specialShotCounter = 0;
            }
            {
            }

            if (chosenAmmo.type != 3103)
            {
                Main.player[Projectile.owner].ConsumeItem(chosenAmmo.type);
            }

        }
    }
}