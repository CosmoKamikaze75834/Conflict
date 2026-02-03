using UnityEngine;

public static class ColorChange
{
    public static void ApplyRandomColor(GameObject gameObject)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();

        if(renderer != null)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
}