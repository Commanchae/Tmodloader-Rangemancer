using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles;
using Ionic.Zip;
using Bowmancer.Buffs.MiscBuffs;
using Bowmancer.Players;

namespace Bowmancer.Buffs
{
    public abstract class SummonBuff : ModBuff

    {
        protected string name;
        protected string description;
        protected int projectile;
        protected Player owner = null;
        public override void SetStaticDefaults()
        {
            setAttributes();
            Main.buffNoSave[Type] = true; // This buff won't save when you exit the world
            Main.buffNoTimeDisplay[Type] = true; // The time remaining won't display on this buff
            DisplayName.SetDefault(this.name);
            Description.SetDefault(this.description);


        }

        public virtual void setAttributes()
        {
            this.name = "";
            this.description = "";
            this.projectile = 0;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // If the minions exist reset the buff time, otherwise remove the buff from the player
            if (owner is null)
            {
                owner = player;
            }

            if (player.ownedProjectileCounts[this.projectile] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }


        }

        public override bool RightClick(int buffIndex)
        {
            return true;
        }
    }
}
