using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class PhantomPhoenixSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<PhantomPhoenixSummonBuff>();
            projectile = ModContent.ProjectileType<PhantomPhoenixSummonProjectile>();
            name = "Enchanted Phantom Phoenix";
            damage = (int) (32*0.75);
            knockBack = 2;
            mana = 40;
            itemID = ItemID.DD2PhoenixBow;

            itemDescription = "Summons an enchanted [c/ff9d00:phantom phoenix] to fight for you!";
            abilityDescription = "Shoots out a flock of phoenixes every seventh shot.";
            abilityNameColor = "ff2e54";
            abilityName = "Fiery Flock";

            //Tooltip.SetDefault("Summons an enchanted, meaty tendon bow to fight for you!\nSpecial ability: Shoots a blood arrow every other shot.");


        }

    }
}