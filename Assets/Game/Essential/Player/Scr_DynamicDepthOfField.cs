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

            if (Physics.SphereCast(ray, 0.3f, out hit, 100f))
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
        depthOfField.nearFocusEnd.value = hitDistance - 2f;
        depthOfField.farFocusStart.value = hitDistance + 2f;
        depthOfField.farFocusEnd.value = hitDistance + 10f;

        //depthOfField.focusDistance.value = hitDistance;
    }
}
