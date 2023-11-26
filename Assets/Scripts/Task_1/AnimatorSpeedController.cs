using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task_1
{
	public class AnimatorSpeedController : MonoBehaviour
	{
		[SerializeField] private Slider _slider;
		[SerializeField] private Animator _targetAnimator;

		protected void Update()
		{
			if ( Math.Abs( _targetAnimator.speed - _slider.value ) < float.Epsilon )
				return;
			
			_targetAnimator.speed = _slider.value;
			
			_targetAnimator.enabled = _targetAnimator.speed > 0;
		}
	}
}