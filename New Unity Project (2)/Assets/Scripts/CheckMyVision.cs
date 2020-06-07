using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMyVision : MonoBehaviour
{
    // Start is called before the first frame update
    public enum enmSensitivity { HIGH, LOW }

    public enmSensitivity sensitivity = enmSensitivity.HIGH;
    public bool targetInSight = false;
    public float fieldofvision = 45f;
    private Transform target = null;
    public Transform myEyes = null;
    public Transform npcTransform = null;
    private SphereCollider sphareCollider = null;
    public Vector3 lastKnownSighting = Vector3.zero;

    private void Awake()
    {

        npcTransform = GetComponent<Transform>();
        sphareCollider = GetComponent<SphereCollider>();
        lastKnownSighting = npcTransform.position;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    bool InMyFieldofVision()
    {
        Vector3 dirtoTarget = target.position - myEyes.position;
        float angle = Vector3.Angle(myEyes.forward, dirtoTarget);
        if (angle <= fieldofvision)
        {
            return true;
        }
        else
            return false;

    }

    bool ClearLineofsight()
    {
        RaycastHit hit;
        if(Physics.Raycast(myEyes.position, (target.position-myEyes.position).normalized,
            out hit, sphareCollider.radius))
        {
            if (hit.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    void UpdateSight()
    {
        switch (sensitivity)
        {
            case enmSensitivity.HIGH:
                targetInSight = InMyFieldofVision() && ClearLineofsight();
                break;
            case enmSensitivity.LOW:
                targetInSight = InMyFieldofVision() || ClearLineofsight();

                break;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        UpdateSight();
        if (targetInSight)
            lastKnownSighting = target.position;
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        targetInSight = false;
    }
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
