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
using static Terraria.ModLoader.PlayerDrawLayer;
using Bowmancer.Items.Guns;

namespace Bowmancer.Projectiles.ProjectileWeapons.Guns
{
    public class CoinGunSummonProjectile : SummonProjectile
    {

        public override void setAttributes()
        {
            buff = ModContent.BuffType<CoinGunSummonBuff>();
            shootSpeed = 10f;
            shootCooldown = 8;
            specialShotCooldown = 20;
            Projectile.width = 56;
            Projectile.height = 20;

            percentNonConsume = 0f;

            isGun = true;
            shootFromCenter = false;
            useCustomAmmo = false;
            respectiveItem = new Item(ItemID.CoinGun);


            shootSound = SoundID.Item31;
            specialSound = SoundID.Item31;

 
        }

        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, chosenAmmo.damage, Projectile.knockBack, Main.myPlayer);
            Terraria.Audio.SoundEngine.PlaySound(shootSound);
            if (heldItem.ModItem is CoinGunSummon)
            {
                specialShotCounter++;
                if (specialShotCounter == specialShotCooldown)
                {
                    if (!(targetEnemy is null))
                    {
                        if (targetEnemy.FindBuffIndex(BuffID.Midas) == -1)
                        {
                            targetEnemy.AddBuff(BuffID.Midas, 60*3);
                            for (int i = 0; i < 5; i++)
                            {
                                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GoldCoin);
                            }
                            Terraria.Audio.SoundEngine.PlaySound(SoundID.Coins);
                        }
                        specialShotCounter = 0;
                    }
                }
            }
            else
            {
                specialShotCounter = 0;
            }
        }
    }
}
