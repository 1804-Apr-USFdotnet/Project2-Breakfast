import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {} from '@types/googlemaps';
import { TrafficService } from '../traffic.service';
import { TrafficData } from '../models/trafficData';
import { TimeToWork } from '../models/TimeToWork';

@Component({
  selector: 'app-traffic',
  templateUrl: './traffic.component.html',
  styleUrls: ['./traffic.component.css']
})
export class TrafficComponent implements OnInit {
  traffic: TrafficData;
  timeToWork: TimeToWork;
  iconClass = "";
  @ViewChild('map') mapElement: any;
  map: google.maps.Map;  



  constructor(private route: ActivatedRoute, private trafficService: TrafficService) { 
    // this.traffic = {
    //   Address: 'Bellarmine Newman Hall',
    //   WorkAddress: 'Tampa, FL',
    //   AddressPlaceId: 'ChIJ3Y80KujHwogRpYFGqckVdpY',
    //   WorkAddressPlaceId : 'ChIJK3bIkI63wogRcL1x4YGzHCI',
    //   Driving: true,
    //   TravelMode: 'DRIVING',
    //   TimeToWork: '55'
    // };
  }

  ngOnInit() {
    // this.traffic.AddressPlaceId = "ChIJ3Y80KujHwogRpYFGqckVdpY";
    // this.traffic.WorkAddressPlaceId = "ChIJK3bIkI63wogRcL1x4YGzHCI";
    // this.traffic.Driving = true;
    // this.traffic.TravelMode = "DRIVING";
    this.traffic = {
      Address: 'Bellarmine Newman Hall',
      WorkAddress: 'Tampa, FL',
      AddressPlaceId: 'ChIJ3Y80KujHwogRpYFGqckVdpY',
      WorkAddressPlaceId : 'ChIJK3bIkI63wogRcL1x4YGzHCI',
      Driving: true,
      TravelMode: 'DRIVING',
      TimeToWork: '55'
    };
    this.getTimeToWork();
    var mapProp = {
      center: new google.maps.LatLng(18.5793, 73.8143),
      zoom: 15,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var trafficLayer = new google.maps.TrafficLayer();    
    this.map = new google.maps.Map(this.mapElement.nativeElement, mapProp);
    trafficLayer.setMap(this.map);
  }

  getTimeToWork() {
    this.trafficService.getTimeToWork(
        this.traffic.AddressPlaceId,
        this.traffic.WorkAddressPlaceId,
        this.traffic.TravelMode,
        (response) => {
            this.timeToWork = response
        }
    );
  }
}

//  initMap() {
//     this.map = new google.maps.Map(document.getElementById('map'),
//         {
//             mapTypeControl: false,
//             center: { lat: 28.064264, lng: -82.401471 },
//             zoom: 12

//         });
//     var trafficLayer = new google.maps.TrafficLayer();
//     trafficLayer.setMap(this.map);
//     new this.AutocompleteDirectionsHandler(this.map);
// }


//  AutocompleteDirectionsHandler(map) {
//     this.map = map;
//     this.map.originPlaceId = this.traffic.AddressPlaceId;
//     this.map.travelMode = "DRIVING";    
//     this.map.directionsService = new google.maps.DirectionsService;
//     this.map.directionsDisplay = new google.maps.DirectionsRenderer;
//     this.map.directionsDisplay.setMap(map);
//     this.map.destinationPlaceId = this.traffic.WorkAddressPlaceId;

//     var originAutocomplete = new google.maps.places.Autocomplete(
//         originInput,
//         { placeIdOnly: false });
//     var destinationAutocomplete = new google.maps.places.Autocomplete(
//         destinationInput,
//         { placeIdOnly: false });


//     this.setupPlaceChangedListener(originAutocomplete, 'ORIG');
//     this.setupPlaceChangedListener(destinationAutocomplete, 'DEST');

//     this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(originInput);
//     this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(destinationInput);


// }


// // Sets a listener on a radio button to change the filter type on Places
// // Autocomplete.
// AutocompleteDirectionsHandler.prototype.setupClickListener = function(id, mode) {
//     var radioButton = document.getElementById(id);
//     var me = this;
//     radioButton.addEventListener('click',
//         function() {
//             me.travelMode = mode;
//             me.route();
//         });
// }

// AutocompleteDirectionsHandler.prototype.setupPlaceChangedListener = function(autocomplete, mode) {
//     var me = this;
//     autocomplete.bindTo('bounds', this.map);
//     autocomplete.addListener('place_changed',
//         function() {
//             var place = autocomplete.getPlace();
//             if (!place.place_id) {
//                 window.alert("Please select an option from the dropdown list.");
//                 return;
//             }
//             if (mode === 'ORIG') {
//                 me.originPlaceId = place.place_id;
//             } else {
//                 me.destinationPlaceId = place.place_id;
//             }
//             me.route();
//         });

// }

// AutocompleteDirectionsHandler.prototype.route = function() {
//     if (!this.originPlaceId || !this.destinationPlaceId) {
//         return;
//     }
//     var me = this;
//     console.log(this.originPlaceId);
//     var originPlace = this.originPlaceId;
//     console.log(this.destinationPlaceId);
//     var destinationPlace = this.destinationPlaceId;
//     var geoCoder = new google.maps.Geocoder;
//     var location = geocodePlaceId(geoCoder,
//         originPlace,
//         destinationPlace,
//         function() {

//         });
//     console.log(location);
//     this.directionsService.route({
//             origin: { 'placeId': this.originPlaceId },
//             destination: { 'placeId': this.destinationPlaceId },
//             travelMode: this.travelMode
//         },
//         function(response, status) {
//             if (status === 'OK') {

//                 var service = new google.maps.DistanceMatrixService;
//                 console.log(originPlace);
//                 console.log(destinationPlace);
//                 service.getDistanceMatrix({
//                         origins: [address],
//                         destinations: [destAddress],
//                         travelMode: 'DRIVING',
//                         drivingOptions: {
//                             departureTime: new Date(Date.now()),
//                             trafficModel: 'optimistic'
//                         },
//                         unitSystem: google.maps.UnitSystem.METRIC,
//                         avoidHighways: false,
//                         avoidTolls: false
//                     },
//                     function(response2, status2) {
//                         console.log("callback");
//                         if (status2 == 'OK') {
//                             var origins = response2.originAddresses;
//                             var destinations = response2.destinationAddresses;

//                             for (var i = 0; i < origins.length; i++) {
//                                 var results = response2.rows[i].elements;
//                                 for (var j = 0; j < results.length; j++) {
//                                     var element = results[j];
//                                     //                                    var distance = element.distance.text;
//                                     var duration = element.duration.text;
//                                     console.log(duration);
//                                     var from = origins[i];
//                                     var to = destinations[j];
//                                 }
//                             }
//                         }
//                     });
//                 me.directionsDisplay.setDirections(response);
//             } else {
//                 window.alert('Directions request failed due to ' + status);
//             }
//         });
// }
// var address = null;
// var destAddress = null;

// geocodePlaceId(geocoder, placeId, destId, _callback) {
//     geocoder.geocode({ 'placeId': placeId },
//         function(results, status) {
//             if (status === 'OK') {
//                 if (results[0]) {
//                     var latLng = results[0].geometry.location;
//                     console.log("geocode latlang" + latLng);
//                     address = results[0].formatted_address;
//                     //console.log("geocode address" + address);


//                 } else {
//                     window.alert('No results found');
//                 }
//             } else {
//                 window.alert('Geocoder failed due to: ' + status);
//             }
//         });
//     geocoder.geocode({ 'placeId': destId },
//         function(results, status) {
//             if (status === 'OK') {
//                 if (results[0]) {
//                     var destLatLng = results[0].geometry.location;
//                     console.log("geocode latlang" + destLatLng);
//                     destAddress = results[0].formatted_address;
//                     console.log("geocode address" + destAddress);


//                 } else {
//                     window.alert('No results found');
//                 }
//             } else {
//                 window.alert('Geocoder failed due to: ' + status);
//             }
//         });
//     _callback();
// }
// src="https://maps.googleapis.com/maps/api/js?key=@ViewBag.APIKey&libraries=places&callback=initMap"
                
// }

