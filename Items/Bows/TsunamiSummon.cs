using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class TsunamiSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<TsunamiSummonBuff>();
            projectile = ModContent.ProjectileType<TsunamiSummonProjectile>();
            name = "Enchanted Tsunami";
            damage = (int) (53 * 0.75f);
            knockBack = 2f;
            mana = 40;
            itemID = ItemID.Tsunami;

            itemDescription = "Summons an enchanted [c/4fffb3:tsunami] to fight for you!";
            abilityDescription = "Summons a typhoon to swarm your enemies after every 8th shot.";
            abilityNameColor = "4fd6ff";
            abilityName = "Aquatic Swarm";

            //Tooltip.SetDefault("Summons an enchanted, meaty tendon bow to fight for you!\nSpecial ability: Shoots a blood arrow every other shot.");


        }

    }
}