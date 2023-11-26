using System.Collections.Generic;
using UnityEngine;

namespace TopPanel
{
	public class TopPanelController : MonoBehaviour
	{
		[SerializeField] private List<TaskTab> _tabs;
		[SerializeField] private int _startTask;

		private void Start()
		{
			SetTask( _tabs[_startTask - 1].Panel );
		}

		private void OnEnable()
		{
			for (int i = 0; i < _tabs.Count; i++)
			{
				int cur = i;
				_tabs[i].Button.onClick.AddListener( () => SetTask( _tabs[cur].Panel ) );
			}
		}
	
		private void OnDisable()
		{
			for (int i = 0; i < _tabs.Count; i++)
			{
				int cur = i;
				_tabs[i].Button.onClick.RemoveListener( () => SetTask( _tabs[cur].Panel ) );
			}
		}

		private void SetTask(GameObject task)
		{
			for (int i = 0; i < _tabs.Count; i++)
			{
				_tabs[i].Panel.SetActive( false );
			}

			task.SetActive( true );
		}
	}
}