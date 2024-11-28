using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Lights_ : MonoBehaviour
{
    // car front lights
    public Renderer headlight_r_1;
    public Renderer headlight_l_1;

    // car back lights (Break lights)
    public Renderer taillight_l_1;
    public Renderer taillight_r_1;

    // light objects
    public GameObject Back_Left_Light;
    public GameObject Back_Right_Light;
    public GameObject Front_Left_Light;
    public GameObject Front_Right_Light;

    // front lights => yellow
    public Material Front_TurnOFFLight;
    public Material Front_TurnOnLight;

    // back lights => red
    public Material Break_TurnOFFLight;
    public Material Break_TurnOnLight;


    bool front_light_flag = false;
    bool break_light_flag = false;

    void Start()
    {
        Back_Left_Light.SetActive(false);
        Back_Right_Light.SetActive(false);
        Front_Left_Light.SetActive(false);
        Front_Right_Light.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // whenever the G key pressed, change the situation of front lights (the front_light_flag)
        if (Input.GetKeyDown(KeyCode.G))
        {
            front_light_flag = !front_light_flag;
            set_front_lights(front_light_flag);
        }

        // whenever the H key pressed, change the situation of break lights (the break_light_flag)
        if (Input.GetKeyDown(KeyCode.H))
        {
            break_light_flag = !break_light_flag;
            set_break_lights(break_light_flag);
        }
    }

    void set_front_lights(bool front_flag)
    {
        headlight_r_1.material = front_flag ? Front_TurnOnLight : Front_TurnOFFLight;
        headlight_l_1.material = front_flag ? Front_TurnOnLight : Front_TurnOFFLight;


        // changing the situation of light objects
        Front_Left_Light.SetActive(front_flag);
        Front_Right_Light.SetActive(front_flag);

        // debugging
        Debug.Log("Lights Active: " + front_flag);
        Debug.Log("Front_Left_Light Active: " + Front_Left_Light.activeSelf);
        Debug.Log("Front_Right_Light Active: " + Front_Right_Light.activeSelf);
    }

    void set_break_lights(bool break_flag)
    {
        taillight_l_1.material = break_flag ? Break_TurnOnLight : Break_TurnOFFLight;
        taillight_r_1.material = break_flag ? Break_TurnOnLight : Break_TurnOFFLight;

        Back_Left_Light.SetActive(break_flag);
        Back_Right_Light.SetActive(break_flag);

        Debug.Log("Lights Active: " + break_flag);
        Debug.Log("Back_Left_Light Active: " + Back_Left_Light.activeSelf);
        Debug.Log("Back_Right_Light Active: " + Back_Right_Light.activeSelf);

    }
}
