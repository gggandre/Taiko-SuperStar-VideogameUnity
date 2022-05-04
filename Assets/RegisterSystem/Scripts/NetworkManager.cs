using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


/*Authors Diego Alejandro Balderas Tlahuitzo - A01745336
Gilberto André García Gaytán - A01753176
Paula Sophia Santoyo Arteaga - A01745312
Ricardo Ramirez Condado - A01379299
Paola Danae López Pérez- A01745689*/

/*   What this code does is connect through the php to the database and thus determine the connection with it   */

public class NetworkManager : MonoBehaviour
{
    //Here the variables are placed to put the links to the php of the database
    public string RegisterHostUrl = "https://libertadsincolitis.com/php_code/register.php";
    public string LoginHostUrl = "https://libertadsincolitis.com/php_code/chechUser.php";
    public Text m_SendText;

    public Text username;

    public static NetworkManager instance;

    private void Awake()
    {
        //We define that the instance references means this instance (the script)
        instance = this;
    }


    //The coroutine is created to be able to detect if you need to register
    #region REGISTERUSER
    public void SubmitRegister(string user, string email, string pass, Action<Response> response)
    {
        StartCoroutine(Co_CreateUser(user, email, pass, response));
    }


    //If you do not have an account, it sends you to the register page to create your user
    IEnumerator Co_CreateUser(string user, string email, string pass, Action<Response> response)
    {
        Seguridad form = new Seguridad();
        form.secureForm.AddField("userName", user);
        form.secureForm.AddField("email", email);
        form.secureForm.AddField("pass", pass);

        WWW www = new WWW(RegisterHostUrl, form.secureForm);
        yield return www;
        Debug.Log(www.text);

        response(JsonUtility.FromJson<Response>(www.text));



    }

    #endregion




    #region LOGINUSER
    //If it detects that the username and password are correct, it does the following
    public void LoginUser(string user, string pass, Action<Response> response)
    {
        StartCoroutine(Co_LoginUser(user, pass, response));
    }

    IEnumerator Co_LoginUser(string user, string pass, Action<Response> response)
    {
        Seguridad form = new Seguridad();
        form.secureForm.AddField("userName", user);
        form.secureForm.AddField("pass", pass);

        WWW www = new WWW(LoginHostUrl, form.secureForm);
        yield return www;
        Debug.Log(www.text);

        response(JsonUtility.FromJson<Response>(www.text));



    }
    #endregion
}


[System.Serializable]
public class Response
{
    public bool done = false;
    public string message = "";
}