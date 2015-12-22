using UnityEngine;

using System.Collections;
using System.Collections.Generic;

namespace DragonsDemons.Model
{
	public class Player 
	{
		int level;
		int experience;
		int damage;
		int armor;
		int health;
		int energy;
		PlayerResources resources;
		List<Ability> abilities = new List<Ability>();
	}
}
