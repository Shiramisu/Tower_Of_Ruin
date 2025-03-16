using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class RoomConnection : MonoBehaviour
{
    public int lenth = 0;
    public List<GameObject> nextRoom = new List<GameObject>();
    public List<Transform> SpwanList = new List<Transform>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if (lenth > 0 && nextRoom.Count > 0)
        {
            foreach (Transform trans in SpwanList)
            {
                GameObject g = Instantiate(nextRoom[Random.Range(0, nextRoom.Count)], trans.position, trans.rotation);
                g.GetComponent<RoomConnection>().lenth = lenth - 1;
            }
            
        }
        //Destroy(gameObject);

        // Baue den NavMesh zur Laufzeit
        if (navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh();
            //Debug.Log("NavMesh wurde zur Laufzeit gebaked.");
        }
    }

    private NavMeshSurface navMeshSurface;

    void Awake()
    {
        // Hole die NavMeshSurface-Komponente vom gleichen GameObject
        navMeshSurface = GetComponent<NavMeshSurface>();
        if (navMeshSurface == null)
        {
            //Debug.LogError("Kein NavMeshSurface gefunden!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward);
        foreach (Transform item in SpwanList)
        {
            if (item != null)
            {
                Gizmos.DrawRay(item.position, item.forward);
            }
        }
    }
}