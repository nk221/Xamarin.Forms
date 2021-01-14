using System;
using Xamarin.Platform;

namespace Xamarin.Forms
{
	public sealed class RowDefinition : BindableObject, IDefinition, IGridRowDefinition
	{
		public static readonly BindableProperty HeightProperty = BindableProperty.Create("Height", typeof(GridLength), typeof(RowDefinition), new GridLength(1, GridUnitType.Star),
			propertyChanged: (bindable, oldValue, newValue) => ((RowDefinition)bindable).OnSizeChanged());

		public RowDefinition()
		{
			MinimumHeight = -1;
		}

		public GridLength Height
		{
			get { return (GridLength)GetValue(HeightProperty); }
			set { SetValue(HeightProperty, value); }
		}

		internal double ActualHeight { get; set; }

		internal double MinimumHeight { get; set; }

		double IGridRowDefinition.ActualHeight => ActualHeight;

		public event EventHandler SizeChanged;

		void OnSizeChanged()
		{
			EventHandler eh = SizeChanged;
			if (eh != null)
				eh(this, EventArgs.Empty);
		}
	}
}