using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private float _multeplier = 0.5f;
    private float _currentChance = 2;

    public GameObject Spawn(Vector3 position, Vector3 parentScale, float parentChance)
    {
        GameObject child = Instantiate(_cubePrefab, position, Quaternion.identity);

        child.transform.localScale = parentScale * _multeplier;

        Cube cubeScript = child.GetComponent<Cube>();
        cubeScript.SetChance(parentChance / _currentChance);

        ColorChange.ApplyRandomColor(child);

        return child;
    }
}