using UnityEngine;
using System.Collections;

namespace DragonsDemons.Common
{
	interface IDamagable 
	{
		void TakeDamage(float damage);
	}

	interface IDestroyable 
	{
		void Destroy();
	}

	interface IWeapon
	{
		void MakeDamage();
	}
}
