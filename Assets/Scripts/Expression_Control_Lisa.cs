using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expression_Control_Lisa : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        // Dynamische Initialisierung der Animator-Komponente
        anim = GetComponent<Animator>();

        // Rufe die ChangeExpression-Funktion alle 10 Sekunden auf und wiederhole es alle 10 Sekunden
        InvokeRepeating("ChangeExpression", 0f, 10f);
    }

    private void ChangeExpression()
    {
        // Zufällig eine der vier Expressionen auswählen
        int randomExpression = Random.Range(0, 4);

        switch (randomExpression)
        {
            case 0:
                SetExpression("Sad");
                break;
            case 1:
                SetExpression("Extra Sad");
                break;
            case 2:
                SetExpression("Angry");
                break;
            case 3:
                SetExpression("Default");
                break;
        }
    }

    private void SetExpression(string expressionName)
    {
        Debug.Log("Animation " + expressionName);
        anim.Play("Facial Expression_" + expressionName);
    }
}