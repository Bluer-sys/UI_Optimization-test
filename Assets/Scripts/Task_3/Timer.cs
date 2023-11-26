using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace Task_3
{
	public class Timer : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _timer;
		
		private readonly StringBuilder _sb = new();
		
		private readonly DateTime _dateFromStart = DateTime.Now;
		
		private float _elapsedTimeFromStart;

		private void Start()
		{
			_elapsedTimeFromStart = _dateFromStart.Second;
		}

		private void Update()
		{
			_sb.Length = 0;
			_sb.Append( "Time: " );
			_sb.Append( _dateFromStart.Day );
			_sb.Append( ":" );
			_sb.Append( _dateFromStart.Month );
			_sb.Append( ":" );
			_sb.Append( _dateFromStart.Year );
			_sb.Append( " " );
			_sb.Append( ( _dateFromStart.Hour + (int) _elapsedTimeFromStart / 3600 ) % 24 );
			_sb.Append( ":" );
			_sb.Append( ( _dateFromStart.Minute + (int) _elapsedTimeFromStart / 60 ) % 60 );
			_sb.Append( ":" );
			_sb.Append( (int) _elapsedTimeFromStart % 60 );
			
			_timer.text = _sb.ToString();
			
			_elapsedTimeFromStart += Time.deltaTime;
		}
	}
}