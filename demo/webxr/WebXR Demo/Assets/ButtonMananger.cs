using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<RoundButton> buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() 
    {
        buttons.ForEach(button => {
            button.OnActivate.AddListener(ButtonActivate);
        });
    }
    
    private void OnDisable() 
    {
        buttons.ForEach(button => {
            button.OnActivate.RemoveListener(ButtonActivate);
        });
    }

    private void ButtonActivate()
    {
        Debug.Log("Button Collide!!!");
    }
}
