using UnityEngine;

[CreateAssetMenu(fileName = "LoadUIStrategy", menuName = "Scriptable Objects/LoadUIStrategy")]
public abstract class LoadUIStrategy : ScriptableObject
{
    public GameObject canvas;
    public GameObject newCan;
    public abstract void LoadScreen(GameObject canvas); //the canvas passes in what the current cavas is at the time of loading... incase anything needs
    public abstract void UnloadScreen();
}
