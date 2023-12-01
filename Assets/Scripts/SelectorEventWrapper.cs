using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectorEventWrapper : MonoBehaviour
{
    public UnityEvent OnSelected;
    // Start is called before the first frame update
    void Start()
    {
        AddSelectionListener();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddSelectionListener() {
        if (OnSelected == null) {
            OnSelected = new UnityEvent();
        }

        OnSelected.AddListener(OnSelectedHandler);
    }

    public void OnSelectedHandler() {
        Debug.Log("Selected");
    }
}
