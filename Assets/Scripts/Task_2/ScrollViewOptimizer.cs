using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Task_2
{
	public class ScrollViewOptimizer : MonoBehaviour
	{
		private const int InstanceCount = 9;
		
		[Header("Settings")]
		[SerializeField] private int _count;

		[SerializeField] private float _spacing;
		[SerializeField] private float _leftPadding;
		[SerializeField] private float _rightPadding;
		[SerializeField] private float _heightOffset;

		[Header("Refs")]
		[SerializeField] private Item _itemPrefab;
		[SerializeField] private Sprite[] _sprites;
		[SerializeField] private RectTransform _content;

		private readonly List<Item> _instancedItems = new();
		private readonly List<ItemModel> _itemModels = new();
		private float _contentWidth;
		private float _itemWidth;
		private int _lastInd = -1;

		private void Start()
		{
			CalculateContentWidth();
			ResetContentScroll();
			CreateItemModels();
			StartupItems();
		}

		private void Update()
		{
			float curOffset = -_content.anchoredPosition.x;		// Natural content offset
			curOffset -= _leftPadding;							// Skip padding
			curOffset += _spacing;								// Skip first spacing
			
			int curInd = Mathf.FloorToInt( curOffset / ( _itemWidth + _spacing ) );
			curInd = Mathf.Clamp( curInd, 0, _count - 1 );

			if ( _lastInd == curInd )
				return;
			
			_lastInd = curInd;
			
			RefreshItemsPositions( curInd );
			
			// Debug.Log( $"Cur Index: {curInd}" );
		}

		private void RefreshItemsPositions(int leftInd)
		{
			for (int i = 0; i < _instancedItems.Count; i++)
			{
				int inx = leftInd + i;
				Item item = _instancedItems[i];
				bool needShow = inx < _count;
				
				item.SetActive( needShow );

				if ( !needShow )
					return;

				item.SetItem( _itemModels[inx] );
				
				item.SetPosition(
					_leftPadding + inx * (_itemWidth + _spacing), 
					_heightOffset
				);
			}
		}

		private void CalculateContentWidth()
		{
			Vector2 sizeDelta = _itemPrefab.GetComponent<RectTransform>().sizeDelta;

			_itemWidth = sizeDelta.x;
			_contentWidth = _itemWidth * _count
			                + _leftPadding
			                + _rightPadding
			                + _spacing * ( _count - 1 );
			
			_content.sizeDelta = new Vector2( _contentWidth, sizeDelta.y );
		}

		private void ResetContentScroll()
		{
			_content.anchoredPosition *= Vector2.up;
		}

		private void CreateItemModels()
		{
			for (int i = 0; i < _count; i++)
			{
				_itemModels.Add
				(
					new ItemModel
					(
						_sprites[Random.Range( 0, _sprites.Length )],
						$"Item {i + 1}"
					)
				);
			}
		}

		private void StartupItems()
		{
			for (int i = 0; i < InstanceCount; i++)
			{
				Item item = Instantiate( _itemPrefab, _content );
				item.SetItem( _itemModels[i] );

				_instancedItems.Add( item );

				item.SetPosition(
					_leftPadding + i * (_itemWidth + _spacing), 
					_heightOffset
				);
			}
		}
	}
}