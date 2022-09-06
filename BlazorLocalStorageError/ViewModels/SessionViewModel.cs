using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BlazorLocalStorageError.Data;

namespace BlazorLocalStorageError.ViewModels
{
    public class SessionViewModel
    {
        public ILocalStorageService LocalStorage;
        public ISessionStorageService SessionStorage;

        public SessionViewModel(
            ILocalStorageService localStorage,
            ISessionStorageService sessionStorage
        )
        {
            LocalStorage = localStorage;
            SessionStorage = sessionStorage;
        }

        public async Task Init()
        {
            await GetLocalStorage();

            IsLoading = false;
        }

        public event Action? OnChange;
        public void NotifyStateChanged() => OnChange?.Invoke();

        public string SessionID { get; set; } = Guid.NewGuid().ToString();

        private bool isLoading = true;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                NotifyStateChanged();
            }
        }

        private Dictionary<int, ComplexModel> complexDataModel = new ComplexModel().GetDefaultComplexModel();
        public Dictionary<int, ComplexModel> ComplexDataModel
        {
            get => complexDataModel;
            set
            {
                complexDataModel = value;
                NotifyStateChanged();
            }
        }

        public async Task SetLocalStorage()
        {
            await LocalStorage.SetItemAsync(SessionID, await BuildLocalStorageObject());
        }

        public async Task GetLocalStorage()
        {
            SessionID = await GetSessionID();

            var response = await LocalStorage.GetItemAsync<StorageModel>(SessionID);
        }

        public Task<StorageModel> BuildLocalStorageObject()
        {
            return Task.FromResult(
                new StorageModel()
                {
                    ComplexModel = ComplexDataModel
                }
            ); 
        }

        public async Task<string> GetSessionID()
        {
            string sessionID = SessionID;

            await SessionStorage.SetItemAsStringAsync("sessionID", sessionID);

            await SetLocalStorage();

            return sessionID;
        }
    }
}
