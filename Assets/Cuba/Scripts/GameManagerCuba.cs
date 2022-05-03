/*Authors:
 * Diego Alejandro Balderas Tlahuitzo - A01745336
   Gilberto André García Gaytán - A01753176
   Paula Sophai Santoyo Arteaga - A01745312
   Ricardo Ramírez Condado - A01379299
   Paola Danae López Pérez- A01745689
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class GameManagerCuba : MonoBehaviour
{
    //First we declare all the components and variables that we will use in the code

    public GameObject LevelFinishedPanel;

    public static GameManagerCuba instance;
    public int points = 0;
    public bool isGameOver = false;
    private int passLevel;
    public GameObject GameOverPanel;

    public SpriteRenderer[] instruments;
    public AudioSource[] buttonSounds;


    private int instrumentSelect;

    public float stayLit;
    private float stayLitCounter;

    public float waitBetweenLights;
    private float waitBetweenCounter;

    private bool shouldBeLit;
    private bool shouldBeDark;

    public List<int> activeSequence;
    private int positionInSequence;

    private bool gameActive;
    private int inputInSequence;

    public AudioSource correct;
    public AudioSource incorrect;

    public TextMeshProUGUI scoreText;


    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldBeLit)
        {
            stayLitCounter -= Time.deltaTime;
            if (stayLitCounter < 0)
            {
                instruments[activeSequence[positionInSequence]].color = new Color(instruments[activeSequence[positionInSequence]].color.r, instruments[activeSequence[positionInSequence]].color.g, instruments[activeSequence[positionInSequence]].color.b, 0.7f);
                buttonSounds[activeSequence[positionInSequence]].Stop();
                shouldBeLit = false;

                shouldBeDark = true;
                waitBetweenCounter = waitBetweenLights;

                positionInSequence++;
            }
        }
        if (shouldBeDark)
        {
            waitBetweenCounter -= Time.deltaTime;

            if (positionInSequence >= activeSequence.Count)
            {
                shouldBeDark = false;
                gameActive = true;
            }
            else
            {
                if (waitBetweenCounter < 0)
                {

                    instruments[activeSequence[positionInSequence]].color = new Color(instruments[activeSequence[positionInSequence]].color.r, instruments[activeSequence[positionInSequence]].color.g, instruments[activeSequence[positionInSequence]].color.b, 1f);
                    buttonSounds[activeSequence[positionInSequence]].Play();

                    stayLitCounter = stayLit;
                    shouldBeLit = true;
                    shouldBeDark = false;
                }
            }
        }
    }

    public void StartGame() //This Function starts the game 
    {
        //First we clean the sequence and update the number of points to zero.  This action allows to reset the game whe the player presses the buttom and allows the player play from the beginning
        activeSequence.Clear();
        points = 0;
        HUDCuba.instance.UpdatePoints();

        //Then the positionInSequence and the input start in the position number zero
        positionInSequence = 0;
        inputInSequence = 0;

        //The game select the number of an instrument, this selection is a random value between zero and the number of instruments
        instrumentSelect = Random.Range(0, instruments.Length);

        //The game add the instrement previously selected into the current sequence
        activeSequence.Add(instrumentSelect);

        //Then the instrument(s) that are include in the sequence increas the hue of their colors and play their sound
        instruments[activeSequence[positionInSequence]].color = new Color(instruments[activeSequence[positionInSequence]].color.r, instruments[activeSequence[positionInSequence]].color.g, instruments[activeSequence[positionInSequence]].color.b, 1f);
        buttonSounds[activeSequence[positionInSequence]].Play();

        //Finally the game update the number of instruments that are include in the sequence and indicates the lights were on
        stayLitCounter = stayLit;
        shouldBeLit = true;
    }

    public void ColorPressed(int whichButton) //This function determains if the instrument that the player click on it is the correct
    {
        //First the game check if the game is active
        if (gameActive)
        {
            //Then the game compares if the number of the current instrument in the sequence is the same number of the instrument that the player presses
            if (activeSequence[inputInSequence] == whichButton)
            {
                //If is the same, the player earn 10 points, then this number of points is update into the view of the player
                Debug.Log("Correct");
                correct.Play();
                points += 10;
                HUDCuba.instance.UpdatePoints();
                //The game increases the number of imput
                inputInSequence++;

                //if there are more or equal numbers of inputs and instruments into the sequence, the game adds a new one, using the same method as in the fucntion "Start game"
                if (inputInSequence >= activeSequence.Count)
                {
                    positionInSequence = 0;
                    inputInSequence = 0;

                    instrumentSelect = Random.Range(0, instruments.Length);

                    activeSequence.Add(instrumentSelect);

                    instruments[activeSequence[positionInSequence]].color = new Color(instruments[activeSequence[positionInSequence]].color.r, instruments[activeSequence[positionInSequence]].color.g, instruments[activeSequence[positionInSequence]].color.b, 1f);
                    buttonSounds[activeSequence[positionInSequence]].Play();

                    stayLitCounter = stayLit;
                    shouldBeLit = true;

                    gameActive = false;
                }
            }
            else //if the number of the instrument that the player presseses is not the same as the number of the instrument in the sequence the player lose the game
            {
                //The game check if the player has the minimun points that he needs, in this case 500, if the player has the minimun points the player will see the level finished panel
                if (points >= 100)
                {
                    Debug.Log("Wrong");
                    incorrect.Play();
                    gameActive = false;
                    LevelFinishedPanel.SetActive(true);
                    passLevel = 1;
                    SendData();
                }
                else
                {//if the player hasn't the minimun points the player will see the Game Over Panel
                    Debug.Log("Wrong");
                    incorrect.Play();
                    gameActive = false;
                    GameOverPanel.SetActive(true);
                    passLevel = 0;
                    SendData();
                }
            }

        }
    }


    public void SendData()
    {
        StartCoroutine(submitData());
    }

    private IEnumerator submitData()
    {
        string user = NetworkManager.instance.username.text;
        int IDlevel = 1;
        int score = points;
        int pass = passLevel;

        Debug.Log("sent info");

        WWWForm form = new WWWForm();
        form.AddField("Username", user);
        form.AddField("IDNivel", IDlevel);
        form.AddField("Puntaje", score);
        form.AddField("Superado", pass);

        UnityWebRequest request = UnityWebRequest.Post("http://www.taikosuperstar.com/php_code/recibe_data.php", form);
        yield return request.SendWebRequest();
    }

}
