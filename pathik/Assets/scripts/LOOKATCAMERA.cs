using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOOKATCAMERA : MonoBehaviour
{
    public Transform CAMERA;
   
    // Start is called before the first frame update
    void Start()
    {
        CAMERA = Camera.main.transform;  
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(CAMERA);
        this.gameObject.transform.rotation = new Quaternion(0f, this.gameObject.transform.rotation.y, this.gameObject.transform.rotation.z, this.gameObject.transform.rotation.w);
    }
}
