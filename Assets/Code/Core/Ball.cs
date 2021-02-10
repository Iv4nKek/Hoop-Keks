using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Color _color;
    [SerializeField] private float _elasticity;


    [SerializeField] private MeshRenderer _meshRenderer;
    void Start()
    {
        SetupColor();
    }

    private void SetupColor()
    {
        if(_meshRenderer != null)
            _meshRenderer.material.color = _color;
    }
    void Update()
    {
        
    }
}
