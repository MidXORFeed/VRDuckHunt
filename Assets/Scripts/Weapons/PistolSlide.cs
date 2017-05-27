namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;

    public class PistolSlide : VRTK_InteractableObject
    {
        public float pullMultiplier;
        public float pullOffset;
        public float maxPullDistance = 1.0f;

        public Transform RestTransform;
        public Transform MaxSlideTransform;
        public GameObject leftController;
        public GameObject rightController;

        private VRTK_InteractGrab holdControl;
        private VRTK_InteractGrab sliderControl;

        private IEnumerator currentCoroutine;
        private float SlideBackSpeed = 0.166f;
        private float SlideForthSpeed = 0.083f;
        private float SlideHack = 100000.0f;

        private SliderAnimation sliderAnimation;
        private float previousPull;
        private float currentPull;

        private void DoObjectGrab(object sender, InteractableObjectEventArgs e)
        {
            if (VRTK_DeviceFinder.IsControllerLeftHand(e.interactingObject))
            {
                holdControl = VRTK_DeviceFinder.GetControllerLeftHand().GetComponent<VRTK_InteractGrab>();
                sliderControl = VRTK_DeviceFinder.GetControllerRightHand().GetComponent<VRTK_InteractGrab>();
            }
            else
            {
                sliderControl = VRTK_DeviceFinder.GetControllerLeftHand().GetComponent<VRTK_InteractGrab>();
                holdControl = VRTK_DeviceFinder.GetControllerRightHand().GetComponent<VRTK_InteractGrab>();
            }
        }

        private void DoObjectUnGrab(object sender, InteractableObjectEventArgs e)
        {
            currentCoroutine = SlideForth();
            StartCoroutine(currentCoroutine);
        }

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
            float maxSlidePosition = 1.0f;
            while (currentPull < maxSlidePosition)
            {
                currentPull += SlideBackSpeed;
                if (currentPull > maxSlidePosition)
                {
                    currentPull = maxSlidePosition;
                }
                sliderAnimation.SetFrame(currentPull);
                yield return null;
            }
            currentCoroutine = null;
        }

        IEnumerator SlideForth()
        {
            float minSlidePosition = 0.0f;
            while (currentPull > minSlidePosition)
            {
                currentPull -= SlideForthSpeed;
                if (currentPull < minSlidePosition)
                {
                    currentPull = minSlidePosition;
                }
                sliderAnimation.SetFrame(currentPull);
                yield return null;
            }
            currentCoroutine = null;
        }

        private void PullSlider()
        {
            currentPull = Mathf.Clamp((Vector3.Distance(holdControl.transform.position, sliderControl.transform.position) - pullOffset) * pullMultiplier, 0, maxPullDistance);
            sliderAnimation.SetFrame(currentPull);
            previousPull = currentPull;
        }

        void Start()
        {
            sliderAnimation = GetComponent<SliderAnimation>();
            this.InteractableObjectGrabbed += new InteractableObjectEventHandler(DoObjectGrab);
            this.InteractableObjectUngrabbed += new InteractableObjectEventHandler(DoObjectUnGrab);
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

            if (!IsGrabbed() && currentCoroutine == null && transform.localPosition != RestTransform.localPosition)
            {
                if (transform.localPosition != MaxSlideTransform.localPosition)
                {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, RestTransform.localPosition, SlideHack);
                }
            }

            if (IsGrabbed())
            {
                PullSlider();
            }
        }
    }
}
