using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onoff : MonoBehaviour
{
    public bool tuner = true;
    public Camera secondcam;
    public Slider slider;
    public GameObject rawimg;
    // Start is called before the first frame update
    public Transform player;

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }

    // Update is called once per frame

    public void zoom()
    {
        secondcam.orthographicSize = slider.value ;
    }
    public void turn()
    {
        if(tuner)
        {
            rawimg.SetActive(true);
            tuner = false;
        }
        else
        {
            rawimg.SetActive(false);
            tuner = true;
        }
    }
}
