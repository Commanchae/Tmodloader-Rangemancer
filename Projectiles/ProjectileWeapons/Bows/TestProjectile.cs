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
using Bowmancer.Items;
using IL.Terraria.Audio;
using Bowmancer.Items.Bows;

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

        }


        protected override void shoot(Item chosenAmmo, Vector2 position, Vector2 shootVel)
        {
                var projectile = Projectile.NewProjectile(Projectile.GetSource_FromThis(), position, shootVel, ProjectileID.WaterStream, Projectile.damage, Projectile.knockBack, Main.myPlayer);
            Player player = Main.player[Projectile.owner];
            player.AddBuff(BuffID.Regeneration, 3600);
        }
    }
}
