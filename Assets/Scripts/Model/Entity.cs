using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

using DragonsDemons.Common;

namespace DragonsDemons.Model
{
	public class EntityDef
	{
		public class EntityDefParams
		{
			public float health;
			public float armor;
			public float experience;
			public string prefabId;
		}
		public string name;
		public string desc;
		public List<EntityDefParams> paramsByLevel = new List<EntityDefParams>();
	}
		
	public class Entity : IDamagable, IDestroyable
	{
		public Action OnDamage = delegate{};
		public Action OnDestroy = delegate{};
		public Action OnInit = delegate{};

		int level;
		float health;
		EntityDef def;

		public virtual void Init(EntityDef def, int level)
		{
			this.level = level;
			this.def = def;
			health = def.paramsByLevel[level].health;
			OnInit();
		}

		public virtual void TakeDamage(float damage)
		{
			health = Mathf.Clamp(health - (damage - def.paramsByLevel[level].armor + 1), 0f, health);
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
