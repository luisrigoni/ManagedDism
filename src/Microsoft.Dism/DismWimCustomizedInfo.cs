﻿using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;

namespace Microsoft.Dism
{
    public static partial class DismApi
    {
        /// <summary>
        /// Describes a Windows® Imaging Format (WIM) file.
        /// </summary>
        /// <remarks>
        /// <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/hh824792.aspx"/>
        /// typedef struct _DismWimCustomizedInfo
        /// {
        ///     UINT Size;
        ///     UINT DirectoryCount;
        ///     UINT FileCount;
        ///     SYSTEMTIME CreatedTime;
        ///     SYSTEMTIME ModifiedTime;
        /// } DismWimCustomizedInfo;
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
        internal struct DismWimCustomizedInfo_
        {
            /// <summary>
            /// The size of the DismWimCustomizedInfo structure.
            /// </summary>
            public UInt32 Size;

            /// <summary>
            /// The number of directories in the image.
            /// </summary>
            public UInt32 DirectoryCount;

            /// <summary>
            /// The number of files in the image.
            /// </summary>
            public UInt32 FileCount;

            /// <summary>
            /// The time that the image file was created.
            /// </summary>
            public SYSTEMTIME CreatedTime;

            /// <summary>
            /// The time that the image file was last modified.
            /// </summary>
            public SYSTEMTIME ModifiedTime;
        }
    }

    /// <summary>
    /// Represents a Windows® Imaging Format (WIM) file.
    /// </summary>
    public sealed class DismWimCustomizedInfo : IEquatable<DismWimCustomizedInfo>
    {
        private readonly DismApi.DismWimCustomizedInfo_ _wimCustomizedInfo;

        /// <summary>
        /// Initializes a new instance of the DismWimCustomizedInfo class.
        /// </summary>
        /// <param name="wimCustomizedInfoPtr">A pointer to a native <see cref="DismApi.DismWimCustomizedInfo_"/> struct.</param>
        internal DismWimCustomizedInfo(IntPtr wimCustomizedInfoPtr)
            : this(wimCustomizedInfoPtr.ToStructure<DismApi.DismWimCustomizedInfo_>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the DismWimCustomizedInfo class.
        /// </summary>
        /// <param name="wimCustomizedInfo">A native <see cref="DismApi.DismWimCustomizedInfo_"/> struct to copy data from.</param>
        internal DismWimCustomizedInfo(DismApi.DismWimCustomizedInfo_ wimCustomizedInfo)
        {
            _wimCustomizedInfo = wimCustomizedInfo;
        }

        /// <summary>
        /// Gets the time that the image file was created.
        /// </summary>
        public DateTime CreatedTime => _wimCustomizedInfo.CreatedTime;

        /// <summary>
        /// Gets the number of directories in the image.
        /// </summary>
        public long DirectoryCount => _wimCustomizedInfo.DirectoryCount;

        /// <summary>
        /// Gets the number of files in the image.
        /// </summary>
        public long FileCount => _wimCustomizedInfo.FileCount;

        /// <summary>
        /// Gets the time that the image file was last modified.
        /// </summary>
        public DateTime ModifiedTime => _wimCustomizedInfo.ModifiedTime;

        /// <summary>
        /// Gets the size of the customized info.
        /// </summary>
        public long Size => _wimCustomizedInfo.Size;

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as DismWimCustomizedInfo);
        }

        /// <summary>
        /// Determines whether the specified <see cref="DismWimCustomizedInfo"/> is equal to the current <see cref="DismWimCustomizedInfo"/>.
        /// </summary>
        /// <param name="wimCustomizedInfo">The <see cref="DismWimCustomizedInfo"/> object to compare with the current object.</param>
        /// <returns>true if the specified <see cref="DismWimCustomizedInfo"/> is equal to the current <see cref="DismWimCustomizedInfo"/>; otherwise, false.</returns>
        public bool Equals(DismWimCustomizedInfo wimCustomizedInfo)
        {
            return wimCustomizedInfo != null
                   && CreatedTime == wimCustomizedInfo.CreatedTime
                   && DirectoryCount == wimCustomizedInfo.DirectoryCount
                   && FileCount == wimCustomizedInfo.FileCount
                   && ModifiedTime == wimCustomizedInfo.ModifiedTime
                   && Size == wimCustomizedInfo.Size;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>A hash code for the current <see cref="T:System.Object"/>.</returns>
        public override int GetHashCode()
        {
            return CreatedTime.GetHashCode()
                ^ DirectoryCount.GetHashCode()
                ^ FileCount.GetHashCode()
                ^ ModifiedTime.GetHashCode()
                ^ Size.GetHashCode();
        }
    }
}