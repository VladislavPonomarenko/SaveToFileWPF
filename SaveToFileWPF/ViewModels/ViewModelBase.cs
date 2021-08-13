using Caliburn.Micro;
using SaveToFileWPF.Commands;

namespace SaveToFileWPF.Screens
{
    public abstract class ViewModelBase : Screen
    {
        private bool _isViewMode = true;
        public virtual bool IsViewMode
        {
            get => _isViewMode;
            set => Set(ref _isViewMode, value);
        }

        private bool _isValid = true;
        public virtual bool IsValid
        {
            get => _isValid;
            set
            {
                if (value)
                {
                    ValidationError = string.Empty;
                }
                Set(ref _isValid, value);
            }
        }

        private string _validationError = string.Empty;
        public string ValidationError
        {
            get => _validationError;
            set => Set(ref _validationError, value);
        }

        private bool _loading;
        public bool Loading
        {
            get => _loading;
            set => Set(ref _loading, value);
        }

        public RelayCommand ReloadCommand { get; set; }

        protected ViewModelBase()
        {
            ReloadCommand = new RelayCommand(OnReload, o => !Loading);
        }

        private void OnReload(object o)
        {
            LoadInternal();
        }

        protected virtual void Load()
        {
        }

        private void LoadInternal()
        {
            Loading = true;
            Load();
            Loading = false;
        }
    }
}
