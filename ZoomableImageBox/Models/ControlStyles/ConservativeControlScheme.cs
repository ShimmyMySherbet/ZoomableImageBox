namespace ShimmyMySherbet.WinForms.ZoomableImageBox.Models.ControlStyles
{
	/// <summary>
	/// A control scheme that avoid accidental scrolling.
	/// </summary>
	public class ConservativeControlScheme : IZoomablePictureBoxControlScheme
	{
		public void OnDoubleClick(ZoomableImageBox sender, bool shift, bool control, bool alt)
		{
			if (control && shift)
			{
				sender.PanX = 0.5f;
				sender.PanY = 0.5f;
				sender.Zoom = 1f;
			}
		}

		public void OnScrollDown(ZoomableImageBox sender, bool shift, bool control, bool alt)
		{
			if (control && shift)
			{
				sender.PanX -= 0.1f;

			}
			else if (control)
			{
				sender.Zoom += 0.1f;

			}
			else if (shift)
			{
				sender.PanY -= 0.1f;

			}
			else
			{
				// No control
			}
		}

		public void OnScrollUp(ZoomableImageBox sender, bool shift, bool control, bool alt)
		{
			if (control && shift)
			{
				sender.PanX += 0.1f;

			}
			else if (control)
			{
				sender.Zoom -= 0.1f;

			}
			else if (shift)
			{
				sender.PanY += 0.1f;

			}
			else
			{
				// No control
			}
		}
	}
}
