using UnityEngine;
using UnityEngine.UI;

public class Keypad1 : MonoBehaviour
{
    public GameObject player;
    public GameObject keypadOB;
    public GameObject door;
    public Animator door_ani;
    public Text textO;
    public string answer = "2626";
    public AudioSource button;
    public AudioSource correct;
    public AudioSource wrong;
    public bool animate = true;

    void Start()
    {
    }

    public void Number(int number)
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

            if (animate)
            {
                door_ani.SetBool("animate", true);
                Debug.Log("DOOR IS OPEN");
            }
        }
        else
        {
            wrong.Play();
            textO.text = "Wrong";
        }
    }

    public void Clear()
    {
        textO.text = "";
        button.Play();
    }

    public void Exit()
    {
        keypadOB.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (keypadOB.activeInHierarchy)
        {
            player.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
