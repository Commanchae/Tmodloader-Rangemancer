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
    public class CobaltRepeaterSummonProjectile : SummonProjectile
    {
        List<int> randomAssortment = new List<int>() { ProjectileID.Shuriken, ProjectileID.EnchantedBoomerang, ProjectileID.Flamarang, ProjectileID.Bone, ProjectileID.ThornChakram,
            ProjectileID.ThrowingKnife, ProjectileID.SandBallGun, ProjectileID.Seed, ProjectileID.HolyWater, ProjectileID.GoldCoin, ProjectileID.EnchantedBeam, ProjectileID.Beenade,
        ProjectileID.IceSickle, ProjectileID.DeathSickle, ProjectileID.Bananarang, ProjectileID.BeeArrow, ProjectileID.ShadowBeamFriendly, ProjectileID.ChargedBlasterCannon,
        ProjectileID.BoneArrowFromMerchant, ProjectileID.CrystalDart,
        ProjectileID.CursedDart, ProjectileID.ShadowFlameKnife};

        public override void setAttributes()
        {
            // Essential
            Projectile.width = 52;
            Projectile.height = 20;

            // Class Specific.
            buff = ModContent.BuffType<CobaltRepeaterSummonBuff>();
            shootSpeed = 9;
            shootCooldown = 25;

            specialShotCooldown = 25;

            // Bow Specific.
            shootFromCenter = true;
            shootSound = SoundID.Item5;
            specialSound = SoundID.Item8;


            specialShotCooldown = 3;
            respectiveItem = new Item(ItemID.CobaltRepeater);



        }
        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

            Terraria.Audio.SoundEngine.PlaySound(shootSound);

            if (heldItem.ModItem is CobaltRepeaterSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotatedByRandom(MathHelper.ToRadians(5)), randomAssortment[rand.Next(0, randomAssortment.Count)], Projectile.damage, Projectile.knockBack, Main.myPlayer);
                    Terraria.Audio.SoundEngine.PlaySound(specialSound);



                    specialShotCounter = 0;

                }
            }
        }



    }

}
