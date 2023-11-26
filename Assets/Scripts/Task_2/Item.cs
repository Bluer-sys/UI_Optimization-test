using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Task_2
{
	[RequireComponent(typeof(RectTransform))]
	public class Item : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private Image _image;

		private RectTransform _transform;
		
		private void Awake()
		{
			_transform = GetComponent<RectTransform>();
		}

		public void SetItem(ItemModel model)
		{
			_image.sprite = model.Sprite;
			_text.text = model.Text;
		}

		public void SetPosition(float x, float y)
		{
			_transform.anchoredPosition = new Vector2( x, y );
		}

		public void SetActive(bool state)
		{
			gameObject.SetActive( state );
		}
	}
}