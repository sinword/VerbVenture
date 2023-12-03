using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitSettingMode : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private GameObject _modalSingle1;
    [SerializeField] private Material _blueMat;
    [SerializeField] private Outline _outline_blue;
    [SerializeField] private GameObject _modalSingle2;
    [SerializeField] private Material _greenMat;
    [SerializeField] private Outline _outline_green;

    // Start is called before the first frame update
    void Start()
    {
        this._exitBtn.onClick.AddListener(delegate {
            this._greenMat.SetColor("_BaseColor", new Color(0.4069019f, 1.0f, 0.2399999f, 0.0f));
            // this._modalSingle1.SetActive(false);

            this._blueMat.SetColor("_BaseColor", new Color(0.2392156f, 0.8572884f, 1.0f, 0.0f));
            // this._modalSingle2.SetActive(false);
            
            this._canvas.enabled = false;
        });
        // this._outline_green.enabled = true;
        // this._outline_blue.enabled = true;
        //   _canvas.enabled = false;
    }

    
    void OnApplicationQuit()
    {
        _greenMat.SetColor("_BaseColor", new Color(0.4069019f, 1.0f, 0.2399999f, 1.0f));
        _blueMat.SetColor("_BaseColor", new Color(0.2392156f, 0.8572884f, 1.0f, 1.0f));
        
    }
}
