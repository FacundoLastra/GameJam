using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollider : MonoBehaviour
{
		public GameObject player;
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
			Debug.Log("TRIGGER");
			HealthController.getInstance();
			HealthController.getInstance().addHealth(20f);
			//GetComponent("Health Controller").addHealth(20f);
		}
}
