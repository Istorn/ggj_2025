using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public GameObject ropeSegmentPrefab; // Prefab for a single rope segment
    public Transform anchorPoint;       // The top anchor
    public GameObject bridge;           // The bridge object
    public int segmentCount = 10;       // Number of rope segments

    private void Start()
    {
        Rigidbody2D previousRb = anchorPoint.GetComponent<Rigidbody2D>();
        Vector2 segmentPosition = anchorPoint.position;

        // Create rope segments
        for (int i = 0; i < segmentCount; i++)
        {
            GameObject segment = Instantiate(ropeSegmentPrefab, segmentPosition, Quaternion.identity);
            Rigidbody2D currentRb = segment.GetComponent<Rigidbody2D>();
            DistanceJoint2D joint = segment.GetComponent<DistanceJoint2D>();

            // Connect the current segment to the previous segment
            joint.connectedBody = previousRb;
            joint.distance = 0.5f;

            // Update the previous Rigidbody
            previousRb = currentRb;

            // Position for the next segment
            segmentPosition.y -= 0.5f;
        }

        // Attach the bridge to the last rope segment
        DistanceJoint2D bridgeJoint = bridge.AddComponent<DistanceJoint2D>();
        bridgeJoint.connectedBody = previousRb;
        bridgeJoint.distance = 0.5f;
    }
}

