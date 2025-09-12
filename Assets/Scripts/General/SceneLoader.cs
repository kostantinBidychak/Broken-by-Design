using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void Load(string name) 
    {
        SceneManager.LoadScene(name);
    }
}
