using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserDataManagement : MonoBehaviour
{
    #region PHP file URLs
    private string playerLoginURL = "https://royalriches.000webhostapp.com/Login.php";
    private string insertUserURL = "https://royalriches.000webhostapp.com/Insert_User.php";
    #endregion

    #region Public Variables
    public string inputEmail;
    public string inputUserName;
    public string inputPassWord;
    public Text inputEmailText;
    public Text inputUsernameText;
    public Text inputPasswordText;
    #endregion

    #region Coroutines
    IEnumerator Login(string userName, string passWord)
    {
        WWWForm accountDatabase = new WWWForm();
        accountDatabase.AddField("usernameFromUser", userName);
        accountDatabase.AddField("passwordFromUser", passWord);
        WWW login = new WWW(playerLoginURL, accountDatabase);
        yield return login;
        Debug.Log(login.text);
    }

    IEnumerator CreatAccount(string email, string username, string password)
    {
        WWWForm accountDatabase = new WWWForm();
        accountDatabase.AddField("emailFromUser", email);
        accountDatabase.AddField("usernameFromUser", username);
        accountDatabase.AddField("passwordFromUser", password);
        WWW register = new WWW(insertUserURL, accountDatabase);
        yield return register;
        Debug.Log(register.text);
    }
    
    #endregion
    #region My Functions
    public void StartLogin()
    {
        inputUserName = inputUsernameText.text;
        inputPassWord = inputPasswordText.text;
        StartCoroutine(Login(inputUserName, inputPassWord));
        SceneManager.LoadScene("Lobby");
        PlayerPhoton.playerPhotonInstance.SetPlayerStats(inputUserName, inputPassWord);
    }
    public void StartCreatAccount()
    {
        inputEmail = inputEmailText.text;
        inputUserName = inputUsernameText.text;
        inputPassWord = inputPasswordText.text;
        StartCoroutine(CreatAccount(inputEmail, inputUserName, inputPassWord));
        StartCoroutine(Login(inputUserName, inputPassWord));
        PlayerPhoton.playerPhotonInstance.SetPlayerStats(inputUserName, inputPassWord);
        SceneManager.LoadScene("Lobby");

    }
    #endregion


}
