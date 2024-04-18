using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarEtiqueta : MonoBehaviour
{
    private void Start()
    {
        // Asignar la etiqueta "Ground" a todos los hijos del objeto actual
        AsignarEtiquetaHijos(transform);
    }

    private void AsignarEtiquetaHijos(Transform parent)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.tag = "Ground";
            AsignarEtiquetaHijos(child);
        }
    }
}
