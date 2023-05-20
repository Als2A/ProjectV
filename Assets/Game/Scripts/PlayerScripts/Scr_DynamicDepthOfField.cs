using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Scr_DynamicDepthOfField : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    bool isHit;
    float hitDistance;

    float Radius = 0.3f;

    public Volume Effects;

    DepthOfField depthOfField;

    public Scr_Inventory Inventory;


    // Start is called before the first frame update
    void Start()
    {
        //Effects.profile.TryGetSettings(out depthOfField);

        Effects.sharedProfile.TryGet<DepthOfField>(out depthOfField);
    }

    // Update is called once per frame
    void Update()
    {
        if(Inventory.isSee)
        {
            depthOfField.active = false;
        }
        else
        {
            depthOfField.active = true;

            ray = new Ray(transform.position, transform.forward * 100f);
            isHit = false;

            if (Physics.SphereCast(ray, Radius, out hit, 100f))
            {
                isHit = true;
                hitDistance = Vector3.Distance(transform.position, hit.point);
                
            }


            SetFocus();
        }


    }

    void SetFocus()
    {
        depthOfField.nearFocusStart.value = 0f;
        depthOfField.nearFocusEnd.value = hitDistance - 5f;
        depthOfField.farFocusStart.value = hitDistance + 5f;
        depthOfField.farFocusEnd.value = hitDistance + 25f;

        //depthOfField.focusDistance.value = hitDistance;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if(Physics.SphereCast(ray, Radius, out hit, 100f)) //codigo guiri Ignora LayerMask
        {
            // Draw a yellow sphere at the transform's position

            Gizmos.DrawSphere(hit.point, Radius);

        }

    }
}
