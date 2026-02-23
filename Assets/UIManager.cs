using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] LoadUIStrategy initializeStrategy;
    [SerializeField] float UICooldown;
    private List<LoadUIStrategy> que = new List<LoadUIStrategy>();
    
    private float CooldownReq = 0f;

    bool dontAdd = false;
    public void OnRequest(LoadUIStrategy strat)
    {
        if(Time.time < CooldownReq) return;
        if(strat == null) return;


        que[que.Count - 1].UnloadScreen();
        if(dontAdd)
        {
            que.RemoveAt(que.Count - 1);
            que.RemoveAt(que.Count - 1);
        }
        dontAdd = false;
        if(strat.canvas == null)
        {
            Debug.Log("AAAAAAAAAAA");
            dontAdd = true;
        }

        strat.LoadScreen(que[que.Count -2].canvas);


        que.Add(strat);
        Debug.Log(que.Count);
        CooldownReq = Time.time + UICooldown;
        //gameStateManager.UpdateState(currentStrat.importantUIState); 
    }

    private void InitializeMainMenu()
    {
        if(initializeStrategy == null) return;
        initializeStrategy.LoadScreen(null);
        //gameStateManager.UpdateState(initializeStrategy.importantUIState);
        que.Add(initializeStrategy);
        que.Add(initializeStrategy);
    }
    void Start()
    {
        Instance = this;
        //gameStateManager = ServiceHubManage.Instance.gameStateManager;
        InitializeMainMenu();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        
    }
}
