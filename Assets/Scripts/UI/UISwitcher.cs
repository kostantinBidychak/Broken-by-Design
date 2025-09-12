using UnityEngine;

public class UISwitcher : MonoBehaviour
{
    public void Off() => gameObject.SetActive(false);
    public void On() => gameObject.SetActive(true);
}
