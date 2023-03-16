using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoundButton : MonoBehaviour
{
    [SerializeField] Material normalMaterial;
    [SerializeField] Material pushedMaterial;
    [SerializeField] Material activateMaterial;
    [SerializeField] MeshRenderer mesh;

    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (OnActivate == null) {
            OnActivate = new UnityEvent();
        }        
        if (OnDeactivate == null) {
            OnDeactivate = new UnityEvent();
        }       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        mesh.material = pushedMaterial;
    }

    private void OnTriggerExit()
    {
        if (!activated) {
            OnActivate.Invoke();
            mesh.material = activateMaterial;
            activated = true;
        } else {
            OnDeactivate.Invoke();
            mesh.material = normalMaterial;
            activated = false;
        }
    }
}
