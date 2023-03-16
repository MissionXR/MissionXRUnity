using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoundButton : MonoBehaviour
{
    [SerializeField] Material normalMaterial;
    [SerializeField] Material pushedMaterial;
    [SerializeField] Material activateMaterial;

    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    MeshRenderer meshRenderer;
    bool activated = false;
    bool willActivate = false;

    private HashSet<Collider> colliders = new HashSet<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
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
        colliders.Add(other);

        meshRenderer.material = pushedMaterial;
        willActivate = !activated;
    }

    private void OnTriggerExit(Collider other)
    {
        colliders.Remove(other);
        if (colliders.Count > 0) {
            return;
        }

        if (willActivate) {
            meshRenderer.material = activateMaterial;
            OnActivate.Invoke();
            activated = true;
        } else {
            meshRenderer.material = normalMaterial;
            OnDeactivate.Invoke();
            activated = false;
        }
    }
}
