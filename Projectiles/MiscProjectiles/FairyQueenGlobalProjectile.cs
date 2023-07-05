using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bowmancer.Projectiles.MiscProjectiles
{
    public class FairyQueenGlobalProjectile : GlobalProjectile
    {
        static Random rand = new Random();
        static List<Color> colorList = new List<Color> { Color.Aqua, Color.OrangeRed, Color.LightGoldenrodYellow, Color.Orange, Color.LightGreen, Color.Indigo, Color.Violet };

        public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {

            if (projectile.type == ModContent.ProjectileType<FairyQueenProjectile>() && projectile.owner >= 0 && (projectile.owner < Main.maxPlayers)){
                return colorList[rand.Next(colorList.Count)] * 0.5f;
            }
            else
            {
                return null;
            }
        }

        public override void AI(Projectile projectile)
        {
        }


    }
}
