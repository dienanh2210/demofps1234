using UnityEngine;
using System.Collections;
using UltraReal.Utilities;
using UltraReal.WeaponSystem;
using UnityEngine.UI;


public class BasicInputExample : UltraRealMonobehaviorBase {

	
	private UltraRealLauncherBase launcher;

	private Animation anim;
    private GameObject player;


	protected override void OnStart ()
	{
		anim = GetComponent<Animation>();
		base.OnStart ();

		launcher = GetComponent<UltraRealLauncherBase> ();
	}

	

	public AudioClip otherClip;

	protected override void OnUpdate ()
	{
		base.OnUpdate ();

		if (Input.GetButton ("Fire1") && launcher != null) {
			launcher.Fire ();
		//	anim.CrossFade ("Fire");
            

		}

		if (Input.GetKeyDown (KeyCode.R)) {
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = otherClip;
			audio.Play();

		//	anim.CrossFade ("Reload");
			launcher.Reload ();
             
		}
	}
   
}
