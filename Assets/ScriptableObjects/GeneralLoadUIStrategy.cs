using UnityEngine;

[CreateAssetMenu(fileName = "LoadGeneralUIStrategy", menuName = "Scriptable Objects/LoadGeneralUIStrategy")]
public class GeneralUILoadStrategy : LoadUIStrategy // mon specific
{
    //[SerializeField] GameObject canvas;
    private Canvas parentCanvas;

    public override void LoadScreen(GameObject currentCanvas)
    {
        if(parentCanvas == null)
        {
            parentCanvas = UIManager.Instance.transform.GetComponentInChildren<Canvas>();
        }
        if(canvas == null) return;

        newCan = Instantiate(canvas, parentCanvas.transform);

    }
    public override void UnloadScreen()
    {
        if(newCan == null) return;
        Destroy(newCan);
        newCan = null;
    }
}
