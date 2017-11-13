using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//LIbrary that helps us serlize files to a binary format
using System.Runtime.Serialization.Formatters.Binary;
//LIbary that helps us open files
using System.IO;



public static class SavaDataManager {



	public static void SaveData (PlayerStats pm) {
		//Create a new binary formatter to seralize the data from a script to binary format or vice versa
		BinaryFormatter bf = new BinaryFormatter();
		//Saves the data in a custom file extension in the game folder 
		FileStream wStream= new FileStream(Application.persistentDataPath + "WaveState.sav",FileMode.Create);
		FileStream pStream = new FileStream (Application.persistentDataPath + "/playerstats.sav",FileMode.Create);
		//Create a new player stats instance
		PlayerStatsData data = new PlayerStatsData (pm);
		//Save the instance into the file stream by converting it into a binary format
		bf.Serialize (pStream, data);
		//Close the file stream
		pStream.Close ();
	}
	public static int[] LoadPlayerStats () {
		if (File.Exists("playerstats.sav")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream pStream = new FileStream (Application.persistentDataPath + "/playerstats.sav",FileMode.Open);
			PlayerStatsData data = (PlayerStatsData)bf.Deserialize (pStream);
			pStream.Close ();
			return data.stats;
		}
		return new int[1];

	}

}

[System.Serializable]
public class PlayerStatsData {
	public int[] stats;

	public PlayerStatsData (PlayerStats pm){
		stats = new int[3];
		stats [0] = pm.saveMoney;
		stats [1] = pm.saveHealth;
		stats [2] = pm.highScore;

	
	}
}

