using UnityEngine;
using System.Collections;
using DragonsDemons.Common;

namespace DragonsDemons.View.Enemy
{
	public class Asteroid : MonoBehaviour, IDestroyable 
	{
		public float speed = 0.5f;

		Vector3 rotationAngle;
		float rotationSpeed;

		void Start()
		{
			rotationAngle = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
			rotationSpeed = Random.Range(2f, 4f);
		}

		void Update()
		{
			transform.position += new Vector3(0f, -Time.deltaTime * speed, 0f);
			transform.RotateAround(transform.position, rotationAngle, rotationSpeed);
		}

		public virtual void Destroy()
		{
			Destroy(gameObject);
		}
	}
}
