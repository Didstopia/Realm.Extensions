using Xamarin.Forms;
using Didstopia.RealmExtensions;
using Realms;

namespace Realm.Extensions.Demo
{
    public partial class Realm_Extensions_DemoPage : ContentPage
    {
        public Realm_Extensions_DemoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var list = new Didstopia.RealmExtensions.RealmList<string>
            {
                "Test"
            };
            var realm = Realms.Realm.GetInstance();
            realm.Write(() => realm.Add(list));
        }
    }
}
