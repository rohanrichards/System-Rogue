using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouseInput : MonoBehaviour
{
    public GameObject cameraControls;
    public Camera cameraRef;
    public GameObject eyeSensor;
    public GameObject sphereSensor;
    public KeyCode primary = KeyCode.Mouse0;
    public KeyCode secondary = KeyCode.Mouse1;

    private bool isPrimaryDown;
    private GameObject rayTarget;
    private GameObject sphereTarget;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckMouseButtons();
        if (isPrimaryDown)
        {
            CheckForTargets();
        }
    }

    void CheckMouseButtons()
    {
        if (Input.GetKeyDown(primary))
        {
            isPrimaryDown = true;
        } else
        {
            isPrimaryDown = false;
        }
    }

    void CheckForTargets()
    {
        // cast a ray looking for targets
        Transform camTransform = cameraControls.transform;
        Vector3 playerEyes = eyeSensor.transform.position;
        RaycastHit hit;
        List<Collider> filteredSphereHits = new List<Collider>();
        Collider[] sphereHits = Physics.OverlapSphere(sphereSensor.transform.position, sphereSensor.GetComponent<SphereCollider>().radius);

        for(int i = 0; i < sphereHits.Length; i++)
        {
            Collider sphereHit = sphereHits[i];
            //we can only hit things that have a combat script
            //will need to expand this later to include other things
            if(sphereHit.GetComponent<AICombatManager>()) {
                filteredSphereHits.Add(sphereHit);
            }
        }

        if (Physics.Raycast(playerEyes, cameraControls.transform.forward, out hit, 5f))
        {
            Debug.Log("Hit thing: " + hit.collider);
            Debug.DrawRay(playerEyes, camTransform.forward * 3, Color.red, 1f);
            rayTarget = hit.collider.gameObject;
        }

        if (filteredSphereHits.Count > 0)
        {
            sphereTarget = filteredSphereHits[0].gameObject;
            Debug.Log("Sphere target is: " + sphereTarget);
        }
    }

    public GameObject GetRayTarget()
    {
        return rayTarget;
    }

    public void ClearRayTarget()
    {
        rayTarget = null;
    }

    public GameObject GetSphereTarget()
    {
        return sphereTarget;
    }

    public void ClearSphereTarget()
    {
        sphereTarget = null;
    }
}
