using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;




public class SaveDataManager : MonoBehaviour {

	public string key = "Highscore";

	public static SaveDataManager saveDataInstance = null;
	public static int money;
	public static int health;
	public static int score;



	void Awake () {

		//Singleton Pattern

		//If an saveDatainstance doesn't exist
		if (saveDataInstance == null) {
			//set mpInstance to be the "SaveDataManager" component of this gameobject
			saveDataInstance = this;
			//Don't destory this gameobject duirng level changes
			DontDestroyOnLoad (this);
		} 
		else {
			//if any other instance is made destroy it.
			Destroy (gameObject);
			return;
		}


		
	}

	void Start () {
		InvokeRepeating ("SetCurrentScore", 0, 0.2f);
	}


	/*public class HighScore  {
		

	public HighScore(){
			
		}



		public int[] stats;



		public XmlSchema GetSchema () {
			return null;
		}

		public void WriteXml(XmlWriter writer){
			//TODO Save info here
			writer.WriteAttributeString("Score", score.ToString());


		}

		public void ReadXml (XmlReader reader){
			reader.MoveToAttribute ("Score");
			money = reader.ReadContentAsInt ();

		

			Debug.Log ("ReadXML");
		
	}
	}*/
		

	public void SetHighScore () {
		PlayerPrefs.SetInt (key, score + SaveDataManager.money * 3);
		



		/*Debug.Log ("Save Button Clicked");
		//Player Data

		XmlSerializer seralizerWorld = new XmlSerializer (typeof(WorldData));
		//FileStream pStream= new FileStream(Application.dataPath + "playerData.sav",FileMode.Create);

		TextWriter writer2 = new StringWriter ();
		//seralizer.Serialize (writer, wd);
		seralizer.Serialize (writer,  pd);
		seralizerWorld.Serialize (writer2, wd);
		Debug.Log (writer.ToString ());
		Debug.Log (writer2.ToString ());
		writer.Close ();
		writer2.Close ();

		//Saving High Score
		XmlSerializer seralizer = new XmlSerializer (typeof(HighScore));
		TextWriter writer = new StringWriter ();
		seralizer.Serialize (writer,  pd);

		PlayerPrefs.SetString ("Savegame00", writer.ToString ());
	

*/



		//Saves the data in a custom file extension in the game folder 
		//Wave Data



	}

	public void SetCurrentScore(){



		if((score + SaveDataManager.money * 3) > PlayerPrefs.GetInt (key, 0)){
			SetHighScore ();
		}
	
		

	}

	public void ShowHighscore () {
		Debug.Log(PlayerPrefs.GetInt(key));

	}

}
	


	/*public void WriteXml (XmlWriter writer) {
	//	writer.WriteAttributeString("


		GameObject[] turretList = GameObject.FindGameObjectsWithTag ("Building Block");
		Debug.Log (turretList.Length);

		for (int i = 0; i < turretList.Length; i++) {
			


			writer.WriteStartElement ("TurretData");
			writer.WriteElementString("Position",writer.WriteValue (turretList[i].transform.position.ToString()));
			if (turretList [i].GetComponent<TurretBox> ().selectedTurretClone != null) 
				writer.WriteElementString("SelectedTurretClone ",turretList[i].GetComponent<TurretBox>().selectedTurretClone.name);
			writer.WriteElementString("Upgrade Version", turretList [i].GetComponent<TurretBox> ().upgradeVersion.ToString());

			writer.WriteEndElement ();

		}
	
	}


	public void ReadXml (XmlReader reader) {
	}		
}*/




