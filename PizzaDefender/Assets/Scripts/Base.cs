using UnityEngine;

public class Base : MonoBehaviour
{
	private Transform _baseTrigger;
	public int Health = 100;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		this._baseTrigger = this.transform.Find("BaseTrigger").transform;
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	void FixedUpdate()
	{
		var layerNumber = LayerMask.NameToLayer("Enemies");
		var layerMask = 1 << layerNumber;

		Collider2D[] hits = Physics2D.OverlapCircleAll(this._baseTrigger.position, .1f, layerMask);
		foreach (var c in hits)
		{
			if (c.tag == "Enemy")
			{
				CatchDamage();
				break;
			}
		}
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			CatchDamage();
			Destroy(other.gameObject);
		}
	}

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
	}

	private void CatchDamage()
	{
		this.Health -= 10;
		Debug.Log("Damaged!");
	}
}