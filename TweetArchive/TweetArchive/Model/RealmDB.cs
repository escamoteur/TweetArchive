using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;

namespace TweetArchive.Model
{
    public class RealmDB
    {
        private static RealmConfiguration config;

        public static Realm Instance => Realm.GetInstance(config);

        public void Init(string path = null)
        {
            config = new RealmConfiguration(path);
            config.ShouldDeleteIfMigrationNeeded = true;
        }
    }
}
