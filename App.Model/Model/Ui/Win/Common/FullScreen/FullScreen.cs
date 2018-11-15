using System; using App.Model;
using System.Drawing;
using System.Windows.Forms;

namespace FullScreenMode
{
	/// <summary>
	/// This class will help you to hide or show 
    /// a winform in full screen mode. 
    /// Any one can use this source code without restriction.
    /// I'm not responsible for any error.
 	/// </summary>
	public class FullScreen
	{
        private Form                _Form;
		private FormWindowState     _cWindowState;
		private FormBorderStyle     _cBorderStyle;
		private Rectangle           _cBounds;
        private bool                _FullScreen;

		/// <summary>
		/// Full screen constructor.
		/// </summary>
		/// <param name="form">The WinForm to be show or hide as full screen</param>
		public FullScreen(Form form)
		{
			_Form           = form;            
            _FullScreen     = false;
		}

        /// <summary>
		/// Show or Hide your WinForm in full screen mode.
		/// </summary>
		private void ScreenMode()
		{
            
            // set full screen
            if (!_FullScreen)
			{
                // Get the WinForm properties
				_cBorderStyle               = _Form.FormBorderStyle;
				_cBounds	                = _Form.Bounds;
				_cWindowState               = _Form.WindowState;

                // set to false to avoid site effect
				_Form.Visible			    = false;

				//HandleTaskBar.hideTaskBar();
				
                // set new properties
				_Form.FormBorderStyle		= FormBorderStyle.None;
				_Form.WindowState			= FormWindowState.Maximized;
				
				_Form.Visible				= true;
                _FullScreen                 = true;
			}
            else  // reset full screen
            {
                // reset the normal WinForm properties
                // always set WinForm.Visible to false to avoid site effect
                _Form.Visible               = false;
                _Form.WindowState           = _cWindowState;
                _Form.FormBorderStyle       = _cBorderStyle;
                _Form.Bounds                = _cBounds;

                //HandleTaskBar.showTaskBar();

                _Form.Visible               = true;

                // Not in full screen mode
                _FullScreen                 = false;
            }
		}

        /// <summary>
        /// Show or hide full screen mode
        /// </summary>
        public void ShowFullScreen()
        {
            ScreenMode();
        }
        /// <summary>
        /// You can use this to reset the Taskbar in case of error.
        /// I don't want to handle exception in this class.
        /// You can change it if you like!
        /// </summary>
        public void ResetTaskBar()
        {
            //HandleTaskBar.showTaskBar();
        }
    }
}
