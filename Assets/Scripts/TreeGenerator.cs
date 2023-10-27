using System.Collections.Generic;
using UnityEngine;


public class TreeGenerator : MonoBehaviour
{
    public GameObject world;
    public GameObject parent;
    public GameObject[] treeTypes = new GameObject[1];
    public int treeCount = 10;
    private List<GameObject> trees = new List<GameObject>();
    public float yOffset = 0.5f;
    
    // Awake is called first, before any other function
    private void Awake()
    {
        CreateTreeCollection();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateTreeCollection()
    {
        for(int i = 0; i < treeCount; i++)
        {
            Vector3 position = Random.onUnitSphere;
            position.Scale(world.transform.localScale / 2);
            Quaternion rotation = world.transform.rotation;

            //randomly pick a tree, will add weighting later
            int randomIndex = Random.Range(0, treeTypes.Length);
            GameObject randomTree = treeTypes[randomIndex];
            GameObject tree = Instantiate(randomTree, position, rotation, parent.transform);
            align(tree);
            trees.Add(tree);
        }
    }

    void align(GameObject tree)
    {
        Transform tr = tree.transform;
        Transform target = world.transform;

        //Calculate new 'up' direction;
        Vector3 _newUpDirection = (tr.position - target.position).normalized;
        //need to move trees by the yOffset
        tree.transform.position -= _newUpDirection * yOffset;

        tr.up = _newUpDirection;
    }
}
