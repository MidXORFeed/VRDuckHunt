namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;

    public class PistolSlide : VRTK_InteractableObject
    {
        public Transform RestTransform;
        public Transform MaxSlideTransform;

        private IEnumerator currentCoroutine;
        private float SlideBackSpeed = 0.0005f;
        private float SlideForthSpeed = 0.00025f;
        private float SlideHack = 100000.0f;

        public IEnumerator Fire()
        {
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }

            currentCoroutine = SlideBack();
            yield return StartCoroutine(currentCoroutine);

            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }

            currentCoroutine = SlideForth();
            yield return StartCoroutine(currentCoroutine);
        }

        IEnumerator SlideBack()
        {
            while (transform.localPosition != MaxSlideTransform.localPosition)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, MaxSlideTransform.localPosition, SlideBackSpeed);
                yield return null;
            }
            currentCoroutine = null;
        }

        IEnumerator SlideForth()
        {
            while (transform.localPosition != RestTransform.localPosition)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, RestTransform.localPosition, SlideForthSpeed);
                yield return null;
            }
            currentCoroutine = null;
        }

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Update()
        {
            base.Update();

            if (transform.localRotation != RestTransform.localRotation)
            {
                transform.localRotation = RestTransform.localRotation;
            }

            if (currentCoroutine == null && transform.localPosition != RestTransform.localPosition)
            {
                if (transform.localPosition != MaxSlideTransform.localPosition)
                {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, RestTransform.localPosition, SlideHack);
                }
            }


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
