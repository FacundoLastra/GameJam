using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollider : MonoBehaviour
{
		private GameObject player;
		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		void OnTriggerEnter()
		{
			player = GameObject.Find("Game");
			HealthController.getInstance();
			HealthController.getInstance().addHealth(20f);
		    Destroy(gameObject);
		}
}
