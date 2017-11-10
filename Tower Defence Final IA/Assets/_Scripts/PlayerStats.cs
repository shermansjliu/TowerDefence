using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour {

	public static int money ;
	public static int health ;
	public static int score;

	public int startMoney;
	public int startHealth;

	public TextMeshProUGUI moneyText;
	public TextMeshProUGUI healthText;
	public TextMeshProUGUI scoreText;

	void Start () {
		score = 0;
		money = startMoney;
		health = startHealth;
		InvokeRepeating ("UpdateText", 0, 0.3f);
	}

	void UpdateText () {
		scoreText.text = "Score " + score;
		moneyText.text = "$" + money;
		healthText.text = "Lives " + health;
	}
}
