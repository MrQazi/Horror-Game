using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected CapsuleCollider cc;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Animator anim;
    public float Health;
    public Slider healthbar;
    public UnityEvent onDead;

    private void OnValidate() {
        cc ??= GetComponent<CapsuleCollider>();
        agent ??= GetComponent<NavMeshAgent>();
        anim ??= GetComponent<Animator>();
    }

    private void Update() {
        if(anim) anim.SetFloat("Speed", agent.velocity.magnitude / agent.speed);
    }

    protected virtual IEnumerator Start() {
        healthbar.maxValue = Health;
        healthbar.value = Health;
        yield return null;
    }

    void Damage(float value) {
        if (Health <= 0) return;
        Health = Mathf.Clamp(Health-value, 0, 10000.0f);
        healthbar.value = Health;
        if (Health <= 0) {
            Health = -1;
            onDead.Invoke();
            Destroy(gameObject);
        }
    }
}
