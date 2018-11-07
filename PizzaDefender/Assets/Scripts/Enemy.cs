using UnityEngine;

namespace Assets.Scripts
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private LayerMask _wallLayerMask;
		private SpriteRenderer _spriteRenderer;
		private Transform _wallCheck;
		public float MoveSpeed;
		private Rigidbody2D _component;
		public bool FacingRight = false;

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			this._spriteRenderer = this.transform.Find("Body").GetComponent<SpriteRenderer>();
			this._wallCheck = this.transform.Find("WallCheck").transform;
			this._component = this.GetComponent<Rigidbody2D>();
		}

		/// <summary>
		/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
		/// </summary>
		void FixedUpdate()
		{
			Collider2D[] hits = Physics2D.OverlapCircleAll(this._wallCheck.position, .1f, this._wallLayerMask);
			foreach (var c in hits)
			{
				if (c.tag == "Wall" || c.IsTouchingLayers(this._wallLayerMask))
				{
					Flip();
					break;
				}
			}

			float right = this.FacingRight ? 1 : -1;
			this._component.velocity = new Vector2(/*this.transform.localScale.x **/ this.MoveSpeed * right, this._component.velocity.y);
		}

		private void Flip()
		{
			Vector3 scale = this.transform.localScale;
			scale.x *= -1;
			this.FacingRight = !this.FacingRight;
			this.transform.localScale = scale;
		}
	}
}
