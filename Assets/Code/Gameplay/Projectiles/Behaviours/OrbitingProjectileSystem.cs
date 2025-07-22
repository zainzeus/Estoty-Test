using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Projectiles.Behaviours
{
    public class OrbitingProjectileSystem : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private int projectileCount = 3;
        [SerializeField] private float orbitRadius = 2.5f;
        [SerializeField] private float rotationSpeed = 90f; 

        private readonly List<Transform> _projectiles = new();

        private void Start()
        {
            float angleStep = 360f / projectileCount;

            for (int i = 0; i < projectileCount; i++)
            {
                GameObject proj = Instantiate(projectilePrefab, transform);
                _projectiles.Add(proj.transform);
            }
        }

        private void Update()
        {
            for (int i = 0; i < _projectiles.Count; i++)
            {
                Transform proj = _projectiles[i];

                if (proj == null)
                {
                    _projectiles.RemoveAt(i); // Clean up destroyed projectiles
                    continue;
                }



                float angle = Time.time * rotationSpeed + (360f / projectileCount) * i;
                float rad = angle * Mathf.Deg2Rad;
                Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitRadius;

                _projectiles[i].localPosition = offset;
            }
        }
    }
}
