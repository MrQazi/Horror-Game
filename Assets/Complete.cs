using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Complete : MonoBehaviour {
    public Button Next;

    public void Start() {
        ControlFreak2.CFCursor.visible = true;
        ControlFreak2.CFCursor.lockState = CursorLockMode.Confined;
        Next.onClick.AddListener(() => {
            GameManager.instance.Next();
        });
    }
}
