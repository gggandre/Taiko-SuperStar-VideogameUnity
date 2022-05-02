using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Authors Diego Alejandro Balderas Tlahuitzo - A01745336
Gilberto André García Gaytán - A01753176
Paula Sophia Santoyo Arteaga - A01745312
Ricardo Ramirez Condado - A01379299
Paola Danae López Pérez- A01745689*/


/* a script is created to give behavior to the menu
Pause.The script is assigned to the Canvas*/

public class MenuPause : MonoBehaviour
{
    public GameObject panelPause; //the gameobject is created with the pause panel
    public bool isPaused = false; //it is said that it is not paused

    public void Paused()
    { //if the pause function is done, the panel is removed
        isPaused = !isPaused;
        panelPause.SetActive(isPaused);

    }

    private void Update()
    {
        //if the escape button is clicked the pause is activated
        if (Input.GetKey(KeyCode.Escape))
        {
            Paused();
        }
    }
}