using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace Bowmancer.Projectiles.MiscProjectiles
{
    public class PhantasmHomingProjectile : ModProjectile
    {
        NPC targetSet = null;

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ChlorophyteArrow);
            Projectile.width = 10;
            Projectile.height = 20;
            Projectile.friendly = true;         //Can the projectile deal damage to enemies?
            Projectile.hostile = false;         //Can the projectile deal damage to the player?       Projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.light = 0.5f;            //How much light emit around the projectile
            Projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true;          //Can the projectile collide with tiles?

        }




        public void SetTarget(NPC npc)
        {
            targetSet = npc;
        }

    


        public override void AI()
        {
            if (targetSet is null)
            {
                for (int i = 0; i < 200; i++)
                {
                    NPC target = Main.npc[i];
                    //If the npc is hostile
                    if (target.CanBeChasedBy())
                    {
                        //Get the shoot trajectory from the projectile and target
                        float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
                        float shootToY = target.position.Y - Projectile.Center.Y;
                        float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                        //If the distance between the live targeted npc and the projectile is less than 480 pixels
                        if (distance < 480f && !target.friendly && target.active)
                        {
                            //Divide the factor, 3f, which is the desired velocity
                            distance = 3f / distance;

                            //Multiply the distance by a multiplier if you wish the projectile to have go faster
                            shootToX *= distance * 5;
                            shootToY *= distance * 5;

                            //Set the velocities to the shoot values
                            Projectile.velocity.X = shootToX;
                            Projectile.velocity.Y = shootToY;
                        }
                    }
                }
            }
            else
            {
                if (targetSet.CanBeChasedBy())
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = targetSet.position.X + (float)targetSet.width * 0.5f - Projectile.Center.X;
                    float shootToY = targetSet.position.Y - Projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if ( !targetSet.friendly && targetSet.active)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 3f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        Projectile.velocity.X = shootToX;
                        Projectile.velocity.Y = shootToY;
                    }
                }
            }

        }



    }
}
