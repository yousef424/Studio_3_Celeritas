using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogin : MonoBehaviour
{

    public string inputUserName;
    public string inputPassWord;
    private string playerLoginURL= "http://localhost/studio_3_player_data/Login.php";
    public Text inputUsernameText;
    public Text inputPasswordText;

    public void Initate()
    {
        inputUserName = inputUsernameText.text;
        inputPassWord = inputPasswordText.text;
        StartCoroutine(Login(inputUserName, inputPassWord));
    }

    IEnumerator Login(string userName,string passWord)
    {
        WWWForm accountDatabase = new WWWForm();
        accountDatabase.AddField("usernameFromUser", userName);
        accountDatabase.AddField("passwordFromUser", passWord);
        WWW login = new WWW(playerLoginURL, accountDatabase);
        yield return login;
        Debug.Log(login.text);

    }
}
