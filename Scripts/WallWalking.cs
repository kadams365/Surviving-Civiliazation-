using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class WallWalking : MonoBehaviour
{
    public Vector3 pointB;

    IEnumerator Start()
    {
        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            yield return StartCoroutine(RotateObject());
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
            yield return StartCoroutine(RotateObject());
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = .75f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
        yield return new WaitForSeconds(Random.Range(1f,5f));
    }

    IEnumerator RotateObject()
    {
        float amountRotated = 0f;
        while (amountRotated < 180f)
        {
            float frameRotation = 45 * Time.deltaTime;  // Amount to rotate this frame
            transform.Rotate(0, frameRotation, 0);  // Apply the rotation
            amountRotated += frameRotation;  // Also keep track of the amount rotated so far
            yield return new WaitForEndOfFrame();  // We want to rotate every frame until we reach the target
        }
    }
}
