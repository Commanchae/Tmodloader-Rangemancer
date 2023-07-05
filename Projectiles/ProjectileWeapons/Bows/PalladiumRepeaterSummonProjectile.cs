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
    public class PalladiumRepeaterSummonProjectile : SummonProjectile
    {
        protected int heightOffset = 700;
        protected int numberOfSpecialProjectiles = 0;

        public override void setAttributes()
        {
            // Essential
            Projectile.width = 58;
            Projectile.height = 34;

            // Class Specific.
            buff = ModContent.BuffType<PalladiumRepeaterSummonBuff>();
            shootSpeed = 9.25f;
            shootCooldown = 22;

            specialShotCooldown = 20;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item4;


            specialShotCooldown = 20;
            respectiveItem = new Item(ItemID.PalladiumRepeater);



        }
        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);

            Terraria.Audio.SoundEngine.PlaySound(shootSound);

            if (heldItem.ModItem is PalladiumRepeaterSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    Player player = Main.player[Projectile.owner];
                    player.AddBuff(BuffID.RapidHealing, 60*5);
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);
                    for (int i = 0; i < 10; i++)
                    {
                        var dust = Dust.NewDust(player.position, Projectile.width, Projectile.height, DustID.OrangeTorch, Scale: 1.5f) ;
                    }

                    specialShotCounter = 0;

                }
            }
        }



    }

}
