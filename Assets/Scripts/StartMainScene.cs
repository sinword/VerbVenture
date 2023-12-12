using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMainScene : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _startBtn;
    [SerializeField] private Text _notificationText;
    void Start()
    {
        this._startBtn.onClick.AddListener(delegate {
            this._canvas.enabled = false;
            Debug.Log("StartMainScene StartBtn Clicked, MainScene starts");
        });
    }
    void Update()
    {
        
    }
}
