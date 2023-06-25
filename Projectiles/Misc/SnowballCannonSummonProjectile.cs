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
using Bowmancer.Items.Guns;
using Bowmancer.Items.Bows;

namespace Bowmancer.Projectiles.Misc
{
    public class SnowballCannonSummonProjectile : MiscSummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<SnowballCannonSummonBuff>();
            shootSpeed = 11f;
            shootCooldown = 19;
            specialShotCooldown = 5;
            itemDefault = new Item(ItemID.SnowballCannon);
            Projectile.width = 50;
            Projectile.height = 26;
            searchDistance = 700f;
        }

        protected override void handleShot(Item chosenAmmo, Vector2 position, Vector2 shootVel, float angleOffset, Vector2 targetCenter)
        {
            Item heldItem = Main.player[Projectile.owner].HeldItem;

            if (heldItem.ModItem is SnowballCannonSummon)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotateRandom(MathHelper.ToRadians(5)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

            }
            else
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel.RotateRandom(MathHelper.ToRadians(5)), chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

                specialShotCounter = 0;
            }
            Main.player[Projectile.owner].ConsumeItem(chosenAmmo.type);


        }
    }
}
