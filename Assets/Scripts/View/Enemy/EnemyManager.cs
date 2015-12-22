using UnityEngine;
using System.Collections;

namespace DragonsDemons.View.Enemy
{
	public class EnemyManager : MonoBehaviour 
	{
		[SerializeField] GameObject[] asteroidPrefabs;
		[SerializeField] Vector2 boundsX;
		[SerializeField] float maxY;

		void Start()
		{
			Invoke("CreateAsteroid", Random.Range(1f, 2f));
		}

		void CreateAsteroid()
		{
			GameObject go = Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)]) as GameObject;
			go.transform.parent = transform;
			go.transform.position = new Vector3(Random.Range(boundsX.x, boundsX.y), maxY, Random.Range(3, 15));
			go.transform.Rotate(new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)));
			Invoke("CreateAsteroid", Random.Range(1f, 5f));
		}
	}
}
