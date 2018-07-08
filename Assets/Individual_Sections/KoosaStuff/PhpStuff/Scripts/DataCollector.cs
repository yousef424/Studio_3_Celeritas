using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCollector : MonoBehaviour 
{
	public WWW playerData;
	public string playerDataString;
	public List<string> playerDataList= new List<string>();
	public string[] playerDataArray;
    public string dataToDisplay;
    public int playerIndex;
    public bool getData;

    public void Data()
    {
        StartCoroutine(DisplayData());
    }
	// Use this for initialization
	public IEnumerator DisplayData () 
	{
		playerData = new WWW("https://royalriches.000webhostapp.com/Player_data.php");
		yield return playerData;
        playerDataString = playerData.text;
		Debug.Log(playerData.text);
        playerDataArray = playerDataString.Split(';');
        Debug.Log(GetSpecifiedData(playerDataArray[playerIndex], dataToDisplay));
	}

    string GetSpecifiedData(string data,string index)
    {
        string specifiedData = data.Substring(data.IndexOf(index) + index.Length);
        if (specifiedData.Contains("|"))
        {
           specifiedData = specifiedData.Remove(specifiedData.IndexOf('|'));
        }
        return specifiedData;
    }



}
