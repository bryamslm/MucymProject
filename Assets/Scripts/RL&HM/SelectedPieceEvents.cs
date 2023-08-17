using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedPieceEvents : MonoBehaviour
{

    public Renderer renderer;
    public Material originalMaterial;
    public Material selectedMaterial;

    public void ChangeToSelecteMaterial()
    {
        renderer.material = selectedMaterial;
    }

    public void ChangeToUnelectedMaterial()
    {
        renderer.material = originalMaterial;
    }
}
