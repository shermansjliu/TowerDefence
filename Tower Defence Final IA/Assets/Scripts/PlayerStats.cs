using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour {

	public static int money ;
	public static int health ;

	public int startMoney;
	public int startHealth;

	public TextMeshProUGUI moneyText;
	public TextMeshProUGUI healthText;

	void Start () {
		money = startMoney;
		health = startHealth;
		InvokeRepeating ("UpdateText", 0, 0.3f);
	}

	void UpdateText () {
		moneyText.text = "$" + money;
		healthText.text = "Lives " + health;
	}
}
