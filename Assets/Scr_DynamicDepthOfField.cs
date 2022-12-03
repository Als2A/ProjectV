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


    // Start is called before the first frame update
    void Start()
    {
        //Effects.profile.TryGetSettings(out depthOfField);

        Effects.sharedProfile.TryGet<DepthOfField>(out depthOfField);
    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward * 100f);
        isHit = false;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            isHit = true;
            hitDistance = Vector3.Distance(transform.position, hit.point);
            Debug.Log("Hit");
        }


        SetFocus();

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
