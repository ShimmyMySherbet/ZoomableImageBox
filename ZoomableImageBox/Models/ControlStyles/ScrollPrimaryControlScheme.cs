namespace ShimmyMySherbet.WinForms.ZoomableImageBox.Models.ControlStyles
{
	/// <summary>
	/// A ZoomablePictureBox Control Scheme that prioritizes scrolling over Zooming.
	/// </summary>
	public class ScrollPrimaryControlScheme : IZoomablePictureBoxControlScheme
	{
		public void OnDoubleClick(ZoomableImageBox sender, bool shift, bool control, bool alt)
		{
			if (control || shift)
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
				// No Control
			}
			else if (control)
			{
				sender.Zoom += 0.1f;
			}
			else if (shift)
			{
				sender.PanX -= 0.1f;
			}
			else
			{
				sender.PanY -= 0.1f;
			}
		}

		public void OnScrollUp(ZoomableImageBox sender, bool shift, bool control, bool alt)
		{
			if (control && shift)
			{
				// No Control
			}
			else if (control)
			{
				sender.Zoom -= 0.1f;
			}
			else if (shift)
			{
				sender.PanX += 0.1f;
			}
			else
			{
				sender.PanY += 0.1f;
			}
		}
	}
}
