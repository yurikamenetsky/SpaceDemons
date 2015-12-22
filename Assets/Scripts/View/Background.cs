using UnityEngine;
using UnityEngine.Serialization;

using System.Collections;
using System.Collections.Generic;

namespace PlayerDemons.View
{
	public class Background : MonoBehaviour 
	{
		public float speed = 0.1f;
		float currentPosition;
		float StartPosX;

		[SerializeField] GameObject[] backgrounds;
		[SerializeField] float backgroundHeight = 128;

		void Start()
		{
			StartPosX = backgrounds[0].transform.localPosition.x;
		}
			
		void Update () 
		{
			currentPosition += speed * Time.deltaTime;
			float y = Mathf.Repeat (currentPosition, 1);
			currentPosition = Mathf.Repeat (currentPosition, backgrounds.Length);

			GameObject current = null;
			GameObject next = null;

			if (currentPosition >= backgrounds.Length - 1) {
				current = backgrounds [backgrounds.Length - 1];
				next = backgrounds [0];
			} else {
				for (int i = 0; i < backgrounds.Length - 1; ++i) {
					if (currentPosition >= i && currentPosition < i + 1) {
						current = backgrounds [i];
						next = backgrounds [i + 1];
						break;
					}
				}
			}
			current.transform.localPosition = new Vector2 (StartPosX, -y * backgroundHeight);
			next.transform.localPosition = new Vector2 (StartPosX, -y * backgroundHeight + backgroundHeight);
				
			foreach (var it in backgrounds)
				it.SetActive (it == current || it == next);
		} 
	}
}
