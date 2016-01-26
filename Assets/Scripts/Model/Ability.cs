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
		HealthAdd,
		HealthRegeneration,
		SpeedUp,
		ProjectileSpeedUp,
		Experience,
		ExperienceMultiplier,
		GoldMultiplier,
		Freeze,
		Slow,
		Stealth,
		LifeSteal,
		DamageOverTime,
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
		public readonly float range;
		public readonly float duration;
		public readonly float cooldown;
		public readonly float energyCost;
		public readonly float healthCost;
		public readonly float projectileSpeed;
		public readonly float projectileCount;
		public readonly int requredPlayerLevel;
		public readonly string prefabId;

		public readonly int maxLevel;
		public readonly AbilityType type;
		public readonly DamageType damageType;
		public readonly WeaponType suitableWeapon;
		public readonly string name;
		public readonly string descr;
		public readonly string icon;
		public readonly Dictionary<AbilityBonusType, AbilityParams> parameters;
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
