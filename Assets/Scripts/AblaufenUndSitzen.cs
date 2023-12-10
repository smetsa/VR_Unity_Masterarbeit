using System.Collections;
using UnityEngine;

public class AblaufenUndSitzen : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform finalDestination;
    public float movementSpeed = 2.0f;
    public float rotationSpeed = 5.0f;
    public float delayAtWaypoint = 10.0f;
    public float waitTimeAtLastWaypoint = 5.0f;

    private int currentWaypointIndex = 0;
    private Transform targetWaypoint;
    private bool reachedDestination = false;
    private bool isDelaying = false;
    private bool reachedFinalDestination = false;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (waypoints.Length > 0)
        {
            targetWaypoint = waypoints[0];
        }
    }

    private void Update()
    {
        if (!reachedDestination)
        {
            MoveToWaypoint();
        }
        else if (currentWaypointIndex != waypoints.Length - 1 && !isDelaying)
        {
            StartCoroutine(DelayAtWaypoint());
        }
        else if (currentWaypointIndex == waypoints.Length - 1 && !reachedFinalDestination)
        {
            StartCoroutine(WaitAtLastWaypoint());
        }
    }

    private void MoveToWaypoint()
    {
        if (targetWaypoint != null)
        {
            Vector3 targetDirection = targetWaypoint.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);

            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                reachedDestination = true;
                if (currentWaypointIndex < waypoints.Length - 1)
                {
                    currentWaypointIndex++;
                    targetWaypoint = waypoints[currentWaypointIndex];
                }
            }
        }
    }

    private IEnumerator DelayAtWaypoint()
    {
        Debug.Log("Waiting at waypoint " + currentWaypointIndex);
        isDelaying = true;
        yield return new WaitForSeconds(delayAtWaypoint);
        isDelaying = false;

        GoToNextWaypoint();
    }

    private void GoToNextWaypoint()
    {
        reachedDestination = false;

        if (currentWaypointIndex < waypoints.Length)
        {
            targetWaypoint = waypoints[currentWaypointIndex];
        }
    }

    private IEnumerator WaitAtLastWaypoint()
    {
        yield return new WaitForSeconds(waitTimeAtLastWaypoint);

        if (finalDestination != null)
        {
            reachedFinalDestination = true;
            transform.position = finalDestination.position;
            animator.SetBool("hinsetzen", true);
        }
    }
}