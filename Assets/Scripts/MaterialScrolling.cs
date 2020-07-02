using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SortingLayer {Background, Default, Foreground}

public class MaterialScrolling : MonoBehaviour
{
    private Renderer mRenderer;
    private Material currentMaterial;
    private float offSet;
    public float increaseOffSet;
    public float speed;
    public int orderLayer;
    public SortingLayer sortingLayer;

    void Start()
    {
        mRenderer = GetComponent<MeshRenderer>();
        mRenderer.sortingLayerName = sortingLayer.ToString();
        mRenderer.sortingOrder = orderLayer;
        currentMaterial = mRenderer.material;
    }

    void FixedUpdate()
    {
        offSet += increaseOffSet;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offSet * speed, 0));
    }
}
