using System;
using System.Collections.Generic;
using MonoTouch.UIKit;

namespace Cnet.iOS
{
	public class ListPickerViewModel<TItem> : UIPickerViewModel
	{
		public event EventHandler<EventArgs> ValueChanged;

		public TItem SelectedItem { get; private set; }

		IList<TItem> _items;
		public IList<TItem> Items
		{
			get { return _items; }
			set { _items = value; Selected(null, 0, 0); }
		}

		public ListPickerViewModel()
		{
		}

		public ListPickerViewModel(IList<TItem> items)
		{
			Items = items;
		}

		public override int GetRowsInComponent(UIPickerView picker, int component)
		{
			if (NoItem())
				return 1;
			return Items.Count;
		}

		public override string GetTitle(UIPickerView picker, int row, int component)
		{
			if (NoItem(row))
				return "";
			var item = Items[row];
			return GetTitleForItem(item);
		}

		public override void Selected(UIPickerView picker, int row, int component)
		{
			if (NoItem(row))
				SelectedItem = default(TItem);
			else
				SelectedItem = Items[row];

			if (ValueChanged != null)
				ValueChanged (this, new EventArgs ());
		}

		public override int GetComponentCount(UIPickerView picker)
		{
			return 1;
		}

		public virtual string GetTitleForItem(TItem item)
		{
			return item.ToString();
		}

		bool NoItem(int row = 0)
		{
			return Items == null || row >= Items.Count;
		}
	}
}

