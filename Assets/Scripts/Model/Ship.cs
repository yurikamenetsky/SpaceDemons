using UnityEngine;

using System.Collections;
using System.Collections.Generic;

namespace DragonsDemons.Model
{
	public class ShipDef : EntityDef
	{
		public List<Ability> abilities = new List<Ability>();
		public List<Weapon> weapons = new List<Weapon>();
		public List<string> enemiesId = new List<string>();
	}

	public class Ship : Entity 
	{
		public int level;
		public string defId;
		ShipDef def;

		public override void Init (EntityDef def, int level)
		{
			base.Init (def, level);
			this.def = def as ShipDef;
		}

		public override void TakeDamage (float damage)
		{
			base.TakeDamage (damage);
		}

		public override void Destroy ()
		{
			base.Destroy ();
		}
	}
}
