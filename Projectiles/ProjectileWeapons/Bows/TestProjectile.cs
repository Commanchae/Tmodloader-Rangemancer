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

namespace Bowmancer.Projectiles.ProjectileWeapons.Bows
{
    public class TestProjectile : SummonProjectile
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<TestProjectileBuff>();
            shootSpeed = 6.1f;
            shootCooldown = 30;
            respectiveItem = new Item(ItemID.WoodenBow);
            shootFromCenter = true;

        }


        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, chosenAmmo.shoot, Projectile.damage, Projectile.knockBack, Main.myPlayer);

        }
    }
}
