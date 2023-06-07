using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfaceTest : MonoBehaviour
{
    private float maxX;
    private float minX;
    private float maxZ;
    private float minZ;
    private Renderer renderer;
    public GameObject prefab;
    private GameObject clone;

    public Transform Obstacle;

    public int depth = 20;
    public int width;
    public int height;
    public float scale = 20;
    public float treshold = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        this.renderer = this.gameObject.GetComponent<Renderer>();
        this.maxX = this.renderer.bounds.max.x;
        this.minX = this.renderer.bounds.min.x;
        this.maxZ = this.renderer.bounds.max.z;
        this.minZ = this.renderer.bounds.min.z;

        this.width = (int)this.maxX - (int)this.minX;
        this.height = (int)this.maxZ - (int)this.minZ;

        GeneratePrefabs();

        Obstacle.transform.position = this.transform.position;
        /*Obstacle.transform.rotation = this.transform.rotation;*/

    }

    private void GeneratePrefabs()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            Destroy(child.gameObject);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(CalculateHeight(x, y) > this.treshold)
                {
                    this.clone = Instantiate(prefab, new Vector3(x + transform.position.x - (width/2) + prefab.transform.position.x, this.transform.position.y + prefab.transform.position.y, y + transform.position.z - (height / 2) + prefab.transform.position.z), prefab.transform.rotation, this.Obstacle.transform);
                }
            }
        }
    }

    private float CalculateHeight (int x, int y)
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / height * scale;

        float OffsetX = Random.Range(-10000, 10000);
        float OffsetY = Random.Range(-10000, 10000);

        return Mathf.PerlinNoise(xCoord + OffsetX, yCoord + OffsetY);
    }
}
