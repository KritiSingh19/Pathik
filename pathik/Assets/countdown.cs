using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public float timeStart = 5;
    public GameObject endpanel;

    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        if (timeStart <= 0)
        {
            endpanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}