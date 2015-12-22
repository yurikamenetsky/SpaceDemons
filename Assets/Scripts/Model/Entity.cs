using UnityEngine;

using System;
using System.Collections;

using DragonsDemons.Common;

namespace DragonsDemons.Model
{
	public class EntityDef
	{
		public float health;
		public float armor;
		public float experience;

		public string name;
		public string desc;
		public string prefabId;
	}
		
	public class Entity : IDamagable, IDestroyable
	{
		public Action OnDamage = delegate{};
		public Action OnDestroy = delegate{};

		int level;
		float health;
		EntityDef def;

		public void Init(EntityDef def, int level)
		{
			this.level = level;
			this.def = def;
			health = def.health;
		}

		public virtual void TakeDamage(float damage)
		{
			health = Mathf.Clamp(health - (damage - def.armor + 1), 0f, health);
			if(health <= float.Epsilon)
				Destroy();

			OnDamage();
		}

		public virtual void Destroy()
		{
			OnDestroy();
		}
	}
}
