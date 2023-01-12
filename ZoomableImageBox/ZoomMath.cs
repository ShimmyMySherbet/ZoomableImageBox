using System;
using System.Drawing;

namespace ShimmyMySherbet.WinForms.ZoomableImgBox
{
	/// <summary>
	/// Provides a collection of math functions used by <seealso cref="ZoomableImageBox"/>
	/// </summary>
	public static class ZoomMath
	{
		/// <summary>
		/// Divides the width and height components of <seealso cref="SizeF"/> by <paramref name="dividend"/>
		/// </summary>
		/// <param name="dividend"></param>
		/// <returns>The resulting size</returns>
		public static SizeF DivideSize(SizeF size, float dividend)
		{
			var width = size.Width / dividend;
			var height = size.Height / dividend;

			return new SizeF(width, height);
		}

		/// <summary>
		/// Alligns the <paramref name="child"/> rectangle inside of <paramref name="parent"/>
		/// based on the <paramref name="x"/> and <paramref name="y"/> parameters
		/// </summary>
		/// <param name="parent">The parent rectangle area</param>
		/// <param name="child">The child rectangle to allign</param>
		/// <param name="x">X allignment value between 0 and 1</param>
		/// <param name="y">Y allignment value bewteen 0 and 1</param>
		/// <returns>A rectangle that includes the <paramref name="child"/> size, with it's calculated location</returns>
		public static RectangleF AlignRectangle(SizeF parent, SizeF child, float x, float y)
		{
			// the child should be moved so these coordinates are in the middle of it
			var focusX = parent.Width * x;
			var focusY = parent.Height * y;

			var childMidX = child.Width / 2f;
			var childMidY = child.Height / 2f;

			var parentX = focusX - childMidX;
			var parentY = focusY - childMidY;

			return new RectangleF(new PointF(parentX, parentY), child);
		}


		/// <summary>
		/// Scales <paramref name="child"/> to fit within <paramref name="parent"/>
		/// </summary>
		/// <param name="parent">The bounding/limit size</param>
		/// <param name="child">The size to scale to the parent</param>
		public static SizeF ScaleToEnapsulate(SizeF parent, SizeF child)
		{
			var WidthRatio = child.Width / parent.Width;
			var HeightRatio = child.Height / parent.Height;

			var scaler = Math.Max(WidthRatio, HeightRatio);

			var width = parent.Width * scaler;
			var height = parent.Height * scaler;

			return new SizeF(width, height);
		}


		/// <summary>
		/// Basic clamp function, since <seealso cref="Math"/> doesn't provide an overload for <seealso cref="float"/>
		/// </summary>
		/// <param name="value">The value to clamp</param>
		/// <param name="min">The minimum allowed value</param>
		/// <param name="max">The maximum allowed value</param>
		/// <returns>The clamped value</returns>
		public static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				return min;
			}
			else if (value > max)
			{
				return max;
			}
			else
			{
				return value;
			}
		}

	}
}
