using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject _fire;
    private Rigidbody[] _rigidbodies;
    private NavMeshObstacle _navMeshObstacle;
    private Collider _collider;
    
    private float _minForceValue = 150;
    private float _maxForceValue = 200;

    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Outline>().OutlineWidth == 0)
            {
                Break();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _fire.SetActive(true);
        }
    }

    public void Break()
    {
        // Вырезаем отверстие в навмеш (чтобы игрок там больше не смог пройти)
        _navMeshObstacle.enabled = true;
        
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;

            // Генерируем случайную силу.
            var forceValue = Random.Range(_minForceValue, _maxForceValue);

            // Генерируем случайное направление.
            var direction = Random.insideUnitSphere;
            
            // Придаем силу каждому rigidbody.
            rigidbody.AddForce(direction * forceValue);
        }
    }
}