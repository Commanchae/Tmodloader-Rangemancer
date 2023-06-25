using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles.Bows;

namespace Bowmancer.Items.Bows
{
    public class MoltenFurySummon : Summon
    {
        public override void setAttributes()
        {
            buff = ModContent.BuffType<MoltenFurySummonBuff>();
            projectile = ModContent.ProjectileType<MoltenFurySummonProjectile>();
            name = "Molten Fury Summon";
            damage = 20;
            knockBack = 3f;
            mana = 10;
            itemID = ItemID.MoltenFury;
        }

    }
}