using System.Collections.Generic;
using UnityEngine;


public class CloudGenerator : MonoBehaviour
{
    public GameObject world;
    public GameObject[] cloudTypes = new GameObject[3];
    public int cloudCount = 10;
    private List<GameObject> clouds = new List<GameObject>();
    public GameObject cloudAnchor;
    public float yOffset = 50f;
    
    // Awake is called first, before any other function
    private void Awake()
    {
        CreateCloudCollection();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cloudAnchor.transform.Rotate(Vector3.up * (Time.deltaTime * 0.6f));
    }

    void CreateCloudCollection()
    {
        for(int i = 0; i < cloudCount; i++)
        {
            Vector3 position = Random.onUnitSphere;
            position.Scale(world.transform.localScale / 2);
            Quaternion rotation = world.transform.rotation;

            //randomly pick a tree, will add weighting later
            int randomIndex = Random.Range(0, cloudTypes.Length);
            GameObject randomTree = cloudTypes[randomIndex];
            GameObject cloud = Instantiate(randomTree, position, rotation, cloudAnchor.transform);
            align(cloud);
            clouds.Add(cloud);
        }
    }

    void align(GameObject cloud)
    {
        Transform tr = cloud.transform;
        Transform target = world.transform;

        //Calculate new 'up' direction;
        Vector3 _newUpDirection = (tr.position - target.position).normalized;
        //need to move trees by the yOffset
        cloud.transform.position -= _newUpDirection * yOffset;

        tr.up = _newUpDirection;
    }
}
