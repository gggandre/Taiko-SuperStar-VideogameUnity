/*Authors:
 * Diego Alejandro Balderas Tlahuitzo - A01745336
   Gilberto André García Gaytán - A01753176
   Paula Sophia Santoyo Arteaga - A01745312
   Ricardo Ramírez Condado - A01379299
   Paola Danae López Pérez- A01745689
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This code is used to manage de IU's components that the player can see. 
public class HUDJapan : MonoBehaviour
{

    //First we declare all the components and variables that we will use in the code 

    public GameManagerJapan manager;
    public static HUDJapan instance;
    public TextMeshProUGUI txtPoints;
    public bool isLevelFinished = false;
    public GameObject LevelFinishedPanel;


    private void Awake()
    {
        //We define that the instance references means this instance (the script)
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //When the game starts we assing 0 points to the player, then the game update the view.  The player see 0 points
        int points = PlayerPrefs.GetInt("numberPoints", 0);
        GameManagerJapan.instance.points = points;
        UpdatePoints();

    }


    public void UpdatePoints() //Function to update the points of the player in his score
    {
        int points = GameManagerJapan.instance.points;
        txtPoints.text = points.ToString();
    }

    public void FinishLevel() //Function for change the value of the variable that defines if the level is already finished
    {
        isLevelFinished = true;//The level finish
    }


}
