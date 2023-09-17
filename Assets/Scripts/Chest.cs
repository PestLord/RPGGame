using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator _animator;
    private BoxCollider _collider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Open();
        }
    }

    public void Open()
    {
        _animator.SetTrigger("open");
    }
}