namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;

    public class PistolSlide : VRTK_InteractableObject
    {
        public Transform RestTransform;
        public Transform MaxSlideTransform;

        private IEnumerator currentCoroutine;
        private float SlideSpeed = 0.0005f;
        private float SlideTime = 0.1f;

        public IEnumerator Fire()
        {
            currentCoroutine = SlideBack();
            StartCoroutine(currentCoroutine);

            yield return new WaitForSeconds(SlideTime);

            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }

            currentCoroutine = SlideForth();
            StartCoroutine(currentCoroutine);
        }

        IEnumerator SlideBack()
        {
            while (transform.localPosition != MaxSlideTransform.localPosition)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, MaxSlideTransform.localPosition, SlideSpeed);
                yield return null;
            }
        }

        IEnumerator SlideForth()
        {
            while (transform.localPosition != RestTransform.localPosition)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, RestTransform.localPosition, SlideSpeed);
                yield return null;
            }
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();
            //base.Update();
            //if (transform.localPosition.x <= restPosition)
            //{
            //    transform.localPosition = new Vector3(restPosition, transform.localPosition.y, transform.localPosition.z);
            //}

            //if (fireTimer == 0 && transform.localPosition.x > restPosition && !IsGrabbed())
            //{
            //    transform.localPosition = new Vector3(transform.localPosition.x - boltSpeed, transform.localPosition.y, transform.localPosition.z);
            //}

            //if (fireTimer > 0)
            //{
            //    transform.localPosition = new Vector3(transform.localPosition.x - boltSpeed, transform.localPosition.y, transform.localPosition.z);
            //    fireTimer -= boltSpeed;
            //}

            //if (fireTimer < 0)
            //{
            //    fireTimer = 0;
            //}
        }
    }
}
