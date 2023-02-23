using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Demon_Camera : MonoBehaviour
{
    public Scr_Cordura Cordura;

    RaycastHit hit_L;
    RaycastHit hit_M;
    RaycastHit hit_R;

    float Radius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Physics.Raycast(transform.position, transform.forward, out hit

        //Ray ray = new Ray(transform.position, transform.forward * 100f);
        

        if (Physics.Raycast(transform.position, transform.forward, out hit_M)) //codigo guiri Ignora LayerMask
        {
            if (hit_M.transform.CompareTag("Demon"))
            {
                Cordura.RestartTimeScream();

                // -- Animacion --//

                //hit_M.transform.gameObject.SetActive(false);
                hit_M.transform.GetComponentInChildren<Animator>().SetBool("Hide", true);
            }
            
        }

        if (Physics.Raycast(transform.position, transform.forward + (transform.right/2), out hit_R)) //codigo guiri Ignora LayerMask
        {
            if (hit_R.transform.CompareTag("Demon"))
            {
                Cordura.RestartTimeScream();

                hit_R.transform.GetComponentInChildren<Animator>().SetBool("Hide", true);

            }

        }

        if (Physics.Raycast(transform.position, transform.forward + (-transform.right/2), out hit_L)) //codigo guiri Ignora LayerMask
        {
            if (hit_L.transform.CompareTag("Demon"))
            {
                Cordura.RestartTimeScream();

                hit_L.transform.GetComponentInChildren<Animator>().SetBool("Hide", true);

            }

        }
    }

    void OnDrawGizmos()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit_M)) //codigo guiri Ignora LayerMask
        {
            Gizmos.DrawRay(transform.position, transform.forward);

        }

        if (Physics.Raycast(transform.position, transform.forward + (transform.right/2), out hit_R)) //codigo guiri Ignora LayerMask
        {
            Gizmos.DrawRay(transform.position, transform.forward + (transform.right / 2));

        }

        if (Physics.Raycast(transform.position, transform.forward + -(transform.right / 2), out hit_L)) //codigo guiri Ignora LayerMask
        {
            Gizmos.DrawRay(transform.position, transform.forward + -(transform.right / 2));

        }

    }
}
