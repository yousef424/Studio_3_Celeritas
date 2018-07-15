using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDataEntry : MonoBehaviour
{

    private string insertUserURL = "https://royalriches.000webhostapp.com/Insert_User.php";
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
        SceneManager.LoadScene("Login");
    }
    IEnumerator CreatAccount(string email,string username,string password)
    {
        WWWForm accountDatabase = new WWWForm();
        accountDatabase.AddField("emailFromUser", email);
        accountDatabase.AddField("usernameFromUser", username);
        accountDatabase.AddField("passwordFromUser", password);
        WWW register = new WWW(insertUserURL, accountDatabase);
        yield return accountDatabase;
        Debug.Log(register.text);
    }
}
