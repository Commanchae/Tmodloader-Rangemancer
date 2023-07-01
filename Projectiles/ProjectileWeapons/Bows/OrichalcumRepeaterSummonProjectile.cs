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
    public class OrichalcumRepeaterSummonProjectile : SummonProjectile
    {
        protected int heightOffset = 700;
        protected int numberOfSpecialProjectiles = 0;

        public override void setAttributes()
        {
            // Essential
            Projectile.width = 56;
            Projectile.height = 30;

            // Class Specific.
            buff = ModContent.BuffType<OrichalcumRepeaterSummonBuff>();
            shootSpeed = 9.75f;
            shootCooldown = 19;

            specialShotCooldown = 3;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item4;

            respectiveItem = new Item(ItemID.OrichalcumRepeater);



        }
        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

            Terraria.Audio.SoundEngine.PlaySound(shootSound);

            if (heldItem.ModItem is OrichalcumRepeaterSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    Vector2 directVelocity = targetLocation - position;
                    directVelocity.Normalize();
                    directVelocity *= shootSpeed;
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, directVelocity, ProjectileID.FlowerPetal, Projectile.damage, Projectile.knockBack, Main.myPlayer);


                    specialShotCounter = 0;

                }
            }
        }



    }

}
