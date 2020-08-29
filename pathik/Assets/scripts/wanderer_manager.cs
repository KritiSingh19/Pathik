using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class wanderer_manager : MonoBehaviour,IDropHandler
{
    
    public GameObject content,contenttransform,button1,maincam,sourceplace;
    private GameObject temp,temp2;
    public GameObject[] places,paths,buttons;
    public string[] destinations2;

    private int i = 0,j=0,h=0;
    public Transform myplace;
    public Transform TEMPtransform;
   
    void Start()
    {
       TEMPtransform = contenttransform.transform;
       
        places = GameObject.FindGameObjectsWithTag("place");
        paths = GameObject.FindGameObjectsWithTag("path");

        initiate();
        
    }

    // Update is called once per frame
    void Update()
    {
       sourceplace=nearestplace();
    }

    public GameObject nearestplace()
    {
        int count = 0;
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
      
        foreach (GameObject go in places)
        {
            Vector3 diff = go.transform.position - maincam.transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                
            }
            count++;
        }
       
        return closest;
    }
    public void initiate()
    {
        j = 0;
        h = 0;
        buttons = GameObject.FindGameObjectsWithTag("button");
        foreach(GameObject button in buttons)
        {
            GameObject.Destroy(button);
        }
        foreach (GameObject respawn in places)
        {

            if (j % 5 == 0)
            {
                h++;
                j = 0;
            }

            temp = Instantiate(button1, new Vector3(146 + j * 260, 960 - h * 200, 0), Quaternion.identity, contenttransform.transform);
            j++;
            temp.GetComponentInChildren<Text>().text = respawn.name;
            temp.name = respawn.name;
            respawn.gameObject.SetActive(false);
        }

        foreach (GameObject path in paths)
        {
            path.gameObject.SetActive(false);
        }
    }
    public void startnavigation()
    { int counter = 0,lowindex=int.MaxValue,highindex=0,currentindex=0;
        foreach (GameObject path in paths)
            path.gameObject.SetActive(false);
        foreach (GameObject place in places)
            place.gameObject.SetActive(false);

        foreach (GameObject place in places)
        {
            if (place == sourceplace)
                currentindex = counter;
           foreach(string desti in destinations2)
            {
                if(desti==place.name)
                {
                    if (counter > highindex)
                        highindex = counter;
                    if (counter < lowindex)
                        lowindex = counter;
                    place.gameObject.SetActive(true);
                }

            }
            counter++;
        }
        if (lowindex > currentindex)
            lowindex = currentindex;
        if (highindex < currentindex)
            highindex = currentindex;
        for (counter=lowindex;counter<=highindex-1;counter++)
        {
            foreach (GameObject path in paths)
            {
                if (path.name == places[counter].name + " to " + places[counter + 1].name)
                    path.SetActive(true);
            }
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invpanel = myplace as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(invpanel, Input.mousePosition))
        {
            Debug.Log(eventData.pointerDrag.name);
            destinations2[i] = eventData.pointerDrag.name;
            eventData.pointerDrag.SetActive(false);
            
            i++;


        }
        
    }
    

}
