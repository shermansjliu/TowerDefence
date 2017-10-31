using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public static int money ;
	public static int health ;

	int startMoney = 100;
	int startHealth = 20;

	public Text moneyText;

	void Start () {
		money = startMoney;
		health = startHealth;
		InvokeRepeating ("UpdateText", 0, 0.3f);
	}

	void UpdateText () {
		moneyText.text = "$" + money;
	}
}
