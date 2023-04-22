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
        MaterialPropertyBlock mpb = new MaterialPropertyBlock();//���͸��� �� Ŭ���� ����.
        spriteRenderer.GetPropertyBlock(mpb);//���͸��� �� ��������
        mpb.SetFloat("_Outline", Outline ? 1f : 0);
        mpb.SetColor("_OutlineColor", color);
        mpb.SetFloat("_OutlineSize", outlineSize);
        spriteRenderer.SetPropertyBlock(mpb);//���͸��� �� �����ϱ�
    }
}
