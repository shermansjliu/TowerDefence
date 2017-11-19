using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour {



	public int startMoney;
	public int startHealth;

	public TextMeshProUGUI moneyText;
	public TextMeshProUGUI healthText;
	public TextMeshProUGUI scoreText;



	void Start () {
		SaveDataManager.money = startMoney;
		SaveDataManager.health = startHealth;
		InvokeRepeating ("UpdateText", 0, 0.3f);
	}

	void UpdateText () {
		scoreText.text = "Score " +  SaveDataManager.score;
		moneyText.text = "$" + SaveDataManager.money;
		healthText.text = "Lives " + SaveDataManager.health;
	}

}
