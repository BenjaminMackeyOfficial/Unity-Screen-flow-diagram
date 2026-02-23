using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ButtonUIManagerPinger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Button button;
    private UIManager uIManager;
    [SerializeField] LoadUIStrategy loadUIStrategyPrefab;
    private LoadUIStrategy loadUIStrategy;
    [SerializeField] KeyCode hotKey;
    
    void Start()
    {

        loadUIStrategy = Instantiate(loadUIStrategyPrefab);
        button = gameObject.GetComponent<Button>();
        uIManager = UIManager.Instance;

        if(button == null) return;
        button.onClick.AddListener(fireOff);
    }
    
    void OnEnable()
    {
        if(button == null) return;
        button.onClick.AddListener(fireOff);
    }
    void OnDisable()
    {
        if(button == null) return;
        button.onClick.RemoveAllListeners();
    }
    
    void Update()
    {
        if(Input.GetKey(hotKey))
        {
            fireOff();
        }
    }
    private void fireOff()
    {
        uIManager.OnRequest(loadUIStrategy);
    }
}
