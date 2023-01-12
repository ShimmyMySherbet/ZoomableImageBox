using System.ComponentModel;

namespace ShimmyMySherbet.WinForms.ZoomableImageBox.Models
{
	public enum EZoomControlScheme
	{
		/// <summary>
		/// Scroll is prioritized over zoom
		/// </summary>
		[Description("Control scheme that prioritises scrolling over zooming")]
		ScrollPrimary,
		/// <summary>
		/// Zoom is prioritized over scroll
		/// </summary>
		[Description("Control scheme that prioritises zooming over scrolling")]
		ZoomPrimary,

		/// <summary>
		/// Control scheme that avoids accidental scrolling, requiring Shift and/or CTRL to take effect
		/// </summary>
		[Description("Control scheme that avoids accidental scrolling, requiring Shift and/or CTRL to take effect")]
		Conservative,

		/// <summary>
		/// No image controls, acts like a picture box.
		/// </summary>
		[Description("Disables image controls, causing the ZoomableImageBox to act like a PictureBox")]
		None,

		/// <summary>
		/// Uses a custom control style.
		/// </summary>
		[Description("Custom control scheme")]
		Custom
	}
}
