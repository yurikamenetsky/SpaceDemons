using UnityEngine;
using System.Collections;

namespace DragonsDemons.Utils
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        [Range(5f, 100f)]
		float speed = 0.5f;

		[SerializeField] Renderer playerRenderer;

		public float boundX;
		public float boundY;

		bool isMoved = false;
		Vector3 currentDelta;

		void Update () {
			if (Input.touchCount > 0) 
			{
				Touch touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began && !isMoved)
				{
					isMoved = true;
					Vector3 newPosition = Camera.main.WorldToScreenPoint(transform.position);
					newPosition.z = transform.position.z;
					currentDelta = newPosition - new Vector3(touch.position.x, touch.position.y, 0);
				}
				else if(touch.phase == TouchPhase.Ended)
				{
					isMoved = false;
				}
				else if (isMoved && (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)) 
				{
					Vector3 movePosition = new Vector3(touch.position.x + currentDelta.x, touch.position.y + currentDelta.y, 
						-Camera.main.transform.position.z);
					Vector3 realPos = Camera.main.ScreenToWorldPoint(movePosition);
					realPos.z = transform.position.z;
					Vector3 newPosition = Vector3.Lerp(transform.position, realPos, Time.deltaTime * speed);
					newPosition.x = Mathf.Max(newPosition.x, -boundX);
					newPosition.x = Mathf.Min(newPosition.x, boundX);
					newPosition.y = Mathf.Max(newPosition.y, -boundY);
					newPosition.y = Mathf.Min(newPosition.y, boundY);
					transform.position = newPosition;
					/*Bounds bounds = playerRenderer.bounds;
					Vector3 maxPos = Camera.main.WorldToViewportPoint(new Vector3(bounds.max.x, bounds.max.y, 0f));
					Vector3 minPos = Camera.main.WorldToViewportPoint(new Vector3(bounds.min.x, bounds.min.y, 0f));
					maxPos.x = Mathf.Clamp01(maxPos.x);
					minPos.x = Mathf.Clamp01(minPos.x);
					maxPos.y = Mathf.Clamp01(maxPos.y);
					minPos.y = Mathf.Clamp01(minPos.y);
					Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
					pos.x = (maxPos.x + minPos.x) * 0.5f;
					pos.y = (maxPos.y + minPos.y) * 0.5f;
					transform.position = Camera.main.ViewportToWorldPoint(pos);*/
				}
			}
		}
    }
}
