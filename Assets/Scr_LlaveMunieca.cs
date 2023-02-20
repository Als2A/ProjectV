using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_LlaveMunieca : MonoBehaviour
{

    public Animator llaveAnimator;

    public void ActivarAnimacion()
    {
        llaveAnimator.SetBool("Ready", true);

        var PuzzleMunieca = GetComponentInParent<Scr_PuzzleRanuras_Munieca>();
        PuzzleMunieca.StartAnim = true;
    }
}
