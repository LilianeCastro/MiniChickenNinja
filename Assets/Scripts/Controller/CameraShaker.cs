using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public IEnumerator shake(float duration, float magnitude)
    {
        Vector3 originPos = transform.localPosition;

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1.2f, 1.2f) * magnitude;
            float y = Random.Range(-0.5f, 0.5f) * magnitude;

            transform.localPosition = new Vector3(x, y, originPos.z);

            elapsed +=  Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originPos;
    }

}
