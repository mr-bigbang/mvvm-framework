# Basic classes for MVVM projects
This repository includes some classes I often use in MVVM projects. The main focus is on .NET Core.

## Available classes

### ViewModelBase
Base class for all ViewModel. This class implements the `INotifyPropertyChanged` interface required for binding. Includes a NLog `Log` property (for logging) as well as `SetValue` methods for easily raising the `PropertyChanged` event.

### ServiceBase
Base class for all services. Includes a NLog `Log` property (for logging).

#### SqlServiceBase
Base class for services that access Microsoft SQL-Server databases. Derives from `ServiceBase`. Includes a `ConnectionStringR` and `ConnectionStringW` property with the `ApplicationIntent` set accordingly.

#### SqliteServiceBase
Base class for services that access SQLite3 database-files. Derives from `ServiceBase`. Includes a `ConnectionString` property with the `PRAGMA foreign_keys` set to true.

## Available interfaces

### IDataLoadingViewModel
Provide common properties and methods for data-loading ViewModel. The method `Initialise()` should initiate the loading and is (usually) being called from outside the ViewModel. The property `IsLoading` indicates, whether all data has been loaded. After all data has been loaded, the event `DataLoaded` is raised, indicating, whether the data was loaded successfully.

### IAsyncDataLoadingViewModel
Basically the same as `IDataLoadingViewModel`, but instead of `Initialise()` you can await `InitialiseAsync()`.
