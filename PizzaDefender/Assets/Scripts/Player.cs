using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
	public class Player : MonoBehaviour
	{
		private Transform _groundCheck;
		private bool _grounded;
		private bool _jump;
		private Rigidbody2D _rigitbody;
		[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;

		[HideInInspector]
		public bool FacingRight = true;
		public float JumpForce = 1;
		public float MoveForce = 365f;
		public float MaxSpeed = 5f;

		public float runSpeed = 40f;

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			this._groundCheck = this.transform.Find("GroundCheck");
			this._rigitbody = this.GetComponent<Rigidbody2D>();
		}

		/// <summary>
		/// Update is called every frame, if the MonoBehaviour is enabled.
		/// </summary>
		void Update()
		{
			//this._grounded = Physics2D.Linecast(this.transform.position, this._groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
			this._grounded = Physics2D.OverlapCircleAll(this._groundCheck.position, .1f, 1 << LayerMask.NameToLayer("Ground")).Any();

			if (Input.GetButtonDown("Jump"))
			{
				this._jump = true;
			}
		}

		/// <summary>
		/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
		/// </summary>
		void FixedUpdate()
		{
			var move = Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime * 10f;
			Vector3 targetVelocity = new Vector2(move, this._rigitbody.velocity.y);
			Vector3 mVelocity = Vector3.zero;
			this._rigitbody.velocity = Vector3.SmoothDamp(this._rigitbody.velocity, targetVelocity, ref mVelocity, m_MovementSmoothing);

			if (move > 0 && !FacingRight)
			{
				Flip();
			}
			else if (move < 0 && FacingRight)
			{
				Flip();
			}

			if (this._jump)
			{
				this._rigitbody.AddForce(new Vector2(0f, this.JumpForce));

				this._jump = false;
			}
		}

		private void Flip()
		{
			FacingRight = !FacingRight;

			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
