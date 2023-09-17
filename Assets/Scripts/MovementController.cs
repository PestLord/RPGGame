using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;
    private Camera _camera;
    private Outline _outline;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
        _outline = GetComponent<Outline>();
    }
    
    private void Update()
    {
        // Перемещаем персонажа в направлении _destination.

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                _destination = hit.point;
                _navMeshAgent.SetDestination(_destination);
            }
        }
        // TODO: Получите точку, по которой кликнули мышью и задайте ее вектор в поле _destination.
    }
}