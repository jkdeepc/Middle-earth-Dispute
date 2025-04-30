using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RTSEngine
{
	public class MainMenu : MonoBehaviour {


        public GameObject exitButton;

        private void Awake()
        {
#if UNITY_WEBGL
       
            exitButton.SetActive(false);
#endif
        }

        public void LeaveGame ()
		{
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
       
            Application.Quit();
#endif
        }

        public void LoadScene(string sceneName)
		{
			SceneManager.LoadScene (sceneName);
		}
	}
}