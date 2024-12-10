using Unity.VisualScripting;
using UnityEngine;

public class WaveCreator : MonoBehaviour
{
    public LineRenderer xlineRenderer; 
    public int ix = 328;
    public Vector2 Limits = new Vector2(-9f, 8.0f);
   [Range(0f,5f)] public float amplitude = 3.09f;
   [Range(0f,1.00f)] public float frequency = 0.55f;
   [Range(0f, 10f)]public float speed = 2f;
    
    void Start()
    {
        xlineRenderer = GetComponent<LineRenderer>();
        xlineRenderer.widthMultiplier = 0.2f;
    }

    void Drawing()
    {
        float start = Limits.x; // Start Position
        float Tau = 2 * Mathf.PI; // Formula: pi2r
        float Finish = Limits.y; // End Position
        xlineRenderer.positionCount = ix;
        for (int i = 0; i < ix; i++)
        {
            float progress = (float)i / (ix - 1);
            float x = Mathf.Lerp(start, Finish, progress);
            float y = amplitude * Mathf.Sin((Tau * frequency * x) + (Time.timeSinceLevelLoad * speed)); // Formula
            xlineRenderer.SetPosition(i, new Vector3(x,y,0));
            Debug.Log(i);
        }
    }
    
    
    
    void Update()
    {
        Drawing();
    }
}
