using UnityEngine;
using System.Collections;

public class PathedProjectileSpawner : MonoBehaviour{

	public Transform Destination;
	public PathedProjectile Projectile;

	public float Speed;
	public float FireRate;

	private float _nextShotInSeconds;
	
	public void Start(){
		_nextShotInSeconds = FireRate;
	}

	public void Update(){
		if ((_nextShotInSeconds -= Time.deltaTime) > 0)
						return;

		_nextShotInSeconds = FireRate;
		var projectile = (PathedProjectile)Instantiate (Projectile, transform.position, transform.rotation);
		projectile.Initialize (Destination, Speed);
	}

	public void OnDrawGizmos(){
		if (Destination == null)
			return;

		Gizmos.color = Color.red;
		Gizmos.DrawLine (transform.position, Destination.position);
	}
}

