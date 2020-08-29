using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkastraalgo : MonoBehaviour
{
    public int l = 0, k = 0;
    public GameObject[] paths, places;
    public GameObject temp,temp2,sourceplace,tempsourceplace;
    public int[] destinationint= {1,4 };
    
    // Start is called before the first frame update
    void Start()
    {
        places = GameObject.FindGameObjectsWithTag("place");
        paths = GameObject.FindGameObjectsWithTag("path");


        int[,] adjmatrix = {          { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 0,0 , 0, 0, 0, 0, 0, 0, 0 },
                                    { 0,0 , 0, 0, 0, 0, 0, 0, 0 },
                                    { 0,0 , 0, 0, 0, 0, 0, 0, 0 },
                                   { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                      { 0,0 , 0, 0, 0, 0, 0, 0, 0 },
                                    { 0,0 , 0, 0, 0, 0, 0, 0, 0 },
                                    { 0,0 , 0, 0, 0, 0, 0, 0, 0 },
                                     { 0,0 , 0, 0, 0, 0, 0, 0, 0 } };

       foreach(GameObject path1 in places)
        {
            l = 0;
            foreach (GameObject path2 in places)
            {
                
                    if (temp=GameObject.Find(path1.name+" to "+path2.name))
                    {
                        adjmatrix[k, l] = (int)temp.GetComponent<LineRenderer>().bounds.size.magnitude;
                        Debug.Log("wrote "+ (int)temp.GetComponent<LineRenderer>().bounds.size.magnitude + " at" + l + k + " for " + path1 + " to " + path2);
                    }
                    else if(temp = GameObject.Find(path2.name + " to " + path1.name))
                     {
                    adjmatrix[k, l] = (int)temp.GetComponent<LineRenderer>().bounds.size.magnitude;
                    Debug.Log("wrote " + (int)temp.GetComponent<LineRenderer>().bounds.size.magnitude + " at" + l + k + " for " + path2 + " to " + path1);
                     }
                    else
                    {
                    adjmatrix[k, l] = 0;
                    }
                l++;
            }
            k++; 
        }
        dijkstra(adjmatrix, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static readonly int NO_PARENT = -1;


    public void dijkstra(int[,] adjacencyMatrix,
                                        int startVertex)
    {
        int nVertices = adjacencyMatrix.GetLength(0);
        int[] shortestDistances = new int[nVertices];
        bool[] added = new bool[nVertices];
        for (int vertexIndex = 0; vertexIndex < nVertices;
                                            vertexIndex++)
        {
            shortestDistances[vertexIndex] = int.MaxValue;
            added[vertexIndex] = false;
        }
        shortestDistances[startVertex] = 0;
        int[] parents = new int[nVertices];
        parents[startVertex] = NO_PARENT; 
        for (int i = 1; i < nVertices; i++)
        {
            int nearestVertex = -1;
            int shortestDistance = int.MaxValue;
            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                if (!added[vertexIndex] &&
                    shortestDistances[vertexIndex] <
                    shortestDistance)
                {
                    nearestVertex = vertexIndex;
                    shortestDistance = shortestDistances[vertexIndex];
                }
            }
            added[nearestVertex] = true;

            for (int vertexIndex = 0;
                    vertexIndex < nVertices;
                    vertexIndex++)
            {
                int edgeDistance = adjacencyMatrix[nearestVertex, vertexIndex];

                if (edgeDistance > 0
                    && ((shortestDistance + edgeDistance) <
                        shortestDistances[vertexIndex]))
                {
                    parents[vertexIndex] = nearestVertex;
                    shortestDistances[vertexIndex] = shortestDistance +
                                                    edgeDistance;
                }
            }
        }
        
        printSolution(startVertex, shortestDistances, parents);
        
        myfunc(shortestDistances,parents);
    } 
    private static void printSolution(int startVertex,
                                    int[] distances,
                                    int[] parents)
    {
        int nVertices = distances.Length;
        Debug.Log("Vertex\t Distance\tPath");

        for (int vertexIndex = 0;
                vertexIndex < nVertices;
                vertexIndex++)
        {
            if (vertexIndex != startVertex)
            {
                Debug.Log("\n" + startVertex + " -> ");
                Debug.Log(vertexIndex + " \t\t ");
                Debug.Log(distances[vertexIndex] + "\t\t");
              //  printPath(vertexIndex, parents);
            }
        }
    }
    private void printPath(int currentVertex,
                                int[] parents,int lastvertex)
    {

        
        if (currentVertex == NO_PARENT)
        {
            GameObject.Find(places[currentVertex].name+" to "+places[lastvertex].name).SetActive(true);
            Debug.Log("activating "+ places[currentVertex].name + " to " + places[lastvertex].name);
            return;
        }
        printPath(parents[currentVertex], parents,currentVertex);
        if(lastvertex!=999)
        {
            GameObject.Find(places[currentVertex].name + " to " + places[lastvertex].name).SetActive(true);
            Debug.Log("activating " + places[currentVertex].name + " to " + places[lastvertex].name);
        }

    }

    public void myfunc(int[] distances,int[] parents)
    {
        int Pose = 0, minvalue = int.MaxValue;
        Debug.Log("shortest distances are");
        foreach (int dist in distances)
            Debug.Log("go" + dist);
       foreach(int dest in destinationint )
        {
        if(distances[dest]<minvalue)
            {
                minvalue = distances[dest];
                Pose = dest;
            }
          
        }
        Debug.Log("calculated pose " + Pose);
        printPath(0, parents,999);

    }

    
}
