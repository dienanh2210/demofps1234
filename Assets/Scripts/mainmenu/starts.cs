using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class starts : MonoBehaviour {

   // public MouseLook mouseLook;
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      //  mouseLook.m_cursorIsLocked = false;
        //  mouseLook.lockCursor = true;
       
    }

    public void star() {
        // SceneManager.LoadScene("testscene", LoadSceneMode.Additive);
       // SceneManager.LoadScene("testscene", LoadSceneMode.Single);
        Application.LoadLevel("testscene");
       
    }
   public  void OnLevelWasLoaded(int level)
    {
#if UNITY_EDITOR && (UNITY_5_0 || UNITY_5_1 || UNITY_5_2_0)
     if (UnityEditor.Lightmapping.giWorkflowMode == UnityEditor.Lightmapping.GIWorkflowMode.Iterative) {
         DynamicGI.UpdateEnvironment();
        Application.LoadLevel("testscene");
     }
#endif
    }
}
