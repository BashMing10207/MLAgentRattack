using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BashUtils
{
    public static Quaternion QuatFromV3AndV3(Vector3 a, Vector3 b)
    {
        Vector3 crossDIr = Vector3.Cross(a, b);
        float Betweendegree = Vector3.Angle(a, b);
        Quaternion velocityRot = new(crossDIr.x * Mathf.Sin(Betweendegree / 2), crossDIr.y * Mathf.Sin(Betweendegree / 2), crossDIr.z * Mathf.Sin(Betweendegree / 2)
            , Mathf.Cos(Betweendegree / 2));
        return velocityRot;
    }
    public static Vector3 V2ToV3(Vector2 v)
    {
        return new Vector3(v.x, 0, v.y);
    }
    public static void SmoothNormals(Mesh mesh)
    {
        var trianglesOriginal = mesh.triangles;
        var triangles = trianglesOriginal.ToArray();

        var vertices = mesh.vertices;

        var mergeIndices = new Dictionary<int, int>();

        for (int i = 0; i < vertices.Length; i++)
        {
            var vertexHash = vertices[i].GetHashCode();

            if (mergeIndices.TryGetValue(vertexHash, out var index))
            {
                for (int j = 0; j < triangles.Length; j++)
                    if (triangles[j] == i)
                        triangles[j] = index;
            }
            else
                mergeIndices.Add(vertexHash, i);
        }

        mesh.triangles = triangles;

        var normals = new Vector3[vertices.Length];

        mesh.RecalculateNormals();
        var newNormals = mesh.normals;

        for (int i = 0; i < vertices.Length; i++)
            if (mergeIndices.TryGetValue(vertices[i].GetHashCode(), out var index))
                normals[i] = newNormals[index];

        mesh.triangles = trianglesOriginal;
        mesh.normals = normals;
    }
}
[Serializable]
public class SetablePair<T, T2> //c#의 Pair와 Tuple은 readonly이기에 새로 만든 
    //struct는 lsit 등에서 꺼낼 때 복사값이 내보내지므로 class로
{
    public T First;
    public T2 Second;

    public void SetFirst(T value) => First = value;
    public void SetSecond(T2 value) => Second = value;

    public SetablePair(T key, T2 val)
    {
        this.First = key;
        this.Second = val;
    }
}