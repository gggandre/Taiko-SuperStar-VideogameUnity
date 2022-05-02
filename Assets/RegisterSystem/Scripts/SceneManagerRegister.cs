using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

/*Authors Diego Alejandro Balderas Tlahuitzo - A01745336
Gilberto André García Gaytán - A01753176
Paula Sophia Santoyo Arteaga - A01745312
Ricardo Ramirez Condado - A01379299
Paola Danae López Pérez- A01745689*/

/*   This code is used to detect if you are logging in correctly   */

public class SceneManagerRegister : MonoBehaviour
{
    #region Login
    [Header("Login Inputs")]
    public InputField m_PasswordInputLogin;

    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }

    internal static void LoadScene(int levelID)
    {
        throw new NotImplementedException();
    }

    public InputField m_UserInputLogin;
    #endregion

    #region Register
    [Header("Register Inputs")]
    [SerializeField] private InputField m_Username;
    [SerializeField] private InputField m_Email;
    [SerializeField] private InputField m_Password;
    [SerializeField] private InputField m_ConfirmPassword;
    [SerializeField] private Text m_ErrorText;



    [SerializeField] private GameObject m_PanelLogin;
    [SerializeField] private GameObject m_PanelRegister;
    #endregion
    private NetworkManager m_NetworkManager;

    [Header("Direcciones de correo")]
    public string[] Emails;
    public bool cuentaRegistradaConExito;
    public int MaxLenght;


    void Start()
    {
        m_NetworkManager = FindObjectOfType <NetworkManager>();

    }

    //<summary>
    //Order to send data
    //user
    //email
    //pass
    //<summary>

    public void submitLogin()
    {

                if (m_PasswordInputLogin.text == "" || m_UserInputLogin.text == "")
                {
                    m_ErrorText.text = "Error 444: Check that no field is empty";
                    return;
                }

                m_NetworkManager.LoginUser(m_UserInputLogin.text, m_PasswordInputLogin.text, delegate (Response response)
                {
                    m_ErrorText.text = "Logging wait a moment...";
                    m_ErrorText.text = response.message;

                    if (response.done)
                    {
                        m_ErrorText.text = "Next Scene...";
                        m_ErrorText.text = response.message;
                        submitLogin();
                        {
                           SceneManager.LoadScene("01 Start Menu");
  
                        }
                    }

                    else
                    {
                        m_ErrorText.text = "Error, please login";
                        m_ErrorText.text = response.message;
                    }
                });
    }

    void blankRegisterSpace()
    {
        m_Username.text = "";
        m_Email.text = "";
        m_Password.text = "";
        m_ConfirmPassword.text = "";
    }

    public void SubmitRegister()
    {
        foreach (string emailSet in Emails)
        {
            if (m_Email.text.Contains(emailSet)) {
                cuentaRegistradaConExito = true;
                if (m_Username.text == "" || m_Email.text == "" || m_Password.text == "" || m_ConfirmPassword.text == "")
                {
                    m_ErrorText.text = "Error 444: Check that no field is empty";
                    return;
                }

                if (m_Password.text == m_ConfirmPassword.text)
                {
                    if (m_Password.text.Length >= MaxLenght) {
                        m_ErrorText.text = "Processing information please wait a moment";
                        m_NetworkManager.SubmitRegister(m_Username.text, m_Email.text, m_Password.text, delegate (Response response)
                        {

                            m_ErrorText.text = response.message;
                            if (response.done == true)
                            {
                                ////WRITE ACCEPTANCE CODE WHEN REGISTERING
                                cuentaRegistradaConExito = false;
                                blankRegisterSpace();
                                print("Account Created successfully");
                            }
                            else
                            {
                                ///ACTION BY NOT REGISTERING ACCOUNT
                                cuentaRegistradaConExito = true;
                                blankRegisterSpace();
                                print("Account is not created, please create one");

                            }
                        });
                    }
                    else
                    {
                        m_ErrorText.text = "Your password must contain at least 8 characters";
                    }
                }
                else
                {
                    m_ErrorText.text = "Error 565: There are data that are not similar, try again";
                    return;
                }
            }

            if (!m_Email.text.Contains (emailSet) && !cuentaRegistradaConExito)
            {
                    m_ErrorText.text = "Error 877: We're sorry, but a valid email cannot be read.";
            }
        }
    }
}