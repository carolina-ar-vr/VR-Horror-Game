using UnityEngine;
using System.collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //text element
using UnityStandardAssets.Character.FirstPerson;

public class Keypad : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject hud;
    public GameObject inv; //inventory

    public GameObject door; //door
    public Animator door_ani;

    public Text textO;
    public string answer = "2626";

    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;

    public bool animate;

    void Start()
    {

    }

    public void Number(int number) //when we press one of our buttons the text object to equal the number to string
    {
        textO.text += number.ToString();
        button.Play();
    }

    public void Execute()
    {
        if (textO.text == answer)
        {
            correct.Play();
            textO.text = "Right";
        }
        else
        {
            wrong.Play();
            textO.text = "Wrong";
        }
    }

    public void Clear() //clears textbox
    {
        textO.text = "";
        button.Play();
    }

    public void Exit()
    {
        keypadOB.SetActive(false); //goes away
        inv.SetActive(true); //inv is true
        hud.SetActive(true); //hud is true
        player.GetComponent<FirstPersonController>().enabled = true; //player script -> true
    }

    public void Update()
    {
        if (textO.text == "Right" && animate)
        {
            door_ani.SetBool("animate", true);
            Debug.Log("DOOR IS OPEN");
        }

        if (keypadOB.activeInHierarchy)
        {
            hud.SetActive(false); //nothing
            inv.SetActive(false); //nothing
            player.GetComponent<FirstPersonController>().enabled = false; //nothing
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
