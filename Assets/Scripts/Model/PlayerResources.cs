using UnityEngine;

using System.Collections;
using System.Collections.Generic;

namespace DragonsDemons.Model
{
	public class PlayerResources
	{
		public enum ResourceType
		{
			Gold,
			Crystal
		}

		public static Dictionary<ResourceType, string> namingMap = new Dictionary<ResourceType, string>
		{
			{ResourceType.Gold, "gold"},
			{ResourceType.Crystal, "crystal"}
		};

		Dictionary<string, int> resources = new Dictionary<string, int>();

		public int GetResource(string resId)
		{
			return resources[resId];
		}

		public int GetResource(ResourceType typeId)
		{
			return resources[namingMap[typeId]];
		}
	}
}
