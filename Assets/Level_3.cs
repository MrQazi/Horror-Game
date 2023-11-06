using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

public class Level_3 : Level {
    public PlayableDirector scene;
    public PlayableDirector final;
    public Player player;
    public List<Shooter> shooters;
    public Shooter cop;

    protected override void Start() {
        base.Start();
        scene.stopped += (d) => {
            scene.gameObject.SetActive(false);
            player.gameObject.SetActive(true);
            shooters.ForEach(s=>s.gameObject.SetActive(true));
            cop.gameObject.SetActive(true);
        };
    }

    private void Update() {
        if(shooters.Count == 0)return;
        shooters = shooters.Where(s => s).ToList();
        if (shooters.Count == 0) {
            player.gameObject.SetActive(false);
            final.gameObject.SetActive(true);
            final.stopped += d => {
                Complete();
            };
        }
    }
}
