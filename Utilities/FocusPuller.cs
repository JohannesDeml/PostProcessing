// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FocusPuller.cs" company="Supyrb">
//   Copyright (c) 2017 Supyrb. All rights reserved.
// </copyright>
// <author>
//   Johannes Deml
//   send@johannesdeml.com
// </author>
// --------------------------------------------------------------------------------------------------------------------

using BitStrap;
using UnityEngine.PostProcessing;

namespace Supyrb
{
    using UnityEngine;
    using System.Collections;
    
    [ExecuteInEditMode]
    public class FocusPuller : MonoBehaviour
    {
        [SerializeField] private PostProcessingBehaviour postProcessing;
        [SerializeField] private Transform target = null;
        [SerializeField] private Vector3 positionOffset = Vector3.zero;
        [SerializeField] private float distanceOffset = 0f;
        [SerializeField, ReadOnly] private float currentDistance = 0f;

        private void OnPreRender()
        {
            if (target == null)
            {
                return;
            }
            currentDistance = Vector3.Dot(target.position + positionOffset - transform.position, transform.forward) + distanceOffset;
            postProcessing.SetDepthOfFieldFocusDistance(currentDistance);
        }

        void Reset()
        {
            if (postProcessing == null)
            {
                postProcessing = GetComponent<PostProcessingBehaviour>();
            }
        }
    }
}

