using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Kontrolle_Ticketnehmen : MonoBehaviour
{
    public Animator animator;
    public string boolname = "Weitergehen";
    private void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(Ticketerhalten);
    }
    public void  Ticketerhalten(GameObject go)
    {
        animator.SetBool(boolname, true);
    }
 
}
