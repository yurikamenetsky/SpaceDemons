using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

namespace DragonsDemons.Model
{
	public enum AbilityType
	{
		Automatic,
		OneShoot,
		Continious,
		Passive
	}

	public enum AbilityBonusType
	{
		DamageAdd,
		DamageMultiplier,
		ArmorAdd,
		ArmorMultiplier,
		Health,
		Regeneration,
		Freez,
		Slow,
		Speed,
		ProjectileSpeed,
		Stealth,
		LifeSteal,
		DamageOverTime,
		Experience,
		ExperienceMultiplier,
		GoldMultiplier,
		Support
	}

	public class AbilityParams
	{
		public readonly float value;
		public readonly float commonLevelMultiplier;
		public readonly List<float> levelMultipliers;
	}

	public class AbilityDef
	{
		public readonly float attackRange;
		public readonly float duration;
		public readonly float cooldown;
		public readonly float energyCost;
		public readonly float healthCost;
		public readonly float projectileSpeed;

		public readonly int requredPlayerLevel;
		public readonly int maxLevel;
		public readonly AbilityType type;
		public readonly DamageType damageType;
		public readonly WeaponType suitableWeapon;
		public readonly string name;
		public readonly string descr;
		public readonly string icon;
		public readonly string prefabId;
		public readonly Dictionary<AbilityBonusType, AbilityParams> param;
	}

	public class Ability 
	{
		public Action<Ability> OnInit = delegate {};
		public Action<Ability> OnActivate = delegate {};
		public Action<int> OnLevelChanged = delegate {};

		public int level;
		public string defId;
		AbilityDef def;

		public int Level {get {return level;} set {level = value; OnLevelChanged(level);}}

		public void Init(AbilityDef def)
		{
			this.def = def;
			OnInit(this);
		}

		public void Activate()
		{
			OnActivate(this);
		}
	}
}
