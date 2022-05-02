using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*Authors Diego Alejandro Balderas Tlahuitzo - A01745336
Gilberto André García Gaytán - A01753176
Paula Sophia Santoyo Arteaga - A01745312
Ricardo Ramirez Condado - A01379299
Paola Danae López Pérez- A01745689*/

/*This code is used to manage the dialogs in general that we use in the game, 
in this case to give the information of the select levels scene and the information of the instruments of each country*/


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textD;

    [TextArea(3, 30)] //Text area is used so that the paragraphs in unity can be seen in a better way
    public string[] paragraphs; //an array called paragraphs is created
    int index; //index is created
    public float speedParagraph; //with this you can give a speed to the paragraphs

    public GameObject buttonContinue; //the Gameobject for the continue button is created
    public GameObject buttonQuit; //the Gameobject for the quit button is created

    public GameObject panelDialogue; //the Gameobject for the dialogue panel is created
    public GameObject buttonRead; //the Gameobject for the read button is created



    private void Start()
    {
        //the start is made private and if the remove button and the dialogue panel are false, the panel is deactivated
        buttonQuit.SetActive(false);
        panelDialogue.SetActive(false);

    }


    private void Update()
    {
        //if the text parameter receives the paragraphs the continue button is activated
        if (textD.text == paragraphs[index])
        {

            buttonContinue.SetActive(true);
        }

    }

    IEnumerator TextDialogue()
    {
        //text is given some time so that it is traversed letter by letter
        foreach (char letter in paragraphs[index].ToCharArray())
        {
            textD.text += letter;

            yield return new WaitForSeconds(speedParagraph);
        }
    }



    public void nextParagraph()
    {

        //if there is another paragraph
        buttonContinue.SetActive(false);
        if (index < paragraphs.Length - 1)
        { //the next paragraph variable is created if the continue button no longer detects more paragraphs the coroutine is started
            index++;
            textD.text = "";
            StartCoroutine(TextDialogue());
        }
        else
        { //else if there are no more paragraphs the remove button appears
            textD.text = "";
            buttonContinue.SetActive(false);
            buttonQuit.SetActive(true);
        }
    }

    public void activeButtonRead() //if the read button is activated, the dialogue coroutine starts
    {
        panelDialogue.SetActive(true);
        StartCoroutine(TextDialogue());
    }

    public void ButtonClose() //if the dialogue ends, quit button is activated and de pannel disappear
    {
        panelDialogue.SetActive(false);
        buttonRead.SetActive(false);
    }

}
