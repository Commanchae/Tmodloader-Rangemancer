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
    public class MoltenFurySummonProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            //Essentials
            Projectile.width = 18;
            Projectile.height = 36;

            buff = ModContent.BuffType<MoltenFurySummonBuff>();
            shootSpeed = 8;
            shootCooldown = 22;

            respectiveItem = new Item(ItemID.MoltenFury);

            // Bow Specific.
            shootFromCenter = true;

            specialShotCooldown = 3;
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            if (chosenAmmo.shoot == 1)
            {

                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.FireArrow, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item20);
            }
            else
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
            }

            if (heldItem.ModItem is MoltenFurySummon)
            {
                specialShotCounter++;

                if (specialShotCounter >= specialShotCooldown)
                {

                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.FireArrow, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.HellfireArrow, Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item5);
                    Terraria.Audio.SoundEngine.PlaySound(SoundID.Item20);
                    specialShotCounter = 0;
                }
            }
            else
            {
                specialShotCounter = 0;
            }
            {
            }

        }
    }
}
