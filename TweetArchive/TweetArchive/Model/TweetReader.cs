using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoxKite.Twitter;
using BoxKite.Twitter.Authentication;
using Splat;
using TweetArchive.ViewModels;

namespace TweetArchive.Model
{
    public class TweetReader
    {
        public void StartService()
        {
            Mapper.Initialize(
                cfg =>
                    cfg.CreateMap<BoxKite.Twitter.Models.Tweet, TweetViewModel>()
                        .IgnoreAllPropertiesWithAnInaccessibleSetter());

            var config = Locator.Current.GetService<IConfiguration>();

            var serviceTask = Task.Run(async () =>
            {
                var session = new ApplicationSession(config.ApiKey, config.ApiSecret);

                var twitterauth = await session.StartApplicationOnlyAuth();

                if (twitterauth)
                {

                    var realm = RealmDB.Instance;
                    realm.Write(() =>
                    {
                        realm.RemoveAll<TweetViewModel>();
                    });

                    while (true)
                    {
                        try
                        {
                            var timeline = await session.GetUserTimeline(config.TwitterAccount, count: 4).ConfigureAwait(true);


                            //For this first Test we clear the DB completely before each Update
                            //realm.RemoveAll<TweetViewModel>();

                            realm = RealmDB.Instance;
                            var transAction = realm.BeginWrite();

                            foreach (var tweet in timeline)
                            {

                                var PersistentTweet = new TweetViewModel();
                                try
                                {
                                    Mapper.Map(tweet, PersistentTweet);
                                    realm.Add(PersistentTweet);
                                }
                                catch (Exception ex)
                                {
                                    throw;
                                }
                            }
                            transAction.Commit();

                        }
                        catch (Exception exception)
                        {
                         
                            Debug.WriteLine(exception.Message);   
                            throw;
                        }

 

                        await Task.Delay(5000);
                    }
                }
                else
                {
                    throw new UnauthorizedAccessException("could not authorize against Twitter");
                }

            });
          


        }
    }
}
