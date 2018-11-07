using UnityEngine;

namespace Assets.Scripts
{
	public class Spawner : MonoBehaviour
	{
		public float SpawnTime = 5f;
		public float SpawnDelay = 3f;
		public GameObject[] Enemies;

		/// <summary>
		/// Start is called on the frame when a script is enabled just before
		/// any of the Update methods is called the first time.
		/// </summary>
		void Start()
		{
			InvokeRepeating("Spawn", SpawnDelay, SpawnTime);
		}

		private void Spawn()
		{
			var enemyIndex = Random.Range(0, Enemies.Length);
			var original = Enemies[enemyIndex];
			Instantiate(original, this.transform.position, this.transform.rotation);
		}
	}
}
