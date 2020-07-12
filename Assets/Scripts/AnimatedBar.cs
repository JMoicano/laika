using UnityEngine;
using UnityEngine.UI;

public abstract class AnimatedBar : MonoBehaviour
{
    [Range(0.1f, 100)]
    public float AnimationSmoothness = .6f;
    public float StartValue;
    public Gradient Gradient;
    public Image BarImage;

    protected float totalWidth;

    public virtual float Progress { get; }

    protected void Start()
    {
        totalWidth = BarImage.rectTransform.rect.width;
        BarImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, StartValue);
    }


    protected void Animate()
    {
        var currentWidth = BarImage.rectTransform.rect.width;
        var diff = totalWidth * Progress - currentWidth;

        if (Mathf.Abs(diff) < AnimationSmoothness)
            return;

        var targetWidth = currentWidth + Mathf.Sign(diff) * AnimationSmoothness;

        BarImage.color = Gradient.Evaluate(targetWidth / totalWidth);
        BarImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Clamp(targetWidth, 0, totalWidth));
    }

    protected void Update() => Animate();
}
