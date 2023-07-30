using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles.ProjectileWeapons.Bows;
using System;
using Bowmancer.Projectiles;
using Bowmancer.Players;

namespace Bowmancer.Buffs.MiscBuffs
{
    public class AmmoSavingBuff : ModBuff
    {
        public float nonConsumptionBonus = 0f;

        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true; 
            Main.buffNoTimeDisplay[Type] = true; 
            DisplayName.SetDefault("Ammo Saving Technique");
            Description.SetDefault("The weapons are teaching each other how to save ammo! An additive 2.5% chance of not consuming ammo for each summoned!");


        }


        public override void Update(Player player, ref int buffIndex)
        {

        }

    }
}

