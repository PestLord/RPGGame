using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public bool HasProtectedPotion => _hasProtectionPotion;
    
    [SerializeField] 
    private float highlightIntensity = 2;
    
    private Outline _outline;
    private bool _hasProtectionPotion;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    public void TakePotion()
    {
        _hasProtectionPotion = true;
        _outline.OutlineWidth = highlightIntensity;
    }
    
}
