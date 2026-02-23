using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LoadReturnUIStrategy", menuName = "Scriptable Objects/LoadReturnUIStrategy")]
public class ReturnUILoadStrategy : LoadUIStrategy // mon specific
{
    private Canvas parentCanvas;

    public override void LoadScreen(GameObject currentCanvas)
    {
        canvas = currentCanvas;
        if(parentCanvas == null)
        {
            parentCanvas = UIManager.Instance.transform.GetComponentInChildren<Canvas>();
        }
        if(currentCanvas == null) return;
        
        newCan = Instantiate(currentCanvas, parentCanvas.transform);
        
    }
    public override void UnloadScreen()
    {
        if(newCan == null) return;
        Destroy(newCan);
        newCan = null;
    }
}
