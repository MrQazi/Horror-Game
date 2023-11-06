using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class ZombieGirl : Enemy {
    protected override IEnumerator Start() {
        yield return base.Start();
        
        while (Player.Inst && agent) {
            if (Vector3.Distance(transform.position, Player.Inst.transform.position) <
                agent.stoppingDistance * 1.5f) {
                transform.LookAt(Player.Inst.transform);
                anim.Play("Attack");
                yield return new WaitForSeconds(2.5f);
            }

            agent.SetDestination(Player.Inst.transform.position);
            yield return null;
        }
    }
}
