using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

public class FunctionGenerator : MonoBehaviour
{
    public GameObject point;
    public float detail = 1f;
    public int num_points = 100;
    public Vector2[] inputs, outputs;

    private void DefineDomain()
    {
        int steps = Convert.ToInt32(num_points * detail);
        int total_points = steps * steps;
        
        inputs = new Vector2[total_points];

        int k = 0;
        for (int i = 0; i < steps; i++)
        {
            for (int j = 0; j < steps; j++)
            {
                inputs[k++] = new Vector2(i, j) * (1 / detail);
            }
        }
    }

    private void DefineRange()
    {
        outputs = new Vector2[inputs.Length];

        for (int i = 0; i < outputs.Length; i++)
        {
            outputs[i].x = inputs[i].x;
            outputs[i].y = inputs[i].y;

            GameObject new_point = Instantiate(point, new Vector3(inputs[i].x, outputs[i].x, inputs[i].y), Quaternion.identity);
            Renderer new_point_renderer = new_point.GetComponent<Renderer>();
            new_point_renderer.material.color = Color.HSVToRGB(outputs[i].y % 100 / 100, 1, 1);
        }
        
    }
    public void Start()
    {
        DefineDomain();
        DefineRange();
    }
}