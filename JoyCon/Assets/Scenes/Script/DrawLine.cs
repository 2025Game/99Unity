using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLine : MonoBehaviour
{
    [Header("線を結ぶ対象")]
    public Transform targetA; // 点A（始点）
    public Transform targetB; // 点B（終点）

    [Header("線の見た目")]
    public float lineWidth = 0.1f; // 線の太さ

    private LineRenderer lineRenderer;

    void Start()
    {
        // LineRendererコンポーネントを取得＆初期設定
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // 頂点の数は2つ（始点と終点）
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    void Update()
    {
        if (targetA != null && targetB != null)
        {
            // 毎フレーム2つのオブジェクトの位置をLineRendererにセット
            lineRenderer.SetPosition(0, targetA.position); // 始点（インデックス0）
            lineRenderer.SetPosition(1, targetB.position); // 終点（インデックス1）
        }
    }

    // コードから直接Vector3で指定したい場合に使える関数
    public void SetPositions(Vector3 startPos, Vector3 endPos)
    {
        if (lineRenderer == null) lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}