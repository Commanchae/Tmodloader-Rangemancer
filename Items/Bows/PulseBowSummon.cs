using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;

namespace Bowmancer.Items.Bows
{
    public class PulseBowSummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<PulseBowSummonBuff>();
            projectile = ModContent.ProjectileType<PulseBowSummonProjectile>();
            name = "Enchanted Pulse Bow";
            damage = (int) (80*0.75);
            knockBack = 4.5f;
            mana = 40;
            itemID = ItemID.PulseBow;

            itemDescription = "Summons an enchanted [c/99ceff:pulse bow] to fight for you!";
            abilityDescription = "After a random number of shots, shoots a normal arrow inplace of a pulse bolt.";
            abilityNameColor = "ababab";
            abilityName = "Faulty Conversion";

            //Tooltip.SetDefault("Summons an enchanted, meaty tendon bow to fight for you!\nSpecial ability: Shoots a blood arrow every other shot.");


        }

    }
}