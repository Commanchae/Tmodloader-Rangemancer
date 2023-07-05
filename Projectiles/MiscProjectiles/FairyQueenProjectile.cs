using Microsoft.Xna.Framework;
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
    public class FairyQueenProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.FairyQueenRangedItemShot);
            // projectile.aiStyle = 3; This line is not needed since CloneDefaults sets it already.
            AIType = ProjectileID.FairyQueenRangedItemShot;
        }

    }
}
