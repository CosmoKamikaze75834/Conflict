using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private Cube _cubeScript;
    private float _maxChance = 100;
    private float _minChance = 0;
    private float _currentchance;
    private float _multeplier = 0.5f;

    private int _minCubs = 2;
    private int _maxCubs = 6;

    private void Start()
    {
        _currentchance = _maxChance;
    }

    private void Update()
    {
        OnCubeClick();
    }

    private void OnCubeClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject cube = hit.collider.gameObject;

                _cubeScript = cube.GetComponent<Cube>();

                if (_cubeScript == null)
                    return;

                Spawn(cube);
            }          
        }
    }

    private void Spawn(GameObject cube)
    {
        float random = Random.Range(_minChance, _maxChance);

        if (random <= _currentchance)
        {
            _currentchance *= _multeplier;

            int count = Random.Range(_minCubs, _maxCubs);

            for (int i = 0; i < count; i++)
            {
                GameObject clone = Instantiate(_cubePrefab, cube.transform.position, cube.transform.rotation);

                Color randColor = Random.ColorHSV();
                clone.GetComponent<Renderer>().material.color = randColor;

                clone.transform.localScale = cube.transform.localScale * _multeplier;
            }
        }

        _cubeScript.Disappear();
    }
}