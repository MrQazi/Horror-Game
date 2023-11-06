using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_5 : Level {
    public Player player;
    public List<ProxyCollider> points;

    protected override void Start() {
        base.Start();
        EnableNextTrigger();
    }
    
    void EnableNextTrigger() {
        if (points.Count == 0) {
            AllDone();
            return;
        }

        var t = points[0];
        points.RemoveAt(0);
        t.gameObject.SetActive(true);
        t.onTriggerEnter.AddListener(c => {
            EnableNextTrigger();
        });
    }

    private void AllDone() {
        Complete();
    }
    public override void Complete() {
        player.gameObject.SetActive(false);
        base.Complete();
    }
}
