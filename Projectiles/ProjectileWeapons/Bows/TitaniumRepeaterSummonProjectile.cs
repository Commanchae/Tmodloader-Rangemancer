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
    public class TitaniumRepeaterSummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            // Essential
            Projectile.width = 56;
            Projectile.height = 30;

            // Class Specific.
            buff = ModContent.BuffType<TitaniumRepeaterSummonBuff>();
            shootSpeed = 9.75f;
            shootCooldown = 19;

            specialShotCooldown = 3;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item4;

            respectiveItem = new Item(ItemID.TitaniumRepeater);



        }
        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);

            Terraria.Audio.SoundEngine.PlaySound(shootSound);

            if (heldItem.ModItem is TitaniumRepeaterSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(5)), chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedBy(MathHelper.ToRadians(-5)), chosenAmmo.shoot, damage, Projectile.knockBack, Main.myPlayer);


                    specialShotCounter = 0;

                }
            }
            else
            {
                specialShotCounter = 0;
            }
        }



    }

}
