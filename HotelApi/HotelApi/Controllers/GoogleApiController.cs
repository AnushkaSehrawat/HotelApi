using Demo.Controllers;
using GoogleMaps.LocationServices;
using HotelApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelApi.Controllers
{
    public class GoogleApiController : ApiController
    {




        [Route("api/GoogleApi/{add}")]
        public List<string> Get([FromUri]string add)
        {
            Latitude HD = new Latitude();
          // var address = "pune";

            HD.address = add;
            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(add);

            HD.latitude = point.Latitude;
            HD.longitude = point.Longitude;
            double lat = Convert.ToDouble(HD.latitude);
            double longi = Convert.ToDouble(HD.longitude);
            HotelController h1 = new HotelController();
            return h1.Gethotels(lat,longi);

         //   HotelController.GetDetails(HD);
            
        }


        //[HttpPost]
        //public Latitude Post(Latitude ld)
        //{
        //    //Latitude Hd = new Latitude();
        //    //Hd.address = ld.address;


        //    var locationService = new GoogleLocationService();
        //    var point = locationService.GetLatLongFromAddress(ld.address);

        //    ld.latitude = point.Latitude;
        //    ld.longitude = point.Longitude;

        //    HotelController.GetDetails(ld);
        //    return ld;
        //}

    }
}
