using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Sh : MonoBehaviour
{
    [Range(0, 16)]
    public int outlineSize = 1;
    public Color color = Color.white;

    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateOutLine(true);
    }
    private void OnDisable()
    {
        UpdateOutLine(false);
    }
    private void Update()
    {
        UpdateOutLine(true);
    }
    void UpdateOutLine(bool Outline)
    {
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();//메터리얼 값 클래스 선언.
        spriteRenderer.GetPropertyBlock(mpb);//메터리얼 값 가져오기
        mpb.SetFloat("_Outline", Outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", color);
        mpb.SetFloat("_OutlineSize", outlineSize);
        spriteRenderer.SetPropertyBlock(mpb);//메터리얼 값 생성하기
    }
}
