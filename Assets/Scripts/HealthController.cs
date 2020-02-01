using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
		public float currentHealth = 100f;
		public float maxHealth = 200f;
		public float staticDamage = 1f;
		public GameObject HealthUI;
		private static HealthController _instance;

		// Start is called before the first frame update
		void Start()
		{
			if (_instance == null) {
				_instance = this;
			} else {
				Destroy(gameObject);
			}
		}

		// Update is called once per frame
		void Update()
		{
			if (currentHealth < maxHealth) {
				currentHealth -= staticDamage * Time.deltaTime;
			};
			UpdateUI();
		}

		void UpdateUI() {
			HealthUI.GetComponent<UnityEngine.UI.Text>().text = currentHealth.ToString();
		}

		public static HealthController getInstance() {
			return _instance;
		}

		public void addHealth(float KeyValuePair) {
			currentHealth += KeyValuePair;
		}
}
