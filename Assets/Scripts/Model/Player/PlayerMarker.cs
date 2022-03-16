using NyarlaEssentials;
using UnityEngine;

namespace Model.Player
{
    public class PlayerMarker : Transformer
    {
        public void RotateToDirection(Vector3 direction, float maxDelta)
        {
            Vector3 targetDirection =
                Vector3.RotateTowards(transform.forward, direction, maxDelta * Mathf.Deg2Rad, 999);
            transform.rotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        }
    }
}