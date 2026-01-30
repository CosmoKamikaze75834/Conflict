using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _transform;

    private Color _color;
    private int _chanceSplit = 100;

    public void OnMouseUpAsButton()
    {
        int min = 0;
        int max = 100;

        int minCubs = 2;
        int maxCubs = 6;

        int chanceDivider = 2;
        float scale = 0.5f;

        int random = Random.Range(min, max + 1);

        if(random <= _chanceSplit)
        {
            Debug.Log("рандомное число " + random);
            Disappear();

            int count = Random.Range(minCubs, maxCubs + 1);

            for (int i = 0; i < count; i++)
            {
                GameObject clone = Instantiate(_gameObject, _transform.position, _transform.rotation);

                _chanceSplit /= chanceDivider;

                Debug.Log("шанс уменьшился на " + _chanceSplit);

                Renderer rend  = clone.GetComponent<Renderer>();
                _color = Random.ColorHSV();
                rend.material.color = _color;

                clone.transform.localScale = _transform.localScale * scale;
            }
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Куб исчез");
        }
    }

    public void Disappear()
    {
        Destroy(gameObject);
    }
}