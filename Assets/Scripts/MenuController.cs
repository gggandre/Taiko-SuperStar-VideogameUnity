using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*Authors Diego Alejandro Balderas Tlahuitzo - A01745336
Gilberto André García Gaytán - A01753176
Paula Sophia Santoyo Arteaga - A01745312
Ricardo Ramirez Condado - A01379299
Paola Danae López Pérez- A01745689*/

/*This is a very simple code to be able to handle the start menu*/

public class MenuController : MonoBehaviour
{
    // It loads the scene that you tell it in unity, the levelID is used, since when you list the scenes you can call them like this
    // in a simpler way

    public void LoadGameLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

    //If the exit game button is clicked, it takes you out of the game once you have the executable
    public void ExitGame()
    {
        Application.Quit();
    }
}
