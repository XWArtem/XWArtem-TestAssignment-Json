using UnityEngine;

public class UINavigation : MonoBehaviour
{
    public void AppQuit()
    {
        StopAllCoroutines();
        Application.Quit();
    }
}
