using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Xamarin.Forms;

namespace TweetArchive.Views
{
    public partial class TweetViewCell 
    {
        public TweetViewCell()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.Text, v => v.TweetMessage.Text);
            });
        }
    }
}
