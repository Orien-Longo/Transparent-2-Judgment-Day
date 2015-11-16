using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour
{
    public GameObject canvas1, canvas2;
    // Use this for initialization
    void Start()
    {
        //Application.loadedLevel("LichHunt proto3");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0)|| Input.GetKeyDown(KeyCode.Joystick2Button0)|| Input.GetKeyDown(KeyCode.Joystick3Button0))
        {
            Application.LoadLevel("LichHunt proto3");
            //Debug.Log("Pressed left click.");
            Destroy(canvas1);
            Destroy(canvas1);
        }
    }
}
