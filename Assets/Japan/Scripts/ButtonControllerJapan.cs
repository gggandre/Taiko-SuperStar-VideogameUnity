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

//This code is used to manage the mouse's behavior.
public class ButtonControllerJapan : MonoBehaviour
{
    //First we declare all the components and variables that we will use in the code

    private Animator animator;


    private SpriteRenderer theSprite;

    public int thisButtonNumber;

    private GameManagerJapan theGM;

    private AudioSource theSound;

    // Start is called before the first frame update
    void Start()
    {
        //When the game starts all our references get or find the components of the GameObject.  Like the sound, the animation, the game manager and the view of the component
        theSprite = GetComponent<SpriteRenderer>();
        theGM = FindObjectOfType<GameManagerJapan>();
        theSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void OnMouseDown() //This function knows when the player presses the click of the mouse
    {
        //When the player presses the click, the instrument(GameObject) increases the hue of its colors, then plays its sound and finally make the animation.
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 1f);
        theSound.Play();
        animator.SetBool("Enter", true);
    }

    private void OnMouseUp()//This function knows when the player releases the click of the mouse
    {
        //When the player releases the click, the instrument (GameObject) decreases the hue of its colors, then sends the variable "thisButtonNumber" to the game manager, 
        //then the instrument stops the sound and stops the animation.
        theSprite.color = new Color(theSprite.color.r, theSprite.color.g, theSprite.color.b, 0.7f);
        theGM.ColorPressed(thisButtonNumber);
        theSound.Stop();
        animator.SetBool("Enter", false);
    }
}
