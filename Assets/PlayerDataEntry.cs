using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataEntry : MonoBehaviour
{

    private string insertUserURL = "http://localhost/studio_3_player_data/Insert_User.php";
    public string inputEmail;
    public string inputUserName;
    public string inputPassWord;
    public Text inputEmailText;
    public Text inputUsernameText;
    public Text inputPasswordText;

    public void Initate()
    {
        inputEmail = inputEmailText.text;
        inputUserName = inputUsernameText.text;
        inputPassWord = inputPasswordText.text;
        CreatAccount(inputEmail, inputUserName, inputPassWord);
    }
    public void CreatAccount(string email,string username,string password)
    {
        WWWForm accountDatabase = new WWWForm();
        accountDatabase.AddField("emailFromUser", email);
        accountDatabase.AddField("usernameFromUser", username);
        accountDatabase.AddField("passwordFromUser", password);
        WWW register = new WWW(insertUserURL, accountDatabase);
    }
}
