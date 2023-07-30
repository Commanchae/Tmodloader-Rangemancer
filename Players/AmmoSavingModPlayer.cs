using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Bowmancer.Players
{
    public class AmmoSavingModPlayer : ModPlayer
    {
        public float nonConsumptionBonus = 0f;
        public int summonedWeapons = 0;

        public override void ResetEffects()
        {         
        }

    }
}
