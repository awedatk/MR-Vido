using UnityEngine;
using Meta.XR;

public class SceneCollisionDebug : MonoBehaviour
{
    public OVRInput.Button button = OVRInput.Button.One;

    public Transform rayStartPoint;
    public float rayLength = 5f;
    public EnvironmentRaycastManager envRayManager;
    public TMPro.TextMeshPro debugTextPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(button))
        {
            Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);
       
            bool hasHit = envRayManager.Raycast(ray, out var hit, rayLength);

            if (hasHit)
            {
                TMPro.TextMeshPro debugText = Instantiate(debugTextPrefab);

                Vector3 hitpoint = hit.point;
                Vector3 hitNormal = hit.normal;
                
                debugText.transform.position = hitpoint;
                debugText.transform.rotation = Quaternion.LookRotation(-hitNormal);

                debugText.text = "ENV HIT";
            }
        }

        
    }
}
