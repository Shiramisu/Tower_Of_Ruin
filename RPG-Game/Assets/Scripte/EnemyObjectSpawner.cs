using UnityEngine;

public class EnemyObjectSpawner : MonoBehaviour
{
    [Header("Spawn Einstellungen")]
    // Das Prefab, das instanziiert werden soll
    [SerializeField] private GameObject objectToSpawn;
    // Anzahl der zu erstellenden Objekte
    [SerializeField] private int numberOfObjects = 3;
    // Optionaler Versatz relativ zur Position des Enemys
    [SerializeField] private Vector3 spawnOffset = Vector3.zero;

    // Falls du eine zufällige Streuung wünschst, kann dieser Faktor genutzt werden
    [SerializeField] private float randomRadius = 1f;

    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        if (objectToSpawn == null)
        {
            Debug.LogWarning("Kein Objekt zum Spawnen zugewiesen!");
            return;
        }

        for (int i = 0; i < numberOfObjects; i++)
        {
            // Berechne die Spawnposition relativ zum Enemy
            Vector3 randomOffset = Random.insideUnitSphere * randomRadius;
            randomOffset.y = 0f; // Option: nur horizontal versetzt
            Vector3 spawnPosition = transform.position + spawnOffset + randomOffset;

            // Instanziiere das Objekt und setze es als Kind des Enemy
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            spawnedObject.transform.parent = transform;
        }
    }
}
