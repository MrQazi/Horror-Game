using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour {
    public GameObject env;
    protected virtual void Start() {
        env.SetActive(true);
    }

    public virtual void Complete() {
        gameObject.SetActive(false);
        GameManager.instance.LevelComplete();
    }
}
