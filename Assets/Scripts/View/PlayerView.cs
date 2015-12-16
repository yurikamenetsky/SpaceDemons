using UnityEngine;

using System.Collections;

using DragonsDemons.Common;

namespace DragonsDemons.View
{
    public class PlayerView : MonoBehaviour
    {
		void OnTriggerEnter(Collider other)
		{
			if(other.GetComponent<IDestroyable>() != null)
			{
				other.GetComponent<IDestroyable>().Destroy();
			}
		}
    }
}
