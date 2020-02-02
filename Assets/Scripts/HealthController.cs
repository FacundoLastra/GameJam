using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
		public float currentHealth = 100f;
		public float maxHealth = 200f;
		public float staticDamage = 1f;
		public Slider HealthUI;
		private static HealthController _instance;
	    public Animator deathMenuAnim;
	    private bool isDead = false;
	    public SwipeController playerController;

	    // Start is called before the first frame update
	    void Start()
		{
			if (_instance == null) {
				_instance = this;
			} else {
				Destroy(gameObject);
			}
		}

		// Update is called once per frames
		void Update()
		{
			if (currentHealth < maxHealth) {
				currentHealth -= staticDamage * Time.deltaTime;
			};

            if(currentHealth < 0 && !isDead)
            {
			    playerController.Crash();
            }
			UpdateUI();
		}

		void UpdateUI() {
			HealthUI.GetComponent<UnityEngine.UI.Slider>().value = currentHealth;
		}

		public static HealthController getInstance() {
			return _instance;
		}

		public void addHealth(float KeyValuePair) {
			currentHealth += KeyValuePair;
		}

	    public void OnPlayButton()
	    {
            if(isDead)
		        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
	    }

	    public void OnDeath()
	    {
		    deathMenuAnim.SetTrigger("Dead");
		    isDead = true;
		    HealthUI.gameObject.SetActive(false);

			Debug.Log("dead");
	    }
}
