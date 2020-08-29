using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class creationmanager : MonoBehaviour
{
   // public GameObject obj1;
    public GameObject camposition,places,inputfield,placesbuttons,pathsbutton,paths,Lineparent,linechild;
    public LineRenderer line;
    public int i = 1;
    public Text markertext;
    public TextMeshProUGUI userinput;
    public CreatorsSceneManager creatorsSceneManager;
    public bool mapon = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startmappping()
    {
        line.SetPosition(0, new Vector3(camposition.transform.position.x, -1f, camposition.transform.position.z) + new Vector3(camposition.transform.forward.x * 2f, 0, camposition.transform.forward.z * 2f));
    }
    public void extendline()
    {
        line.positionCount = i+1;
       
        line.SetPosition(i,new Vector3(camposition.transform.position.x,-1f, camposition.transform.position.z) + new Vector3(camposition.transform.forward.x * 2f, 0, camposition.transform.forward.z * 2f));
        i++;
    }
    public void droppoint(GameObject point)
    {

        
        if(userinput.text!=null)
        {
            GameObject childObject = Instantiate(point, new Vector3(camposition.transform.position.x, -0.2f, camposition.transform.position.z)+new Vector3(camposition.transform.forward.x*2f,0,camposition.transform.forward.z*2f), Quaternion.identity);
            childObject.name = userinput.text;
            creatorsSceneManager.WriteToConsole("Added place_> " + userinput.text);
            creatorsSceneManager.AddPlace(userinput.text);
            if (linechild != null)
            {
                extendline();
                linechild.name += userinput.text;
                creatorsSceneManager.AddPath(linechild.name);
                creatorsSceneManager.WriteToConsole("Added path from " + linechild.name);
               // line.SetPosition(i-1, new Vector3(camposition.transform.position.x, -1, camposition.transform.position.z));
                
            }
            startapath();
            extendline();
            childObject.transform.parent = places.transform;
            childObject.name = userinput.text;
            
            markertext=childObject.GetComponentInChildren<Text>();
            markertext.text = userinput.text;
            inputfield.SetActive(false);
            //pathsbutton.SetActive(true);
            userinput.text =null;

        }
        
    }
    public void startapath()
    {
        i = 0;
        linechild = Instantiate(Lineparent, new Vector3(camposition.transform.position.x, -1f, camposition.transform.position.z) + new Vector3(camposition.transform.forward.x * 2f, 0, camposition.transform.forward.z * 2f), Quaternion.identity);
        linechild.transform.parent = paths.transform;
        line = linechild.GetComponent<LineRenderer>();
        line.SetPosition(0, new Vector3(camposition.transform.position.x, -1, camposition.transform.position.z));
        linechild.name = userinput.text + " to ";
        creatorsSceneManager.WriteToConsole("Creating path from " + userinput.text);
        
    }

    public void mapswitch(GameObject minimap)
    {
        if(mapon==false)
        {
            mapon = true;
            minimap.SetActive(true);
        }
        else
        {
            mapon = false;
            minimap.SetActive(false);
        }
    }
   
    
}
