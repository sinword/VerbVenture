using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineIndicator : MonoBehaviour
{
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Detect hand gesture
        // If the user is pointing with the index finger, show the line
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
            SetLine(transform.position, transform.forward, 10f);
            lineRenderer.enabled = true;
        } else {
            lineRenderer.enabled = false;
        }
    }

    void SetLine(Vector3 targetPos, Vector3 direction, float length) {
        Ray ray = new Ray(targetPos, direction);
        Vector3 endPos = targetPos + (direction * length);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, length)) {
            endPos = raycastHit.point;
            Debug.Log("Hit: " + raycastHit.collider.gameObject.name);
        }

        lineRenderer.SetPosition(0, targetPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
