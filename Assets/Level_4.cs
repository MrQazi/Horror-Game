using System;
using UnityEngine;
using UnityEngine.Playables;

public class Level_4 : Level {
    [Serializable]
    public struct VehicleSet {
        public RCC_CarControllerV3 car;
        public RCC_Camera cam;
        public ProxyCollider dest;

        public void Active(Action action) {
            car.gameObject.SetActive(action != null);
            cam.gameObject.SetActive(action != null);
            if(action!=null) RCC_SceneManager.Instance.RegisterPlayer(car);
            dest.onTriggerEnter.AddListener(c => action?.Invoke());
        }
    }

    public VehicleSet highwayvehicle,hospitalvehicle;
    public PlayableDirector call;
    public PlayableDirector room;
    public GameObject Highway;
    public GameObject Hospital;
    protected override void Start() {
        base.Start();
        call.stopped += d => {
            call.gameObject.SetActive(false);
            highwayvehicle.Active(() => {
                highwayvehicle.Active(null);
                Highway.SetActive(false);
                Hospital.SetActive(true);
                hospitalvehicle.Active(() => {
                    hospitalvehicle.Active(null);
                    room.gameObject.SetActive(true);
                    room.stopped += d => {
                        room.gameObject.SetActive(false);
                        Complete();
                    };
                });
            });
        };
    }
}
