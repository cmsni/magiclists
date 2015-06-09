using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MagicLists.DataModel;
using Parse;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MagicLists
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MPLists : Page
    {

        MagicListsDal _db = new MagicListsDal();
        public MPLists()
        {
            this.InitializeComponent();

            populatelist();


        }

        /// <summary>
        /// Invoked when the list needs to be populated via parse.com
        /// </summary>
        public  async void populatelist()
        {
            try
            {

                List<DataModel.MagicLists> mLists;
                mLists=await _db.GetListsAync();

                lstView.ItemsSource = mLists;

            }
            catch(Exception ex)
            {
            }

        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private async Task LstView_OnPullToRefreshRequested(object sender, EventArgs e)
        {
            lstView.ItemsSource = null;
            List<DataModel.MagicLists> mLists;
            mLists = await _db.GetListsAync();

            lstView.ItemsSource = mLists;
        }
    }
}
