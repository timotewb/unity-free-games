using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField] int loadSceneIndex;
    [SerializeField] Animator transition;
    // Start is called before the first frame update
    public void StartGame() {
        LevelLoader lL = gameObject.AddComponent<LevelLoader>();
        lL.LoadNextLevel(loadSceneIndex, transition);
    }
}
