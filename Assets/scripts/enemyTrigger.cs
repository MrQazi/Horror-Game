using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError(other.gameObject.layer);
        if (other.gameObject.layer == 6)
        {
            if (other.GetComponent<NavMeshAgent>())
            {
                Debug.LogError("failed : " + other.name);
                other.GetComponent<NavMeshAgent>().isStopped = true;
                other.GetComponent<followPlayer>().enabled = false;
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}
