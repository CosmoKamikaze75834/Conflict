using System.Collections.Generic;
using UnityEngine;

public static class ExplosionForceApplier
{ 
    private static int _explosionRadius = 0;

    public static void Apply(List<Rigidbody> children, Vector3 explosionCenter, float _explosionForce)
    {
        foreach (var child in children)
        {
            if(child != null)
            {
                child.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
            }
        }
    }
}