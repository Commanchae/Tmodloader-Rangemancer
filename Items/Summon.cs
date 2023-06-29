using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Bowmancer.Buffs;
using Bowmancer.Projectiles;
using System;

namespace Bowmancer.Items
{
    public abstract class Summon : ModItem
    {
        protected int buff;
        protected int projectile;
        protected string name;
        protected int damage;
        protected float knockBack;
        protected int mana = 10;
        protected int itemID;
        protected bool craftable = true;

        protected string itemDescription = "";
        protected string abilityDescription = "";
        protected string abilityName = "";
        protected string abilityNameColor = "";



        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller
            ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;

            ItemID.Sets.StaffMinionSlotsRequired[Type] = (int)1f; // The default value is 1, but other values are supported. See the docs for more guidance. 
            setStaticAttributes();
        }

        public virtual void setAttributes()
        {
        }

        public virtual void setStaticAttributes()
        {
            string concat = "\n[c/a555d7:Special Ability]\n";

            Tooltip.SetDefault(itemDescription + "\n" + "[c/" + abilityNameColor + ":" + abilityName + "]: " + abilityDescription); ;
        }

        public override void SetDefaults()
        {
            setAttributes();
            Item.damage = damage;
            Item.knockBack = knockBack;
            Item.mana = mana; // mana cost
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = ItemUseStyleID.Shoot; // how the player's arm moves when using the item
            Item tempItem = new Item(itemID);
            Item.value = tempItem.value;
            Item.rare = tempItem.rare;
            Item.UseSound = SoundID.Item44; // What sound should play when using the item

            // These below are needed for a minion weapon
            Item.noMelee = true; // this item doesn't do any melee damage
            Item.DamageType = DamageClass.Summon; // Makes the damage register as summon. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type
            Item.buffType = buff;
            // No buffTime because otherwise the item tooltip would say something like "1 minute duration"
            Item.shoot = projectile; // This item creates the minion projectile

            Item.SetNameOverride(name);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            // Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
            player.AddBuff(Item.buffType, 2);

            // Minions have to be spawned manually, then have originalDamage assigned to the damage of the summon item
            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(position, 5, 5, DustID.YellowStarDust, Scale:1.2f);
            }
            projectile.originalDamage = (int)(Item.damage * (Math.Pow(0.95, player.ownedProjectileCounts[Item.shoot])));

            // Since we spawned the projectile manually already, we do not need the game to spawn it for ourselves anymore, so return false
            return false;
        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            if (craftable)
            {
                CreateRecipe()
                    .AddIngredient(itemID, 1)
                    .AddIngredient(ItemID.FallenStar, 3)
                    .AddTile(TileID.WorkBenches)
                    .Register();
            }
        }

    }
}
