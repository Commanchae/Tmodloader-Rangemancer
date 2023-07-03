using Terraria.ModLoader;
using Terraria;
using Bowmancer.Projectiles;
using Ionic.Zip;

namespace Bowmancer.Buffs
{
    public abstract class SummonBuff : ModBuff

    {
        protected string name;
        protected string description;
        protected int projectile;

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
    }
}
