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

namespace Bowmancer.Projectiles
{
    public abstract class GunSummonProjectile : ModProjectile
    {
        protected float shootSpeed = 12f;
        protected int buff;
        protected float minionSlots = 1f;
        protected int shootCooldown = 24;
        protected int shootCounter = 0;
        protected Item gunDefault = new Item(ItemID.FlintlockPistol);
        protected int specialShotCooldown = 3;
        protected int specialShotCounter = 0;
        protected float angleOffset = 0f;
        protected float searchDistance = 500f;
        protected Random rand = new Random();
        protected float percentNonConsume = 0f;

        public override void SetStaticDefaults()


        {
            // Sets the amount of frames this minion has on its spritesheet
            Main.projFrames[Projectile.type] = 1;
            // This is necessary for right-click targeting
            ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;

            Main.projPet[Projectile.type] = true; // Denotes that this projectile is a pet or minion

            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true; // This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; // Make the cultist resistant to this projectile, as it's resistant to all homing projectiles.
        }

        public abstract void setAttributes();

        public sealed override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 28;
            setAttributes();

            Projectile.tileCollide = false; // Makes the minion go through tiles freely

            // These below are needed for a minion weapon
            Projectile.friendly = false; // Only controls if it deals damage to enemies on contact (more on that later)
            Projectile.minion = true; // Declares this as a minion (has many effects)
            Projectile.DamageType = DamageClass.Summon; // Declares the damage type (needed for it to deal damage)
            Projectile.minionSlots = minionSlots; // Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
            Projectile.penetrate = -1; // Needed so the minion doesn't despawn on collision with enemies or tiles


        }

        // Here you can decide if your minion breaks things like grass or pots
        public override bool? CanCutTiles()
        {
            return false;
        }

        // This is mandatory if your minion deals contact damage (further related stuff in AI() in the Movement region)
        public override bool MinionContactDamage()
        {
            return false;
        }

        // The AI of this minion is split into multiple methods to avoid bloat. This method just passes values between calls actual parts of the AI.
        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];

            if (!CheckActive(owner))
            {
                return;
            }

            GeneralBehavior(owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition);
            SearchForTargets(owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter);
            Movement(foundTarget, distanceFromTarget, targetCenter, distanceToIdlePosition, vectorToIdlePosition);
            Visuals(foundTarget);
        }

        // This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
        private bool CheckActive(Player owner)
        {
            if (owner.dead || !owner.active)
            {
                owner.ClearBuff(buff);

                return false;
            }

            if (owner.HasBuff(buff))
            {
                Projectile.timeLeft = 2;
            }

            return true;
        }

        private void GeneralBehavior(Player owner, out Vector2 vectorToIdlePosition, out float distanceToIdlePosition)
        {
            Vector2 idlePosition = owner.Center;
            idlePosition.Y -= 48f; // Go up 48 coordinates (three tiles from the center of the player)

            // If your minion doesn't aimlessly move around when it's idle, you need to "put" it into the line of other summoned minions
            // The index is projectile.minionPos
            float minionPositionOffsetX = (10 + Projectile.minionPos * 40) * -owner.direction;
            idlePosition.X += minionPositionOffsetX; // Go behind the player

            if ((idlePosition - Projectile.Center).X > 0f)
            {
                Projectile.spriteDirection = Projectile.direction = 1;
            }
            else if ((idlePosition - Projectile.Center).X < 0f)
            {
                Projectile.spriteDirection = Projectile.direction = -1;
            }


            // All of this code below this line is adapted from Spazmamini code (ID 388, aiStyle 66)

            // Teleport to player if distance is too big
            vectorToIdlePosition = idlePosition - Projectile.Center;
            distanceToIdlePosition = vectorToIdlePosition.Length();

            if (Main.myPlayer == owner.whoAmI && distanceToIdlePosition > 2000f)
            {
                // Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
                // and then set netUpdate to true
                Projectile.position = idlePosition;
                Projectile.velocity *= 0.1f;
                Projectile.netUpdate = true;
            }

            // If your minion is flying, you want to do this independently of any conditions
            float overlapVelocity = 0.04f;

            // Fix overlap with other minions
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile other = Main.projectile[i];

                if (i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width)
                {
                    if (Projectile.position.X < other.position.X)
                    {
                        Projectile.velocity.X -= overlapVelocity;
                    }
                    else
                    {
                        Projectile.velocity.X += overlapVelocity;
                    }

                    if (Projectile.position.Y < other.position.Y)
                    {
                        Projectile.velocity.Y -= overlapVelocity;
                    }
                    else
                    {
                        Projectile.velocity.Y += overlapVelocity;
                    }
                }
            }
        }

        private void SearchForTargets(Player owner, out bool foundTarget, out float distanceFromTarget, out Vector2 targetCenter)
        {
            // Starting search distance
            distanceFromTarget = searchDistance;
            targetCenter = Projectile.position;
            foundTarget = false;

            // This code is required if your minion weapon has the targeting feature
            if (owner.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[owner.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, Projectile.Center);

                // Reasonable distance away so it doesn't target across multiple screens
                if (between < searchDistance)
                {
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    foundTarget = true;
                }
            }

            if (!foundTarget)
            {
                // This code is required either way, used for finding a target
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];

                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, Projectile.Center);
                        bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(Projectile.position - new Vector2(0, Projectile.height / 2), Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
                        // Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
                        // The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
                        bool closeThroughWall = between < 100f;

                        if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall))
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }

            // friendly needs to be set to true so the minion can deal contact damage
            // friendly needs to be set to false so it doesn't damage things like target dummies while idling
            // Both things depend on if it has a target or not, so it's just one assignment here
            // You don't need this assignment if your minion is shooting things instead of dealing contact damage
            //Projectile.friendly = foundTarget;s
        }

        private void Movement(bool foundTarget, float distanceFromTarget, Vector2 targetCenter, float distanceToIdlePosition, Vector2 vectorToIdlePosition)
        {
            // Default movement parameters (here for attacking)
            float speed = 8f;
            float inertia = 20f;

            if (foundTarget)
            {
                shootCounter++;
                vectorToIdlePosition.Normalize();
                vectorToIdlePosition *= speed;
                Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;

                Vector2 initialPosition = Projectile.Center;

                Vector2 direction = targetCenter - initialPosition;
                float theta = (float)Math.Atan((double)direction.Y / (double)direction.X);
                Projectile.rotation = theta;
                bool directlyAboveorBelow = false;
                if ((targetCenter - Projectile.Center).X > 0f)
                {
                    Projectile.spriteDirection = Projectile.direction = 1;
                    initialPosition.X += (Projectile.width/2f);
                    if ((targetCenter.X - initialPosition.X) <= 0f)
                    {
                        initialPosition.X -= (Projectile.width / 2f);
                    }

                }
                else if ((targetCenter - Projectile.Center).X < 0f)

                {
                    Projectile.spriteDirection = Projectile.direction = -1;
                    initialPosition.X -= (Projectile.width/2f);
                    if ((targetCenter.X - initialPosition.X) < 0f)
                    {
                        initialPosition.X += (Projectile.width / 2f);
                    }
                }

                direction = targetCenter - initialPosition;
                theta = (float)Math.Atan((double)direction.Y / (double)direction.X);

                initialPosition -= Projectile.Center;
                float newX = initialPosition.X * MathF.Cos(theta) + initialPosition.Y * MathF.Sin(theta);
                float newY = -initialPosition.X * MathF.Sin(theta) + initialPosition.Y * MathF.Cos(theta);

                // Create the rotated vector
                Vector2 rotatedVector = new Vector2(newX, -1*newY);
                Vector2 startingPosition = Projectile.Center + rotatedVector;






                if (shootCounter >= shootCooldown)
                {
                    shootCounter = 0;
                    if (Main.myPlayer == Projectile.owner)
                    {


                        Item chosenAmmo = Main.player[Projectile.owner].ChooseAmmo(gunDefault);

                        if (chosenAmmo != null)
                        {
                            Vector2 shootVel = direction;
                            shootVel.Normalize();
                            shootVel *= shootSpeed;
                            angleOffset = 0;
                            handleShot(chosenAmmo, startingPosition, shootVel, angleOffset, targetCenter);
                            
                        }
                    }

                }
            }
            else
            {
                // Minion doesn't have a target: return to player and idle
                if (distanceToIdlePosition > 250f)
                {
                    vectorToIdlePosition.Normalize();
                    vectorToIdlePosition *= speed;
                    Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;

                }
                else
                {
                    // Slow down the minion if closer to the player
                    speed = 8f;
                    inertia = 40;
                }

                if (distanceToIdlePosition > 20f)
                {
                    // The immediate range around the player (when it passively floats about)

                    // This is a simple movement formula using the two parameters and its desired direction to create a "homing" movement
                    vectorToIdlePosition.Normalize();
                    vectorToIdlePosition *= speed;
                    Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
                }
                else if (Projectile.velocity == Vector2.Zero)
                {
                    // If there is a case where it's not moving at all, give it a little "poke"
                    Projectile.velocity.X = -0.15f;
                    Projectile.velocity.Y = -0.05f;
                }
            }
        }

        protected abstract void handleShot(Item chosenAmmo, Vector2 position, Vector2 shootVel, float angleOffset, Vector2 targetCenter);


        private void Visuals(bool foundTarget)
        {
            // So it will lean slightly towards the direction it's moving
            if (!foundTarget)
            {
                Projectile.rotation = Projectile.velocity.X * 0.05f;
            }
            // This is a simple "loop through all frames from top to bottom" animation
            int frameSpeed = 20;

            Projectile.frameCounter++;

            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;

                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }

            // Some visuals here
            Lighting.AddLight(Projectile.Center, Color.White.ToVector3() * 0.78f);
        }

        protected void consumeAmmo(int ammoType)
        {
            int number = rand.Next(1, 101);

            // Implement ammo conservation. 


            if (number >= (int)101 * percentNonConsume)
            {
                // weaponType: 0 for Bows, 1 for Guns.
                if (ammoType != 3104)
                {
                    Main.player[Projectile.owner].ConsumeItem(ammoType);
                }
            }
        }
    }
}
