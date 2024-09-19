using System.Collections;
using UnityEngine;

public class TweenManager : MonoBehaviour
{
    // Tween local position using an AnimationCurve
    public void TweenLocalPosition(RectTransform rectTransform, Vector2 startPos, Vector2 endPos, float duration, AnimationCurve curve)
    {
        StartCoroutine(TweenLocalPositionCoroutine(rectTransform, startPos, endPos, duration, curve));
    }

    private IEnumerator TweenLocalPositionCoroutine(RectTransform rectTransform, Vector2 startPos, Vector2 endPos, float duration, AnimationCurve curve)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration); // Normalized time (0 to 1)
            float curveValue = curve.Evaluate(t); // Evaluate the curve to get the eased value

            // Interpolate local position
            rectTransform.localPosition = Vector2.Lerp(startPos, endPos, curveValue);
            yield return null; // Wait until the next frame
        }
        rectTransform.localPosition = endPos; // Ensure final position is set
    }

    // Tween local scale using an AnimationCurve
    public void TweenLocalScale(RectTransform rectTransform, Vector2 startScale, Vector2 endScale, float duration, AnimationCurve curve)
    {
        StartCoroutine(TweenLocalScaleCoroutine(rectTransform, startScale, endScale, duration, curve));
    }

    private IEnumerator TweenLocalScaleCoroutine(RectTransform rectTransform, Vector3 startScale, Vector3 endScale, float duration, AnimationCurve curve)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration); // Normalized time (0 to 1)
            float curveValue = curve.Evaluate(t); // Get the value from the curve

            // Interpolate local scale
            rectTransform.localScale = Vector2.Lerp(startScale, endScale, curveValue);
            yield return null;
        }
        rectTransform.localScale = endScale; // Ensure final scale is set
    }

    // Tween float value (e.g., opacity) using an AnimationCurve
    public void TweenFloat(System.Action<float> setter, float startValue, float endValue, float duration, AnimationCurve curve)
    {
        StartCoroutine(TweenFloatCoroutine(setter, startValue, endValue, duration, curve));
    }

    private IEnumerator TweenFloatCoroutine(System.Action<float> setter, float startValue, float endValue, float duration, AnimationCurve curve)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            float curveValue = curve.Evaluate(t);

            // Interpolate float value and call the setter
            setter(Mathf.Lerp(startValue, endValue, curveValue));
            yield return null;
        }
        setter(endValue); // Ensure final value is set
    }
}