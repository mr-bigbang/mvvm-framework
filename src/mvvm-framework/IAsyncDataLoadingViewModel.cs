﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Baumann
{
    public interface IAsyncDataLoadingViewModel
    {
        /// <summary>
        /// Indicate wheater the ViewModel is currently loading data
        /// </summary>
        public bool IsLoading { get; }
        /// <summary>
        /// Event is raised when the data loading completes.
        /// The EventArgs indicate, whether there was a problem during data-loading.
        /// </summary>
        public event EventHandler<bool> DataLoaded;
        /// <summary>
        /// Start loading the data. This is normally called from outside the ViewModel.
        /// </summary>
        public Task InitialiseAsync();
    }

    internal sealed class AsyncDataLoadingViewModelExample : ViewModelBase, IAsyncDataLoadingViewModel
    {
        public AsyncDataLoadingViewModelExample() : base() { }

        // Should be ObservableCollection<User>
        private readonly List<string> _user = new List<string>();

        #region IAsyncDataLoadingViewModel
        public bool IsLoading { get; private set; } = true;

        public event EventHandler<bool> DataLoaded;

        // private, because class is sealed
        // protected virtual otherwise
        private void OnDataLoaded(bool success)
        {
            Log.Trace("ENTER OnDataLoaded(bool success)");
            Log.Trace("PARAM {0} = {1}", nameof(success), success);

            IsLoading = false;
            DataLoaded?.Invoke(this, success);
        }

        public async Task InitialiseAsync()
        {
            Log.Trace("ENTER InitialiseAsync()");

            // Load data from async source, like SQL-Server
            const string sqlQuery = @"SELECT [Name] FROM [dbo].[User];";
            using var conn = new SqlConnection("<Your connection string goes here>");
            using var cmd = new SqlCommand(sqlQuery, conn);
            await conn.OpenAsync();
            using var dr = await cmd.ExecuteReaderAsync();
            while (await dr.ReadAsync())
                _user.Add(dr.GetString(0));

            // After everything is loaded, raise the DataLoaded-event (and set IsLoading to false)
            OnDataLoaded(true);
        }
        #endregion
    }
}
