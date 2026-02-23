using UnityEngine;

[CreateAssetMenu(fileName = "CloseUIStrategy", menuName = "Scriptable Objects/CloseUIStrategy")]
public class CloseGameUILoadStrategy : LoadUIStrategy // mon specific
{
    public override void LoadScreen(GameObject currentCanvas)
    {
        Application.Quit();
    }
    public override void UnloadScreen()
    {

    }
}
