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
    public class MythrilRepeaterSummonProjectile : SummonProjectile
    {

        public override void setAttributes()
        {
            // Essential
            Projectile.width = 52;
            Projectile.height = 20;

            // Class Specific.
            buff = ModContent.BuffType<MythrilRepeaterSummonBuff>();
            shootSpeed = 9.5f;
            shootCooldown = 18;

            specialShotCooldown = 30;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item4;


            specialShotCooldown = 20;
            respectiveItem = new Item(ItemID.MythrilRepeater);



        }
        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

            Terraria.Audio.SoundEngine.PlaySound(shootSound);

            if (heldItem.ModItem is MythrilRepeaterSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    Player player = Main.player[Projectile.owner];
                    Vector2 dashVelocity = player.velocity;
                    dashVelocity += new Vector2(1, 1);
                    dashVelocity.Normalize();

                    player.velocity = player.velocity + dashVelocity * 8;
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    for (int i = 0; i < 10; i++)
                    {
                        var dust = Dust.NewDust(player.position, Projectile.width, Projectile.height, DustID.UltraBrightTorch, Scale: 1.5f) ;
                    }

                    specialShotCounter = 0;

                }
            }
        }



    }

}
