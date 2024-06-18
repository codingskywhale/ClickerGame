using UnityEngine;

public class AutoClick : MonoBehaviour
{
    public ClickManager clickManager;

    private void Update()
    {
        if (clickManager == null)
        {
            return;
        }

        clickManager.AutoClick();
    }
}