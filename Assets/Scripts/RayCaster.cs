    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;

/// <summary>
/// Cast ray from index finger to interact with Alphabat Generators
/// </summary>
public class RayCaster : MonoBehaviour
{
    [Tooltip("The layermask to check for collisions.")]
    [SerializeField]
    LayerMask interactionLayerMask;
    [Tooltip("The max distance the ray should check for collisions.")]
    [SerializeField]
    float maxDistance = 50f;
    [Tooltip("Whether use the line renderer to show the ray.")]
    [SerializeField]
    // bool useVisibleRay = true;
    // [Tooltip("The time in seconds that the ray must be hitting the AlphabetGenerator before interaction begins.")]
    // [SerializeField]
    // float interactionDelay = 1f;
    #region LineRenderer
    LineRenderer lineRenderer;
    Color hitStart = new Color(0.3254717f, 1f, 0.7896893f);
    Color end = new Color(0.2311321f, 0.6582434f, 1f);
    Color nohitStart = new Color(1f, 0.4323243f, 0.3254902f);
    #endregion
    bool _isHitting = false;
    // float hitTime = 0f;
    Outline _outline;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        gameObject.SetActive(true);
    }

    void OnDisable()
    {
        ResetInteraction();
    }

    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, maxDistance, interactionLayerMask))
        {      
            if(!_isHitting)
            {
                _isHitting = true;
            }
            Debug.Log(hitInfo.transform.name);
            if(hitInfo.transform.GetComponentInChildren<Outline>())
            {
                _outline = hitInfo.transform.GetComponentInChildren<Outline>();
                _outline.enabled = true;
            }

            lineRenderer.enabled = true;
            lineRenderer.startColor = hitStart;

            lineRenderer.SetPosition(1, hitInfo.point);
            //lineRenderer.SetPosition(1, transform.InverseTransformPoint(hitInfo.point));
        }
        else
        {
            if(_isHitting)
            {
                _isHitting = false;

                ResetInteraction();
            }
            lineRenderer.enabled = true;
            lineRenderer.startColor = nohitStart;
            Vector3 rayEndPoint = transform.position + transform.TransformDirection(Vector3.forward) * maxDistance;
            lineRenderer.SetPosition(1, rayEndPoint);
            //lineRenderer.SetPosition(1, Vector3.forward * maxDistance);
        }
    }

    void ResetInteraction()
    {
        // if (currentGenerator != null) currentGenerator.CloseHighlight();
        // currentGenerator = null;
        // hitTime = 0f;
        // isHitting = false;

        if(this._outline != null)
        {
            this._outline.enabled = false;
            this._outline = null;
        }
        
    }
}
