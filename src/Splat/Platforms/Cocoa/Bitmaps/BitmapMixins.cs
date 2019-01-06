﻿#if UIKIT
using UIKit;
#else
using UIImage = AppKit.NSImage;
#endif

namespace Splat
{
    /// <summary>
    /// Extension methods to assist with dealing with Bitmaps.
    /// </summary>
    public static class BitmapMixins
    {
        /// <summary>
        /// Converts <see cref="IBitmap"/> to a native type.
        /// </summary>
        /// <param name="value">The bitmap to convert.</param>
        /// <returns>A <see cref="UIImage"/> bitmap.</returns>
        public static UIImage ToNative(this IBitmap value)
        {
            return ((CocoaBitmap)value).Inner;
        }

        /// <summary>
        /// Converts a <see cref="UIImage"/> to a splat <see cref="IBitmap"/>.
        /// </summary>
        /// <param name="value">The native bitmap to convert from.</param>
        /// <param name="copy">Whether to copy the android bitmap or not.</param>
        /// <returns>A <see cref="IBitmap"/> bitmap.</returns>
        public static IBitmap FromNative(this UIImage value, bool copy = false)
        {
            if (copy)
            {
                return new CocoaBitmap((UIImage)value.Copy());
            }

            return new CocoaBitmap(value);
        }
    }
}
