//Creado por : Fernando Alvarez
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PreventRepositionInPlaneGround : MonoBehaviour
{
    public AnchorInputListenerBehaviour inputListener;
    public PlaneFinderBehaviour planeFinder;
    public GameObject mensajePlano;

    private void Awake()
    {
        mensajePlano.SetActive(false);
    }

    //Llamado por el evento OnTargetFound del GroundPlaneStage. 
    //Bloquea la reposicion del objeto. Para activar la jugabilidad.
    public void LockPlaneGround()
    {
        inputListener.enabled = false;
        planeFinder.enabled = false;
        mensajePlano.SetActive(false);
    }

    //Llamado por el evento OnTargetLost del GroundPlaneStage.
    //Posibilidad de activar con un boton para restablecer el reposicionamiento del plano.
    public void unLockPlaneGround()
    {
        inputListener.enabled = true;
        planeFinder.enabled = true;
        mensajePlano.SetActive(true);
    }
}
