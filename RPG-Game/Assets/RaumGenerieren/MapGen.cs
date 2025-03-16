using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{

    public GameObject StartRoom;
    public void Generate(int count)
    {
        GameObject g = Instantiate(StartRoom);
        g.GetComponent<RoomConnection>().lenth = count;
    }

    void Start()
    {
        Generate(10);//
    }
}

