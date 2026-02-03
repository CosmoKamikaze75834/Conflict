using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Handler : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private RaycastLaunch _raycast;
    [SerializeField] private Spawner _spawner;

    private int _minCubs = 2;
    private int _maxCubs = 6;
    private float _maxChance = 100f;
    private float _minChance = 0f;
    private float _explosionForce = 500f;

    public void Start()
    {
        _input.OnMouseClicked += OnScreenClick;
    }

    private void OnScreenClick(Vector2 screenPos)
    {
        if(_raycast.TryGetClickedObject(screenPos, out GameObject hitObgect))
        {
            if(hitObgect.TryGetComponent<Cube>(out Cube cube))
            {
                HandleCubeClick(cube);
            }
        }
    }

    private void HandleCubeClick(Cube cube)
    {
        float random = Random.Range(_minChance, _maxChance);

        if (random <= cube.MaxChance)
        {
            List<Rigidbody> children = new List<Rigidbody>();

            int count = Random.Range(_minCubs, _maxCubs);

            for (int i = 0; i < count; i++)
            {
                GameObject child = _spawner.Spawn(cube.transform.position, cube.transform.localScale, cube.MaxChance);
                children.Add(child.GetComponent<Rigidbody>());
            }

            ExplosionForceApplier.Apply(children, cube.transform.position, _explosionForce);
        }

        Destroy(cube.gameObject);
    }
}