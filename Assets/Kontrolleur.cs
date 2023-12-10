using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrolleur : MonoBehaviour
{
    public GameObject player;
    public GameObject check;
    public Ablaufen ablaufenScript; // Verweis auf das Ablaufen-Skript
    public Animator animator;

    private void Update()
    {
        // Berechne die Distanz zwischen dem Kontrolleur und Lisa
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Wenn die Distanz kleiner als 1 Meter ist, setze isDelaying auf true
        if (distanceToPlayer < 1.3f)
        {
            ablaufenScript.isDelaying = true;
            animator.SetTrigger("Warten_Kontrolle");
        }
        else
        {
            // Überprüfe, ob das "Check"-GameObject aktiviert ist
            if (check.activeSelf)
            {
                // Wenn "Check" aktiv ist, setze isDelaying auf false
                ablaufenScript.isDelaying = false;
                animator.SetTrigger("Weitergehen");
            }
        }
    }
}