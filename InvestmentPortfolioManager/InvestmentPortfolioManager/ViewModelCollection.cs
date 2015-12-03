// --------------------------------------------------------------------------------
// <copyright file="ViewModelCollection.cs" company="Alex Kozlov">
//   Copyright (c) Alex Kozlov. All rights reserved.
// </copyright>
// <summary>
//   Observable collection of ViewModels that pushes changes to a related collection of models.
// </summary>
// --------------------------------------------------------------------------------
namespace InvestmentPortfolioManager
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;

    /// <summary>
    /// Observable collection of ViewModels that pushes changes to a related collection of models.
    /// </summary>
    /// <typeparam name="TViewModel">
    /// Type of ViewModels in collection.
    /// </typeparam>
    /// <typeparam name="TModel">
    /// Type of models in underlying collection.
    /// </typeparam>
    public class ViewModelCollection<TViewModel, TModel> : ObservableCollection<TViewModel>
        where TViewModel : class, IViewModel<TModel> where TModel : class
    {
        #region Fields

        private readonly object context;

        private readonly ICollection<TModel> models;

        private readonly Func<TModel, object, TViewModel> viewModelProvider;

        private bool suspendUpdates;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelCollection{TViewModel,TModel}"/> class. 
        /// Constructor.
        /// </summary>
        /// <param name="models">
        /// List of models to synch with.
        /// </param>
        /// <param name="viewModelProvider">
        /// View model provider.
        /// </param>
        /// <param name="context">
        /// View model context.
        /// </param>
        /// <param name="autoFetch">
        /// Determines whether the collection of ViewModels should be
        /// fetched from the model collection on construction.
        /// </param>
        public ViewModelCollection(
            ICollection<TModel> models, 
            Func<TModel, object, TViewModel> viewModelProvider, 
            object context = null, 
            bool autoFetch = true)
        {
            this.models = models;
            this.context = context;

            this.viewModelProvider = viewModelProvider;

            // Register change handling for synchronization
            // from ViewModels to Models
            this.CollectionChanged += this.ViewModelCollectionChanged;

            // If model collection is observable register change
            // handling for synchronization from Models to ViewModels
            if (models is ObservableCollection<TModel>)
            {
                var observableModels = models as ObservableCollection<TModel>;
                observableModels.CollectionChanged += this.ModelCollectionChanged;
            }

            // Fecth ViewModels
            if (autoFetch)
            {
                this.FetchFromModels();
            }
        }

        #endregion

        #region Public Events

        /// <summary>
        /// CollectionChanged event of the ViewModelCollection.
        /// </summary>
        public override sealed event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                base.CollectionChanged += value;
            }

            remove
            {
                base.CollectionChanged -= value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds a new ViewModel for the specified Model instance.
        /// </summary>
        /// <param name="model">
        /// Model to create ViewModel for.
        /// </param>
        public void AddForModel(TModel model)
        {
            this.Add(this.CreateViewModel(model));
        }

        /// <summary>
        /// Adds a new ViewModel with a new model instance of the specified type,
        /// which is the ModelType or derived from the Model type.
        /// </summary>
        /// <typeparam name="TSpecificModel">
        /// Type of Model to add ViewModel for.
        /// </typeparam>
        public void AddNew<TSpecificModel>() where TSpecificModel : TModel, new()
        {
            var m = new TSpecificModel();
            this.Add(this.CreateViewModel(m));
        }

        /// <summary>
        /// Load VM collection from model collection.
        /// </summary>
        public void FetchFromModels()
        {
            // Deactivate change pushing
            this.suspendUpdates = true;

            // Clear collection
            this.Clear();

            // Create and add new VM for each model
            foreach (var model in this.models)
            {
                this.AddForModel(model);
            }

            // Reactivate change pushing
            this.suspendUpdates = false;
        }

        #endregion

        #region Methods

        private void AddIfNotNull(TViewModel viewModel)
        {
            if (viewModel != null)
            {
                this.Items.Add(viewModel);
            }
        }

        private TViewModel CreateViewModel(TModel model)
        {
            return this.viewModelProvider(model, this.context);
        }

        private TViewModel GetViewModelOfModel(TModel model)
        {
            return this.Items.OfType<IViewModel<TModel>>().FirstOrDefault(v => v.IsViewModelOf(model)) as TViewModel;
        }

        private void ModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.suspendUpdates)
            {
                return;
            }

            this.suspendUpdates = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var m in e.NewItems.OfType<TModel>())
                    {
                        this.AddIfNotNull(this.CreateViewModel(m));
                    }

                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var m in e.OldItems.OfType<TModel>())
                    {
                        this.RemoveIfContains(this.GetViewModelOfModel(m));
                    }

                    break;

                case NotifyCollectionChangedAction.Reset:
                    this.Clear();
                    this.FetchFromModels();
                    break;
            }

            this.suspendUpdates = false;
        }

        private void RemoveIfContains(TViewModel viewModel)
        {
            this.Items.Remove(viewModel);
        }

        private void ViewModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Return if synchronization is internally disabled
            if (this.suspendUpdates)
            {
                return;
            }

            // Disable synchronization
            this.suspendUpdates = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var m in e.NewItems.OfType<IViewModel<TModel>>().Select(v => v.Model))
                    {
                        this.models.Add(m);
                    }

                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var m in e.OldItems.OfType<IViewModel<TModel>>().Select(v => v.Model))
                    {
                        this.models.Remove(m);
                    }

                    break;

                case NotifyCollectionChangedAction.Reset:
                    this.models.Clear();
                    foreach (var m in e.NewItems.OfType<IViewModel<TModel>>().Select(v => v.Model))
                    {
                        this.models.Add(m);
                    }

                    break;
            }

            // Enable synchronization
            this.suspendUpdates = false;
        }

        #endregion
    }
}