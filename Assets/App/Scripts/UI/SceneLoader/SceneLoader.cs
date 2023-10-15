using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Scripts.UI.SceneLoader
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadSceneByIndex(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}