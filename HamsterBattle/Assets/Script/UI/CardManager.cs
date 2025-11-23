using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Spawner playerSpawner;
    public Button[] unitButtons;
    public GameObject[] unitPrefabs;

    void Start()
    {
        // Asignar eventos a los botones
        for (int i = 0; i < unitButtons.Length; i++)
        {
            int index = i;
            unitButtons[i].onClick.AddListener(() => SpawnUnit(index));
        }
    }

    void SpawnUnit(int index)
    {
        playerSpawner.unitPrefab = unitPrefabs[index];
        playerSpawner.SpawnUnit();
    }
}
