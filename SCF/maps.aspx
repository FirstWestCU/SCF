<%@ Page Language="C#" %>
<!-- #include file="includes/htmlOpen.html" -->
<div class="wrapper">
<!-- #include file="includes/header.html" -->

    <!--=== Content Part ===-->
    <div class="container content">
        <div class="row">

            <!-- Begin Content -->
            <div class="col-md-12">
                <div class="heading heading-v1 margin-bottom-40">
                    <h2>Heat Maps</h2>
                    <p>The Sustainable Coop fund will help build and expand cooperatives selected by our members. The heat-maps show the aggregated investment of credit unions, confirming where and how they have positively affected society. It demonstrates the areas they invest their time, money and outreach efforts, helping to visually relay the real impact they are making in their communities. </p>
                </div>

                <!-- Basic Map -->
                <div class="headline">
                       <h3>Basic Map</h3>
                </div>
                <div id="map" class="map margin-bottom-50">
                </div>
                <!-- End Basic Map -->

               <!-- Basic Map2 -->
                <div class="headline">
                       <h3>Basic Map2</h3>
                </div>
                <div id="map2" class="map margin-bottom-50">
                </div>
                <!-- End Basic Map -->


               <!-- Basic Map3 -->
                <div class="headline">
                       <h3>Basic Map3</h3>
                </div>
                <div id="map3" class="map margin-bottom-50">
                </div>
                <!-- End Basic Map -->

            </div>
            <!-- End Content -->
        </div>          
    </div><!--/container-->     
    <!--=== End Content Part ===-->




</div><!--/End Wrapepr-->
<!-- #include file="includes/footer.html" -->
<!-- #include file="includes/htmlClose.html" -->
<script type="text/javascript">
    $(document).ready(function () {

        var map;
        var map2;
        var map3;

        var mapOptions = {
            zoom: 7,
            center: new google.maps.LatLng(50.000, -124.000),
            mapTypeId: google.maps.MapTypeId.SATELLITE
        };

        var mapOptions2 = {
            zoom: 7,
            center: new google.maps.LatLng(50.000, -124.000),
            mapTypeId: google.maps.MapTypeId.SATELLITE
        };

        var mapOptions3 = {
            zoom: 7,
            center: new google.maps.LatLng(50.000, -124.000),
            mapTypeId: google.maps.MapTypeId.SATELLITE
        };

        map = new google.maps.Map(document.getElementById('map'), mapOptions);
        map2 = new google.maps.Map(document.getElementById('map2'), mapOptions2);
        map3 = new google.maps.Map(document.getElementById('map3'), mapOptions3);


        var addresses = [
            "2387, Ware St, Abbotsford, BC,V2S3C6, Canada",
            "2420, Montrose Avenue, Abbotsford BC, V2S3S9, Canada",
            "33914 Essendene Ave. Abbotsford BC Canada V2S2H8",
            "2838 Justice Way Abbotsford BC Canada V2T3P5",
            "20550 Fraser Hwy Langley, BC Canada V3A4G2",
            "938 West 28th Avenue Vancouver BC Canada V5Z4H4",
            "463-4800 Kingsway Burnaby BC Canada V5H4J2",
            "5946 12th Avenue Tsawwassen BC Canada V4L1C7",
            "4631 Clarence Taylor Crescent	Delta BC, V4K 4L8, Canada",
            "5800, Mountain View Blvd, Delta, BC, V4K3V6, Canada",
            "9097, 120 Street, Delta, BC, V4C6R7, Canada",
            "P.O Box 2503, New Westminister, BC, V3L5B2, Canada",
            "5034, Emmerson Road, Abbotsford, BC, V3G3C1, Canada",
            "13595, King George Blvd, Surrey, BC, V3T2V1, Canada",
            "85, Winson Road, Abbotsford, BC, V2S8E8, Canada",
            "45600, Menholm Road, Chilliwak, BC, V2P1P7, Canada",
            "P.O. Box 998, 895 Third Avenue, Hope, BC, V0X1L0, Canada",
            "#8-22726, Dewdney Trunk Road, Maple Ridge, BC,	V2X3K2, Canada",
            "Box 1702, Hope, BC, V0X1L0, Canada",
            "Box 74-434 Wallace Street, Hope, BC, V0X 1L0, Canada",
            "P.O Box 99, Kitimat, BC, V8C 2G6, Canada",
            "14 Morgan St, Kitimat, BC, V8C 1J3, Canada",
            "32305 Badger Ave, Mission, BC, V2V 5H8, Canada",
            "12666, 72nd Ave, Surrey, BC, V3W 2M8, Canada",
            "PO Box 15, STN MAIN, Delta, BC, V4K 3N5, Canada",
            "20560 Fraser Highway, Langley, BC, V3A 4G2, Canada",
            "201, 4839 221 Street, Langley, BC,	V3A 2P1, Canada",
            "5768 203 St., Langley, BC, V3A1W3",
            "21488, Old Yale Road, Langley, BC, V3A4M8, Canada",
            "22180 - 48A Avenue, Langley, BC,	V3A8B7, Canada",
            "4875, 222nd Street, Langley, BC,V3A3Z7, Canada",
            "20605, 51B Avenue, Langley, BC, V3A9H1, Canada",
            "7743 200th St, Langley, BC, V2Y1S3, Canada",
            "32646 Logan Ave, Mission, BC, V2V6C7, Canada", 
            "PO Box 3341, Mission, BC, V2V 4J5, Canada",
            "250-2411 160th st, Surrey, BC,	V3S0C8, Canada", 
            "PO Box 45034, Ocean Park RPO, Surrey, BC, V4A9L1, Canada",
            "#205 12725 80th Avenue, Surrey, BC, V3W3A6, Canada", 	 	 
            "11666 Laity Street, Box 5000, Maple Ridge, BC, V2X7G5, Canada",
            "204-2190 west railway st, Abbotsford, BC, V2S2E2, Canada",
            "33860 Dlugosh Avenue, Mission, BC, V2V6B2, Canada",
            "45746 Yale Rd, Chilliwack, BC, V2P2N5, Canada",
            "22188 Lougheed Hwy, Maple Ridge, BC, V2X2S8, Canada",
            "Gateway of Hope, 5787 Langley Bypass, Langley, BC,	V3A0A9, Canada",
            "White Rock	15417 Roper Ave, White Rock, BC, V4B2G4, Canada",
            "15008 26th Avenue, Surrey, BC, V4P3H5, Canada",
            "2615 Clarke Street, Port Moody, BC, V3H1Z4, Canada",
            "12895, 85th Ave, Surrey, BC, V3W-0K8, Canada",
            "102-5830, 176A Street, Surrey, BC, V3S4H5, Canada",
            "2343 – 156 St., South Surrey, BC, V4A4V5, Canada",
            "#102-13771, 72A Ave, Surrey, BC, V3W9C6, Canada",
            "5545 Ladner trunk road,	Delta, BC, V4K1X1, Canada",
            "32550 7th ave, Mission, BC, V2V2B9, Canada",
            "4543 Canada Way, Burnaby, BC, V5G4T4, Canada",
            "P.O Box 2104, Hope, BC, V0X1L0, Canada",
            "14439-104 ave, #101, Surrey, BC, V3R1M1, Canada",
            "10732 City Parkway, Surrey, BC, V3T4C7, Canada",
            "13750 - 88 Avenue, Surrey, BC,	V3W3L1, Canada",
            "14033 92nd ave, Surrey, BC, V3V0B7, Canada",
            "1166 7th Ave, Hope, BC, V0X1L4, Canada",
            "23994 119B ave, Maple Ridge, BC, V4R1W4, Canada",
            "P208 33355 Bevan Ave., Abbotsford, BC, V2S 0E7, Canada",
            "33844 King Road, Abbotsford, BC, V2S7M8, Canada",
            "1183 Melville Street, Vancouver, BC, V6E2X5, Canada",
            "4670 Community St, Chilliwack, BC, V2R5E1, Canada",
            "4–535 Hornby Street,	Vancouver, BC, V6C2E8, Canada"
           ];


        var addresses2 = [
            "2960 North Meridian, Indianapolis, IN, 46208, USA",
            "615 North Alabama Street, Indianapolis, IN, 46204, USA",
            "10439 Commerce Drive, Indianapolis, IN, 46032, USA",
            "3737 Waldemere Avenue, Indianapolis, IN, 46241, USA",
            "7929 North Michigan Road, Indianapolis, IN, 46268, USA",
            "450 West Ohio Street, Indianapolis, IN, 46202, USA",
            "603 East Washington Street, Indianapolis, IN, 46204, USA"];

        var addresses3 = [
            "7222 Commerce Center Drive, Colorado Springs, CO, 80919 USA",
            "3116 Academy Drive, USAF Academy, CO, 80840 USA",
            "102 East Pikes Peak Avenue, Colorado Springs, CO, 80903 USA",
            "2605 Preamble Point, Colorado Springs, CO, 80915 USA",
            "961 East Colorado Avenue, Colorado Springs, CO, 80903 USA",
            "8605 Explorer Drive, Colorado Springs, CO, 80920 USA",
            "6155 Fountain Valley School Road, Colorado Springs, CO, 80911 USA"];



        var longLatData = [];

        var callbackcount = 0;
        //Loop through addresses
        for (var i = 0; i < addresses.length; i++) {
            taddress = addresses[i];
            sleep(1000);
          
            // alert(taddress);
            GMaps.geocode({
                address: taddress,
                callback: function (results, status) {

                    callbackcount++;

                    if (status == 'OK') {
                        var latlng = results[0].geometry.location;
                        // alert(latlng.lat());
                        /*map.addMarker({
                        lat: latlng.lat(),
                        lng: latlng.lng()
                        });*/
                        //alert(latlng.lat());
                        longLatData.push(new google.maps.LatLng(latlng.lat(), latlng.lng()));

                    } else {
                           alert(status);
                    }

                    if (callbackcount == addresses.length) {
                        // alert(longLatData.length);
                        var pointArray = new google.maps.MVCArray(longLatData);
                        //  alert(pointArray.length);
                        heatmap = new google.maps.visualization.HeatmapLayer({
                            data: pointArray
                        });

                        heatmap.setMap(map);
                    }

                }
            });
        } //end for

        ///////////////////////////////////////////
        var longLatData2 = [];

        var callbackcount2 = 0;
  
        //Loop through addresses
        for (var i = 0; i < addresses2.length; i++) {
            taddress2 = addresses2[i];
            sleep(1000);
          
         
        
            GMaps.geocode({
                address: taddress2,
                callback: function (results2, status2) {

                    callbackcount2++;

                    if (status2 == 'OK') {
                        var latlng2 = results2[0].geometry.location;
                        // alert(latlng.lat());
                        /*map.addMarker({
                        lat: latlng.lat(),
                        lng: latlng.lng()
                        });*/
                        //alert(latlng.lat());
                        longLatData2.push(new google.maps.LatLng(latlng2.lat(), latlng2.lng()));

                    } else {
                      //  alert(status2);
                    }

                    if (callbackcount2 == addresses2.length) {
                       
                        // alert(longLatData2.length);
                        var pointArray2 = new google.maps.MVCArray(longLatData2);
                        //  alert(pointArray.length);
                        heatmap2 = new google.maps.visualization.HeatmapLayer({
                            data: pointArray2
                        });

                        heatmap2.setMap(map2);
                    }

                }
            });
        } //end for
        /////////////////////////////////////////////////////
        var longLatData3 = [];

        var callbackcount3 = 0;
        //Loop through addresses
        for (var i = 0; i < addresses3.length; i++) {
            taddress3 = addresses3[i];
            sleep(1000);
            // alert(taddress);
            GMaps.geocode({
                address: taddress3,
                callback: function (results3, status3) {

                    callbackcount3++;

                    if (status3 == 'OK') {
                        var latlng3 = results3[0].geometry.location;
                        // alert(latlng.lat());
                        /*map.addMarker({
                        lat: latlng.lat(),
                        lng: latlng.lng()
                        });*/
                        //alert(latlng.lat());
                        longLatData3.push(new google.maps.LatLng(latlng3.lat(), latlng3.lng()));

                    } else {
                        //alert(taddress);
                    }

                    if (callbackcount3 == addresses3.length) {
                        // alert(longLatData.length);
                        var pointArray3 = new google.maps.MVCArray(longLatData3);
                        //  alert(pointArray.length);
                        heatmap3 = new google.maps.visualization.HeatmapLayer({
                            data: pointArray3
                        });

                        heatmap3.setMap(map3);
                    }

                }
            });
        } //end for


        function sleep(milliseconds) {
            var start = new Date().getTime();
            for (var i = 0; i < 1e7; i++) {
                if ((new Date().getTime() - start) > milliseconds) {
                    break;
                }
            }
        }

    });
</script>