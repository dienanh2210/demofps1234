using UnityEngine;
using System.Collections;
using UltraReal.Utilities;
using UltraReal.WeaponSystem;
using UnityEngine.UI;


public class BasicLauncher : UltraRealLauncherBase {

	
	float _nextShotTime;

	
	int _ammoCount;

	
	[SerializeField] 
	private float _shotDelay = 0.1f;

	
	[SerializeField]
	private float _reloadDelay = 1f;

   
    [SerializeField]
    private int _magazineSize = 35;
        

	
	[SerializeField]
	private Transform _ejectorTransform = null;

	
	[SerializeField]
	private Transform _muzzleTransform = null;

	
	[SerializeField]
	private AudioClip _reloadSound = null;

	
	
	[SerializeField]
	private AudioClip _missfireSound = null;

	
	[SerializeField]
	protected float _ejectorForce = 100f;

	
	[SerializeField]
	protected float _ejectorTorque = 100f;

    
    [SerializeField]
    protected AudioSource _audioSource = null;

    
    [SerializeField]
    protected Animator _animator = null;

    
    [SerializeField]
    protected string _fireAnimTriggerName = "Fire";
    
    [SerializeField]
    protected string _reloadAnimTriggerName = "Reload";

	
	protected override void OnStart ()
	{
		base.OnStart ();

		_nextShotTime = Time.time;
		_ammoCount = _magazineSize;

        if (_audioSource == null)
            _audioSource = gameObject.AddComponent<AudioSource>();
	}

    public Text bullet;
    int bull;

    public override void Fire ()
	{
		if (_nextShotTime <= Time.time){
			if (_ammoCount > 0 && _ammo != null) {

				if(_muzzleTransform != null)
                    _ammo.SpawnAmmo(_muzzleTransform, _ejectorTransform, _ejectorForce, _ejectorTorque, 2f, _audioSource);

				_ammoCount--;

                if (_animator != null)
                    _animator.SetTrigger(_fireAnimTriggerName);

              //  fire();
                base.Fire ();
               



            }
			else
				MissFire();
			_nextShotTime = Time.time + _shotDelay;
		}
	}

	
	public override void MissFire()
	{
		base.MissFire ();

		if (_missfireSound != null && _audioSource != null)
			_audioSource.PlayOneShot (_missfireSound);

       
    }


    public override void Reload ()
	{
       /* base.Reload ();

		if (_reloadSound != null && _audioSource != null)
			_audioSource.PlayOneShot (_reloadSound);

        if (_animator != null)
            _animator.SetTrigger(_reloadAnimTriggerName);

		_nextShotTime = Time.time + _reloadDelay;
		_ammoCount = _magazineSize;
        */
    
       

        

    }
  /*  void fire() {
        _magazineSize--;
        bullet.text = "Bullet:" + _magazineSize.ToString();

    }
   */
}
