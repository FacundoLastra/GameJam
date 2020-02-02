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
	public RawImage MaskImage;
	private static HealthController _instance;
	public Animator deathMenuAnim;
	private bool isDead = false;
	public SwipeController playerController;

	// Mask Textures
	public Texture maskTexture0;
	public Texture maskTexture1;
	public Texture maskTexture2;
	public Texture maskTexture3;
	public Texture maskTexture4;

	// Start is called before the first frame update
	void Start()
	{
		if (_instance == null)
		{
			_instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// Update is called once per frames
	void Update()
	{
		currentHealth -= staticDamage * Time.deltaTime;
		

		if (currentHealth < 0 && !isDead)
		{
			playerController.Crash();
		}
		UpdateUI();
	}

	void UpdateUI()
	{
		HealthUI.GetComponent<UnityEngine.UI.Slider>().value = currentHealth;

		if (currentHealth < 20)
			MaskImage.GetComponent<RawImage>().texture = maskTexture0;
		else if (currentHealth < 40)
			MaskImage.GetComponent<RawImage>().texture = maskTexture1;
		else if (currentHealth < 60)
			MaskImage.GetComponent<RawImage>().texture = maskTexture2;
		else if (currentHealth < 80)
			MaskImage.GetComponent<RawImage>().texture = maskTexture3;
		else
			MaskImage.GetComponent<RawImage>().texture = maskTexture4;

	}

	public static HealthController getInstance()
	{
		return _instance;
	}

	public void addHealth(float KeyValuePair)
	{
		currentHealth += KeyValuePair;
	}

	public void OnPlayButton()
	{
		if (isDead)
			UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
	}

	public void OnDeath()
	{
		deathMenuAnim.SetTrigger("Dead");
		isDead = true;
		HealthUI.gameObject.SetActive(false);
		MaskImage.gameObject.SetActive(false);

		Debug.Log("dead");
	}
}