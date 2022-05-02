using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Authors with creator permission Diamond 32 Tutorials https://www.youtube.com/watch?v=2wcWowi1sUM&t=855s
 * Diego Alejandro Balderas Tlahuitzo - A01745336
Gilberto André García Gaytán - A01753176
Paula Sophia Santoyo Arteaga - A01745312
Ricardo Ramirez Condado - A01379299
Paola Danae López Pérez- A01745689*/

/*  This code is used in the event that the game is used on another platform other than PC, be sure  */

public class Seguridad
{
    private WWWForm m_secureForm = null;
    private const string CONNECTION_PASSWORD = "Lx!537u^h?vnb#?";
    private const string CONNECTION_PASSWORD_ANDROID = "d8RXq+bE@mXcm3";
    private const string CONNECTION_PASSWORD_windows = "Ys*xrUz73%#vPV?";
    private const string CONNECTION_PASSWORD_IOS = "5y=ARb7th+fPdWm";
    private const string CONNECTION_PASSWORD_PS4 = "fRTb4nd?gM^GBP=";
    private const string CONNECTION_PASSWORD_Xone = "G=yZ2RN3Jguw8X";
    private const string CONNECTION_PASSWORD_WII = "ZAXn8-_?vsKumTG";
    private const string CONNECTION_PASSWORD_OSX = "LGn!6VgXse-VT7x";
    private const string CONNECTION_PASSWORD_LINUX = "bsw?QFw+h!zQ9Q";

    public WWWForm secureForm { get { return m_secureForm; } }

    public Seguridad()
    {
        m_secureForm = new WWWForm();

        m_secureForm.AddField("ConectionPass", CONNECTION_PASSWORD);

#if UNITY_ANDROID
        m_secureForm.AddField ("os", "android");
        m_secureForm.AddField ("plataformpass", CONNECTION_PASSWORD_ANDROID);
#endif

#if UNITY_IOS
        m_secureForm.AddField("os", "ios");
        m_secureForm.AddField("plataformpass", CONNECTION_PASSWORD_IOS);
#endif

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        m_secureForm.AddField("os", "windows");
        m_secureForm.AddField("plataformpass", CONNECTION_PASSWORD_windows);
#endif

#if UNITY_PS4
        m_secureForm.AddField("os", "ps4");
        m_secureForm.AddField("plataformpass", CONNECTION_PASSWORD_PS4);
#endif

#if UNITY_XBOXONE
        m_secureForm.AddField("os", "xboxone");
        m_secureForm.AddField("plataformpass", CONNECTION_PASSWORD_Xone);
#endif

#if UNITY_WII
        m_secureForm.AddField("os", "wii");
        m_secureForm.AddField("plataformpass", CONNECTION_PASSWORD_WII);
#endif

#if UNITY_STANDALONE_OSX
        m_secureForm.AddField("os", "osx");
        m_secureForm.AddField("plataformpass", CONNECTION_PASSWORD_OSX);
#endif

#if UNITY_STANDALONE_LINUX
        m_secureForm.AddField("os", "linux");
        m_secureForm.AddField("plataformpass", CONNECTION_PASSWORD_LINUX);
#endif
    }
}
