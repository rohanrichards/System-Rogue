using System.Collections.Generic;
using UnityEngine;
public class RockGenerator : MonoBehaviour
{
    public GameObject world;
    public GameObject parent;
    public GameObject[] rockTypes = new GameObject[1];
    public int rockCount = 10;
    private List<GameObject> rocks = new List<GameObject>();
    public float yOffset = 0.5f;

    // Awake is called first, before any other function
    private void Awake()
    {
        CreateRockCollection();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateRockCollection()
    {
        for(int i = 0; i < rockCount; i++)
        {
            Vector3 position = Random.onUnitSphere;
            position.Scale(world.transform.localScale / 2);
            Quaternion rotation = world.transform.rotation;

            int randomIndex = Random.Range(0, rockTypes.Length);
            GameObject randomRock = rockTypes[randomIndex];
            GameObject rock = Instantiate(randomRock, position, rotation, parent.transform);
            align(rock);
            rocks.Add(rock);
        }
    }

    void align(GameObject rock)
    {
        Transform tr = rock.transform;
        Transform target = world.transform;

        //Calculate new 'up' direction;
        Vector3 _newUpDirection = (tr.position - target.position).normalized;
        //need to move rocks by the yOffset
        rock.transform.position -= _newUpDirection * yOffset;

        tr.up = _newUpDirection;
    }
}
