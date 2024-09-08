using DG.Tweening;
using UnityEngine;

namespace Stars
{
    public class StarsRotating
    {
        private float rotationSpeed;
        private GameObject star;
        private Tween rotationTween;

        public StarsRotating(GameObject star, float rotationSpeed)
        {
            this.rotationSpeed = rotationSpeed;
            this.star = star;
        }

        public void StartRotation()
        {
            rotationTween = star.transform.DORotate(new Vector3(0, 360, 0), rotationSpeed, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
        }

        public void StopRotation()
        {
            rotationTween?.Kill();
        }

        public void Destroy()
        {
            StopRotation();
            star = null;
        }
    }
}