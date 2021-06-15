using UnityEngine;

namespace Core
{
    public interface IRaycast2D
    {
        RaycastHit2D PerformRaycast(Vector3 origin, Vector3 direction, int layerMask);
    }
}
