using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class Level_2 : Level {
    public PlayableDirector scene;

    public Player player;
    public RCC_Camera rccam;

    public RCC_CarControllerV3 car;

    public ProxyCollider col;
    public ProxyCollider cover;

    public List<ProxyCollider> triggers;
    public List<GameObject> hurdles;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        scene.stopped += (d) => {
            scene.gameObject.SetActive(false);
            car.gameObject.SetActive(true);
            rccam.gameObject.SetActive(true);
            RCC_SceneManager.Instance.RegisterPlayer(car);
            col.onTriggerEnter.AddListener(c => {
                car.rigid.isKinematic = true;
                car.enabled = false;
                rccam.gameObject.SetActive(false);
                player.gameObject.SetActive(true);
                EnableNextTrigger();
            });
            col.gameObject.SetActive(true);
        };
    }

    void EnableNextTrigger() {
        if (triggers.Count == 0) {
            AllDone();
            return;
        }

        var t = triggers[0];
        triggers.RemoveAt(0);
        t.gameObject.SetActive(true);
        t.onTriggerEnter.AddListener(c => {
            hurdles[0].SetActive(true);
            hurdles.RemoveAt(0);
            EnableNextTrigger();
        });
    }

    void AllDone() {
        cover.gameObject.SetActive(true);
        cover.onTriggerEnter.AddListener((c)=>Complete());
    }
    public override void Complete() {
        player.gameObject.SetActive(false);
        base.Complete();
    }
}
