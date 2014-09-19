//-----------------------------------------------------------------------
// <copyright file="ExtendedNotifyCollectionChangedEventArgs.cs" company="MyToolkit">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>http://mytoolkit.codeplex.com/license</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyToolkit.Collections
{
    public class ExtendedNotifyCollectionChangedEventArgs<T> : PropertyChangedEventArgs, IExtendedNotifyCollectionChangedEventArgs
    {
#if !LEGACY
        public ExtendedNotifyCollectionChangedEventArgs(IReadOnlyList<T> addedItems, IReadOnlyList<T> removedItems, IReadOnlyList<T> oldCollection)
            : base(null)
        {
            AddedItems = addedItems;
            RemovedItems = removedItems;
            OldCollection = oldCollection; 
        }

        /// <summary>Gets or sets the list of added items. </summary>
        public IReadOnlyList<T> AddedItems { get; private set; }

        /// <summary>Gets or sets the list of removed items. </summary>
        public IReadOnlyList<T> RemovedItems { get; private set; }

        /// <summary>Gets the previous collection (only provided when enabled in the <see cref="ExtendedObservableCollection{T}"/> object). </summary>
        public IReadOnlyList<T> OldCollection { get; private set; }

#else
        public ExtendedNotifyCollectionChangedEventArgs(IList<T> addedItems, IList<T> removedItems, IList<T> oldCollection)
            : base(null)
        {
            AddedItems = addedItems;
            RemovedItems = removedItems;
            OldCollection = oldCollection;
        }

        /// <summary>
        /// Gets or sets the list of added items. 
        /// </summary>
        public IList<T> AddedItems { get; private set; }

        /// <summary>
        /// Gets or sets the list of removed items. 
        /// </summary>
        public IList<T> RemovedItems { get; private set; }

        /// <summary>
        /// Gets the previous collection (only provided when enabled in the <see cref="ExtendedObservableCollection{T}"/> object). 
        /// </summary>
        public IList<T> OldCollection { get; private set; }

#endif

        IEnumerable IExtendedNotifyCollectionChangedEventArgs.RemovedItems
        {
            get { return RemovedItems; }
        }

        IEnumerable IExtendedNotifyCollectionChangedEventArgs.AddedItems
        {
            get { return AddedItems; }
        }

        IEnumerable IExtendedNotifyCollectionChangedEventArgs.OldCollection
        {
            get { return OldCollection; }
        }
    }

    public interface IExtendedNotifyCollectionChangedEventArgs
    {
        /// <summary>Gets the list of added items. </summary>
        IEnumerable AddedItems { get; }

        /// <summary>Gets the list of removed items. </summary>
        IEnumerable RemovedItems { get; }

        /// <summary>Gets the previous collection (only provided when enabled in the <see cref="ExtendedObservableCollection{T}"/> object). </summary>
        IEnumerable OldCollection { get; }
    }
}