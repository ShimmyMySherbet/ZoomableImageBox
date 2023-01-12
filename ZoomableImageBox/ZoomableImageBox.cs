using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShimmyMySherbet.WinForms.ZoomableImgBox
{
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	public partial class ZoomableImageBox : Control
	{
		protected bool _MouseDown = false;
		protected Point _MouseStart = Point.Empty;
		protected float _startX;
		protected float _startY;


		/// <summary>
		/// Resets the Pan and Zoom parameters of the control
		/// </summary>
		public void Reset()
		{
			PanX = 0.5f;
			PanY = 0.5f;
			Zoom = 1f;
		}

		public ZoomableImageBox() : base()
		{
			SizeChanged += OnSizeChange;

			DoubleBuffered = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (Image is null)
			{
				return;
			}

			var sourceSize = ZoomMath.ScaleToEnapsulate(new SizeF(Width, Height), Image.Size);

			sourceSize = ZoomMath.DivideSize(sourceSize, Zoom);

			var sourceRect = ZoomMath.AlignRectangle(Image.Size, sourceSize, PanX, PanY);

			e.Graphics.DrawImage(Image, e.ClipRectangle, sourceRect, GraphicsUnit.Pixel);
		}

		private void OnSizeChange(object? sender, EventArgs e)
		{
			Invalidate();
		}


		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (e.Delta < 0)
			{
				ActiveControlStyle?.OnScrollUp(this, _ShiftDown, _ControlDown, _AltDown);
			}
			else if (e.Delta > 0)
			{
				ActiveControlStyle?.OnScrollDown(this, _ShiftDown, _ControlDown, _AltDown);
			}
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			ActiveControlStyle?.OnDoubleClick(this, _ShiftDown, _ControlDown, _AltDown);
			base.OnDoubleClick(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			_MouseDown = true;
			_MouseStart = e.Location;
			_startX = PanX;
			_startY = PanY;

			base.OnMouseDown(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			_MouseDown = false;
			_MouseStart = Point.Empty;

			base.OnMouseUp(e);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (_MouseDown)
			{
				var difX = e.X - _MouseStart.X;
				var difY = e.Y - _MouseStart.Y;

				var difXPerc = ((float)difX / Width) / Zoom;
				var difYPerc = ((float)difY / Height) / Zoom;

				PanX = _startX - difXPerc;
				PanY = _startY - difYPerc;

			}
			else
			{
				base.OnMouseMove(e);
			}
		}
	}
}
