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
using IL.Terraria.Audio;
using Bowmancer.Items.Bows;

namespace Bowmancer.Projectiles.Bows
{
    public class BorealBowSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<BorealBowSummonBuff>();
            shootSpeed = 6.6f;
            shootCooldown = 29;
        }

        protected override void handleShot(Item chosenAmmo, Vector2 position, Vector2 shootVel, float angleOffset, Vector2 targetCenter)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
            if (heldItem.ModItem is BorealBowSummon)
            {
                specialShotCounter++;

                if (specialShotCounter >= specialShotCooldown)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Snow, Scale: 1.2f);

                    }
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position + new Vector2(0, Projectile.height / 2), Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset + 0.2f)), ProjectileID.SnowBallFriendly, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position + new Vector2(0, Projectile.height / 2), Vector2.Transform(shootVel, Matrix.CreateRotationX(angleOffset - 0.2f)), ProjectileID.SnowBallFriendly, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
                    specialShotCounter = 0;
                }
            }
            else
            {
                specialShotCounter = 0;
            }
            {
            }

            // Does not consume ammo if EndlessQuiver is used.
            if (chosenAmmo.type != 3103)
            {
                Main.player[Projectile.owner].ConsumeItem(chosenAmmo.type);
            }
        }
    }
}