using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_LightBar : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip soundClip;

    [SerializeField] Color Blue_Off_Color;
    [SerializeField] Color Blue_On_Color;

    [SerializeField] Color Red_Off_Color;
    [SerializeField] Color Red_On_Color;


    [SerializeField] Light redLight_Obj;
    [SerializeField] Light blueLight_Obj;

    private Vector3 redTemp;
    private Vector3 blueTemp;

    [SerializeField] int speed = 500;


    bool tense_flag = false;

    private void Start()
    {
        audioSource.Stop();
    }


    // Update is called once per frame
    void Update()
    {
        redTemp.y += speed * Time.deltaTime;
        blueTemp.y -= speed * Time.deltaTime;

        redLight_Obj.transform.eulerAngles = redTemp;
        blueLight_Obj.transform.eulerAngles = blueTemp;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("space key pressed");
            tense_flag = !tense_flag;

            set_tense_light(tense_flag);
            handle_sound(tense_flag);
        }
    }

    void set_tense_light(bool tense_flag)
    {
        redLight_Obj.color = tense_flag ? Red_On_Color : Red_Off_Color;
        blueLight_Obj.color = tense_flag ? Blue_On_Color : Blue_Off_Color;

        redLight_Obj.intensity = tense_flag ? 80 : 15;
        blueLight_Obj.intensity = tense_flag ? 80: 15;

        speed = tense_flag ? 750 : 500;

        //Debug.Log("tense_flag: " + tense_flag);
        
        //Debug.Log("redLight_Obj color: " + redLight_Obj.color);
        //Debug.Log("blueLight_Obj color: " + blueLight_Obj.color);
        
        //Debug.Log("redLight_Obj intensity: " + redLight_Obj.intensity);
        //Debug.Log("blueLight_Obj intensity: " + blueLight_Obj.intensity);
    }

    void handle_sound(bool tense_flag)
    {
        if (tense_flag)
        {
            audioSource.clip = soundClip;
            audioSource.loop = true; // repeating
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
