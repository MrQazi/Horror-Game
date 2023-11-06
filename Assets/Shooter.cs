using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy {
    public Transform enemy;
    protected override IEnumerator Start() {
        yield return base.Start();
        while (enemy) {
            transform.LookAt(enemy);
            yield return null;
        }
    }
}
