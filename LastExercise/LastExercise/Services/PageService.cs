﻿using System.Threading.Tasks;
using Xamarin.Forms;

namespace LastExercise.Services
{
    class PageService : IPageService
    {
        private Page MainPage
        {
            get { return Application.Current.MainPage; }
        }
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await MainPage.DisplayAlert(title, message, ok, cancel);
        }
        public Task DisplayAlert(string title, string message, string ok)
        {
            throw new System.NotImplementedException();
        }
        public async Task<Page> PopAsync()
        {
            return await MainPage.Navigation.PopAsync();
        }
        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }
    }
}
