namespace ShimmyMySherbet.WinForms.ZoomableImageBox.Models
{
	public interface IZoomablePictureBoxControlScheme
	{
		void OnScrollDown(ZoomableImageBox sender, bool shift, bool control, bool alt);
		void OnScrollUp(ZoomableImageBox sender, bool shift, bool control, bool alt);
		void OnDoubleClick(ZoomableImageBox sender, bool shift, bool control, bool alt);
	}
}
