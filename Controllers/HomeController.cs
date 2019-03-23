using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Task2_v5_0_0.Models;

namespace Task2_v5_0_0.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult SearchArtist(string ArtistName, string access_token) {
            // mainly set to previous value for testing. will expire quick
            // if user enters access_token, search artist will use new access_token
            if (access_token == null) {
                access_token = "BQCbTIMBfJLix2pWbm4khjArOQzIFZP7ge7Py_OnflHZETRdKE1XHMBNAw4kg6I3jjyZyQgk7pWGxLzepFk_WPGrMDRBtSzxZ6mkaFCmnqcg8kL9OkkYPhtEc9Cfpvn-B9rVrVlhmVA9HnNW3juw0kSz6jb-NXsqp9s";
            }

            // endpoint to get one result of artist id
            var endPoint = "https://api.spotify.com/v1/search?q=" + ArtistName + "&type=artist&limit=1";

            // setup request to get artist id
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(endPoint);
            request1.Method = "Get";

            // uses authentication token to access new spotify web api
            // before update, api did not require authentication
            request1.Headers.Add("Authorization", "Bearer " + access_token);



            // make call to web api
            try {
                HttpWebResponse response = (HttpWebResponse)request1.GetResponse();

                string strResponse = "";

                // get raw string of json
                using (Stream responseStream = response.GetResponseStream()) {
                    if (responseStream != null) {
                        using (StreamReader reader = new StreamReader(responseStream)) {
                            strResponse = reader.ReadToEnd();
                        }
                    }
                }

                // serialize Json into RootObject
                var jsonResponse = JsonConvert.DeserializeObject<RootObject>(strResponse);
                
                // id pertaining to artist
                // important for searching album
                var id = jsonResponse.artists.items[0].id;

                // setup endpoint to find artist albums
                var albumEndPoint = "https://api.spotify.com/v1/artists/"+id+ "/albums?include_groups=single&market=ES&limit=5";

                // setup request to get artist albums
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(albumEndPoint);
                request2.Method = "Get";
                
                // uses authentication token to access new spotify web api
                // before update, api did not require authentication
                request2.Headers.Add("Authorization", "Bearer " + access_token);

                // make call to web api
                HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();

                string strResponse2 = "";

                // get raw string of json
                using (Stream responseStream = response2.GetResponseStream()) {
                    if (responseStream != null) {
                        using (StreamReader reader = new StreamReader(responseStream)) {
                            strResponse2 = reader.ReadToEnd();
                        }
                    }
                }

                // serialize Json into RootObject
                var jsonResponse2 = JsonConvert.DeserializeObject<RootAlbum>(strResponse2);

                

                return View(jsonResponse2.items);
            }
            catch {
                return View("Error");
            }
        }
     

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

