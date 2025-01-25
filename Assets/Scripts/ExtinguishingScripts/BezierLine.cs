using UnityEngine;

public class BezierLine : MonoBehaviour
{
    public Transform pointA; // Start point
    public Transform pointB; // End point
    public Transform controlPoint; // Control point for bending
    public int segmentCount = 20; // Number of segments for smoothness

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = segmentCount + 1; // One extra point to close the curve
    }

    void Update()
    {
        for (int i = 0; i <= segmentCount; i++)
        {
            float t = i / (float)segmentCount; // Normalized time [0, 1]
            Vector3 curvePoint = CalculateBezierPoint(t, pointA.position, controlPoint.position, pointB.position);
            lineRenderer.SetPosition(i, curvePoint);
        }
    }

    Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        // Quadratic Bezier formula: (1-t)^2 * P0 + 2*(1-t)*t*P1 + t^2*P2
        float u = 1 - t;
        return (u * u * p0) + (2 * u * t * p1) + (t * t * p2);
    }
}
