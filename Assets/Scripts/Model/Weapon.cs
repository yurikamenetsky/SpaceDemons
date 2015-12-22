using UnityEngine;
using System.Collections;

namespace DragonsDemons.Model
{
	public enum DamageType
	{
		Physical,
		Energy,
		Bio
	}

	public enum WeaponType
	{
		Primary,
		Secondary,
		Default
	}

	public class Weapon
	{
		public float minDamage;
		public float maxDamage;
		public float cooldown;
		public DamageType damageType;
		public WeaponType type;
		public string prefabId;
		public string name;
		public string descr;
	}
}
