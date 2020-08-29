using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Map/Map Object")]
public class MapScriptableObjec : ScriptableObject
{

    public List<GameObject> paths = new List<GameObject>();
    public List<GameObject> places = new List<GameObject>();

    public void LoadData()
    {
        //loads data from a save manager which gets data from xml file
    }

    public void SaveData()
    {
        //saves data from the scene of the map
    }
}
