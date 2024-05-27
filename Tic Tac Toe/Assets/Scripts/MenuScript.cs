using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public TMPro.TMP_InputField p1;
    public TMPro.TMP_InputField p2;

    public static string p1Name;
    public static string p2Name;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        if(Input.GetMouseButtonDown(0) && mouse.y < 285 && mouse.x > 360 && mouse.x < 1080)
        {
            if (p1.text == "")
                p1Name = "Player1";
            else
                p1Name = p1.text;
            if (p2.text == "")
                p2Name = "Player2";
            else
                p2Name = p2.text;
            SceneManager.LoadScene("Game");
        }
    }
}
