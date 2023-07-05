using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Bowmancer.Buffs;
using System.Collections.Specialized;
using Bowmancer.Items;
using Bowmancer.Items.Bows;
using Bowmancer.Projectiles.MiscProjectiles;

namespace Bowmancer.Projectiles.ProjectileWeapons.Bows
{
    public class TestProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<TestProjectileBuff>();
            shootSpeed = 6.1f;
            shootCooldown = 5;
            respectiveItem = new Item(ItemID.WoodenBow);
            shootFromCenter = true;

            Projectile.width = 16;
            Projectile.height = 32;

        }


        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel, int damage)
        {
            var projectile = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), position, shootVel, ModContent.ProjectileType<FairyQueenProjectile>(), Projectile.damage + chosenAmmo.damage, Projectile.knockBack, Main.myPlayer);
        }


    }
}
