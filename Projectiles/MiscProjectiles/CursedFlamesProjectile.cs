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
    public class CursedFlamesProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.EyeFire);
            // projectile.aiStyle = 3; This line is not needed since CloneDefaults sets it already.
            AIType = ProjectileID.EyeFire;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 60 * 3);
        }

    }
}
