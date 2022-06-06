namespace YoutubeConverter.Winforms
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    ///     Provides helper methods for Windows Forms Controls.
    /// </summary>
    internal static class ControlHelper
    {
        /// <summary>
        ///     Ensures thread synchronization on a Windows Forms Control by 
        ///     invoking the specified action if being called from a thread other 
        ///     than the main UI thread.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="action">The action to perform.</param>
        /// <exception cref="ArgumentNullException">Throws if the control is null.</exception>
        internal static void EnsureControlThreadSynchronization(this Control control, Action action)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }

            action.Invoke();
        }
    }
}
