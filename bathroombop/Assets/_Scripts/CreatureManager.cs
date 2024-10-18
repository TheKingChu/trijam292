using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    public GameObject rubberDuckPrefab;
    public GameObject soapBarPrefab;
    public GameObject shampooPrefab;

    public List<Transform> holes;
    private List<GameObject> activeCreatures = new List<GameObject>();

    public float spawnInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnCreature), 1f, spawnInterval);
    }

    private void SpawnCreature()
    {
        int randomIndex = Random.Range(0, holes.Count);
        Transform selectedHole = holes[randomIndex];

        GameObject creaturePrefab = ChooseRandomCreature();
        GameObject newCreature = Instantiate(creaturePrefab, selectedHole.position, Quaternion.identity);
        activeCreatures.Add(newCreature);

        CreatureBase creatureScript = newCreature.GetComponent<CreatureBase>();
        AssignKeyToCreature(creatureScript, randomIndex);
    }

    private GameObject ChooseRandomCreature()
    {
        int randomChoice = Random.Range(0, 3);
        switch (randomChoice)
        {
            case 0: return rubberDuckPrefab;
            case 1: return soapBarPrefab;
            case 2: return shampooPrefab;
            default: return rubberDuckPrefab;
        }
    }

    private void AssignKeyToCreature(CreatureBase creature, int holeIndex)
    {
        switch (holeIndex)
        {
            case 0: creature.assignedKey = KeyCode.W; break;
            case 1: creature.assignedKey = KeyCode.A; break;
            case 2: creature.assignedKey = KeyCode.S; break;
            case 3: creature.assignedKey = KeyCode.D; break;
            case 4: creature.assignedKey = KeyCode.O; break;
            case 5: creature.assignedKey = KeyCode.P; break;
            default: creature.assignedKey = KeyCode.None; break;
        }
    }
}
