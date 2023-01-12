using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ShimmyMySherbet.WinForms.ZoomableImgBox.Models;
using ShimmyMySherbet.WinForms.ZoomableImgBox.Models.ControlStyles;

namespace ShimmyMySherbet.WinForms.ZoomableImgBox
{
	public partial class ZoomableImageBox
	{
		#region "Core Parameters"

		/// <summary>
		/// The image to display
		/// </summary>
		[Description("The image to display")]
		[DefaultValue(null)]
		[Category("Appearance")]
		public Image? Image
		{
			get => _Image;
			set
			{
				_Image = value;
				Invalidate();
			}
		}

		/// <summary>
		/// The level of Zoom on the image.
		/// </summary>
		[Description("The level of Zoom on the image.")]
		[DefaultValue(1f)]
		[Category("Behavior")]
		public float Zoom
		{
			get => _Zoom;
			set
			{
				_Zoom = value;
				Invalidate();
			}
		}

		/// <summary>
		/// The left-right scrolling of the image. Between 1 and 0
		/// </summary>
		[Description("The left-right scrolling of the image. Between 1 and 0")]
		[DefaultValue(0.5f)]
		[Category("Behavior")]
		public float PanX
		{
			get => _PanX;
			set
			{
				_PanX = ZoomMath.Clamp(value, 0f, 1f);
				Invalidate();
			}
		}

		/// <summary>
		/// The up-down scrolling of the image. Between 1 and 0
		/// </summary>
		[Description("The up-down scrolling of the image. Between 1 and 0")]
		[DefaultValue(0.5f)]
		[Category("Behavior")]
		public float PanY
		{
			get => _PanY;
			set
			{
				_PanY = ZoomMath.Clamp(value, 0f, 1f);
				Invalidate();
			}
		}

		/// <summary>
		/// Enables/Disables drag panning, where the user can drag the image on the screen to move it
		/// </summary>
		[Description("Enables drag panning, where the user can drag the image on the screen to move it")]
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool DragPanning { get; set; } = true;

		protected Image? _Image;
		protected float _PanY = 0.5f;
		protected float _PanX = 0.5f;
		protected float _Zoom = 1;

		#endregion

		#region "ControlStyles"

		protected IZoomablePictureBoxControlScheme _ControlsScrollPrimary = new ScrollPrimaryControlScheme();
		protected IZoomablePictureBoxControlScheme _ControlsZoomPrimary = new ZoomPrimaryControlScheme();
		protected IZoomablePictureBoxControlScheme _ControlsConservative = new ConservativeControlScheme();


		/// <summary>
		/// Sets the control style for this Zoomable Image Box
		/// </summary>
		[Description("Sets the control scheme for this Zoomable Image Box")]
		[Category("Behavior")]
		[DefaultValue(EZoomControlScheme.ScrollPrimary)]
		public EZoomControlScheme ControlScheme { get; set; } = EZoomControlScheme.ScrollPrimary;

		/// <summary>
		/// The custom control style to use. Requires <seealso cref="ControlScheme"/> to be set to <seealso cref="EZoomControlScheme.Custom"/>
		/// </summary>
		[Category("Behavior")]
		[Description("The custom control style to use. Requires ControlStyle to be set to Custom")]
		[DefaultValue(null)]
		public IZoomablePictureBoxControlScheme? CustomControlStyle { get; set; }

		/// <summary>
		/// The currently used control style
		/// </summary>
		/// 
		protected IZoomablePictureBoxControlScheme? ActiveControlStyle
		{
			get
			{
				switch (ControlScheme)
				{
					case EZoomControlScheme.None:
						return null;

					case EZoomControlScheme.ScrollPrimary:
						return _ControlsScrollPrimary;

					case EZoomControlScheme.ZoomPrimary:
						return _ControlsZoomPrimary;

					case EZoomControlScheme.Conservative:
						return _ControlsConservative;

					case EZoomControlScheme.Custom:
						return CustomControlStyle;

					default:
						return null;
				}
			}
		}
		#endregion


		#region "KeyboardInput"

		private bool _ControlDown = false;
		private bool _ShiftDown = false;
		private bool _AltDown = false;

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ControlKey)
			{
				_ControlDown = true;
			}
			else if (e.KeyCode == Keys.ShiftKey)
			{
				_ShiftDown = true;
			}
			else if (e.KeyCode == Keys.Alt)
			{
				_AltDown = true;
			}
			base.OnKeyDown(e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.ControlKey)
			{
				_ControlDown = false;
			}
			else if (e.KeyCode == Keys.ShiftKey)
			{
				_ShiftDown = false;
			}
			else if (e.KeyCode == Keys.Alt)
			{
				_AltDown = false;
			}
			base.OnKeyUp(e);
		}
		#endregion
	}
}
