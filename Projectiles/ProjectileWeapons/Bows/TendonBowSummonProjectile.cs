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
    public class TendonBowSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            Projectile.width = 22;
            Projectile.height = 40;

            buff = ModContent.BuffType<TendonBowSummonBuff>();
            specialShotCooldown = 2;
            shootSpeed = 6.7f;
            shootCooldown = 30;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.NPCHit13;

            respectiveItem = new Item(ItemID.TendonBow);
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)

        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;


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
            }



        }
    }
}
