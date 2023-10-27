using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldResourceManager : MonoBehaviour
{
    public GameObject world;
    public GameObject parent;
    public List<ResourceSO> resources;

    public int count;
    // Start is called before the first frame update
    void Start()
    {
        int size = resources.Count;
        for(int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, size);
            ResourceSO template = resources[randomIndex];

            Vector3 position = Random.onUnitSphere;
            position.Scale(world.transform.localScale / 2);
            Quaternion rotation = world.transform.rotation;

            GameObject resource = Instantiate(template.prefab, position, rotation, parent.transform);
            resource.AddComponent<ResourceNodeManager>();
            resource.GetComponent<ResourceNodeManager>().resource = template;
            align(resource);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void align(GameObject resource)
    {
        Transform tr = resource.transform;
        Transform target = world.transform;

        //Calculate new 'up' direction;
        Vector3 _newUpDirection = (tr.position - target.position).normalized;
        //need to move trees by the yOffset
        resource.transform.position -= _newUpDirection * 0.3f;

        tr.up = _newUpDirection;
    }
}
