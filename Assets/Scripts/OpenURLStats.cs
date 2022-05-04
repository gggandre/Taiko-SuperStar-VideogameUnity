using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Authors Diego Alejandro Balderas Tlahuitzo - A01745336
Gilberto André García Gaytán - A01753176
Paula Sophia Santoyo Arteaga - A01745312
Ricardo Ramirez Condado - A01379299
Paola Danae López Pérez- A01745689*/

/*This code is used to open the url that is specified in it when clicking on the button that says*/

public class OpenURLStats : MonoBehaviour
{

    public string URL = "https://public.tableau.com/app/profile/andre.garc.a.gayt.n3015/viz/TaikoFinal/DashboardHighscoreperlevel?publish=yes"; //put the link where you want it to open

    public void OpenPage()
    {
        Application.OpenURL(URL); //access the link requested above
    }

}
