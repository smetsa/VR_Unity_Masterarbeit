using UnityEngine;

public class Lisa_NPC : MonoBehaviour
{
    public Transform ericKontrolleur; // Der Transform des Eric-Kontrolleur-Objekts
    public float distanceThreshold = 0.5f; // Der Abstandsschwellenwert

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (ericKontrolleur != null)
        {
            float distance = Vector3.Distance(transform.position, ericKontrolleur.position);

            if (distance <= distanceThreshold)
            {
                animator.SetBool("Kontrolleur", true);
            }
            else
            {
                animator.SetBool("Kontrolleur", false);
            }
        }
    }
}
