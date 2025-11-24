using UnityEngine;
using UnityEngine.UI;

public class Keypad2 : MonoBehaviour
{
    [SerializeField] private Text Ans;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Number(int number)
    {
        Ans.text += number.toString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
