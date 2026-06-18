using System.Runtime.CompilerServices;
using UnityEngine;

public class PlotGenerator : MonoBehaviour
{
    public GameObject point;
    public Renderer point_renderer;
    private float delta_detail = 0.1f;

    public void Start()
    {
        point_renderer = point.GetComponent<Renderer>();

        for (float i = 0; i < 100; i += delta_detail)
        {
            Instantiate(point, new Vector3(i, i, 0), Quaternion.identity);
            Instantiate(point, new Vector3(-i, -i, 0), Quaternion.identity);
            point_renderer.material.color = Color.HSVToRGB(0, 1, 1);
        }

        for (float i = delta_detail; i < 100; i += delta_detail)
        {
            GameObject new_point = Instantiate(point, new Vector3(0, 0, i), Quaternion.identity);
            Renderer new_point_renderer = new_point.GetComponent<Renderer>();
            new_point_renderer.material.color = Color.HSVToRGB(i / 100f, 1, 1);
        }

        for (float i = delta_detail; i < 100; i += delta_detail)
        {
            GameObject new_point = Instantiate(point, new Vector3(i, i, i), Quaternion.identity);
            Renderer new_point_renderer = new_point.GetComponent<Renderer>();
            new_point_renderer.material.color = Color.HSVToRGB(i / 100f, 1, 1);
        }

        for (float i = delta_detail; i < 100; i += delta_detail)
        {
            GameObject new_point = Instantiate(point, new Vector3(-i, -i, -i), Quaternion.identity);
            Renderer new_point_renderer = new_point.GetComponent<Renderer>();
            new_point_renderer.material.color = Color.HSVToRGB(1f - (i / 100f), 1, 1);
        }
    }

}