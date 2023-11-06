using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Level_1 : Level {
    public RCC_AICarController car;
    public RCC_Camera rcccam;
    public Player player;

    public ZombieGirl zombie;

    public PlayableDirector scene;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        rcccam.gameObject.SetActive(true);
        car.onLapEnd.AddListener(() => {
            car.carController.rigid.isKinematic = true;
            car.carController.enabled = false;
            rcccam.gameObject.SetActive(false);
            car.enabled = false;
            scene.gameObject.SetActive(true);
            scene.stopped += (d) => {
                scene.gameObject.SetActive(false);
                player.gameObject.SetActive(true);
                zombie.gameObject.SetActive(true);
                player.transform.LookAt(zombie.transform);
                zombie.onDead.AddListener(Complete);
            };
        });
    }

    public override void Complete() {
        player.gameObject.SetActive(false);
        base.Complete();
    }
}