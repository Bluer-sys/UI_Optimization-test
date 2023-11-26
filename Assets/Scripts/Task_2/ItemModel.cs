using UnityEngine;

namespace Task_2
{
	public struct ItemModel
	{
		public readonly string Text;
		public readonly Sprite Sprite;

		public ItemModel(Sprite sprite, string text)
		{
			Sprite = sprite;
			Text = text;
		}
	}
}