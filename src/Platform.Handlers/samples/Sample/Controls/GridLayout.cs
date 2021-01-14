﻿using System.Collections.Generic;
using Xamarin.Platform;
using Xamarin.Platform.Layouts;

namespace Sample
{
	public class GridLayout : Layout, IGridLayout
	{
		List<IGridRowDefinition> _rowDefinitions = new List<IGridRowDefinition>();
		List<IGridColumnDefinition> _columnDefinitions = new List<IGridColumnDefinition>();

		public IReadOnlyList<IGridRowDefinition> RowDefinitions => _rowDefinitions;
		public IReadOnlyList<IGridColumnDefinition> ColumnDefinitions => _columnDefinitions;

		public double RowSpacing { get; set; }
		public double ColumnSpacing { get; set; }

		Dictionary<IView, GridInfo> _viewInfo = new Dictionary<IView, GridInfo>();

		public int GetColumn(IView view)
		{
			return _viewInfo[view].Col;
		}

		public int GetColumnSpan(IView view)
		{
			return _viewInfo[view].ColSpan;
		}

		public int GetRow(IView view)
		{
			return _viewInfo[view].Row;
		}

		public int GetRowSpan(IView view)
		{
			return _viewInfo[view].RowSpan;
		}

		protected override ILayoutManager CreateLayoutManager() => new GridLayoutManager(this);

		public void AddRowDefinition(IGridRowDefinition gridRowDefinition) 
		{
			_rowDefinitions.Add(gridRowDefinition);
		}
		
		public void AddColumnDefinition(IGridColumnDefinition gridColumnDefinition)
		{
			_columnDefinitions.Add(gridColumnDefinition);
		}

		public void SetRow(IView view, int row)
		{
			if (_viewInfo.TryGetValue(view, out GridInfo gridInfo))
			{
				gridInfo.Row = row;
			}
			else
			{
				_viewInfo[view] = new GridInfo { Row = row };
			}
		}

		public void SetRowSpan(IView view, int span)
		{
			if (_viewInfo.TryGetValue(view, out GridInfo gridInfo))
			{
				gridInfo.RowSpan = span;
			}
			else
			{
				_viewInfo[view] = new GridInfo { RowSpan = span };
			}
		}

		public void SetColumn(IView view, int col)
		{
			if (_viewInfo.TryGetValue(view, out GridInfo gridInfo))
			{
				gridInfo.Col = col;
			}
			else
			{
				_viewInfo[view] = new GridInfo { Col = col };
			}
		}

		public void SetColumnSpan(IView view, int span)
		{
			if (_viewInfo.TryGetValue(view, out GridInfo gridInfo))
			{
				gridInfo.ColSpan = span;
			}
			else
			{
				_viewInfo[view] = new GridInfo { ColSpan = span };
			}
		}

		class GridInfo
		{
			public int Row { get; set; }
			public int Col { get; set; }
			public int RowSpan { get; set; } = 1;
			public int ColSpan { get; set; } = 1;
		}
	}
}
