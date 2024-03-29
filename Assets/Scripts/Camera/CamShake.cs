﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : Singleton<CamShake>
{
    public IEnumerator Shake(float duration, float mag)
    {
        Vector3 original = transform.localPosition;

        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float x = original.x + Random.Range(-1f, 1f) * mag;
            float y = original.y + Random.Range(-1f, 1f) * mag;

            transform.localPosition = new Vector3(x, y, -10);

            elapsed += Time.deltaTime;

            yield return null;
        }
        transform.localPosition = original;
    }
}
