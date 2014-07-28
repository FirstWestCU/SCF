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
                    <h2>Heat Map</h2>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</p>
                </div>

                <!-- Basic Map -->
                <div class="headline"><h3>Basic Map</h3></div>
                <div id="map" class="map margin-bottom-50"></div>
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

        var mapOptions = {
            zoom: 7,
            center: new google.maps.LatLng(50.000, -124.000),
            mapTypeId: google.maps.MapTypeId.SATELLITE
        };

        map = new google.maps.Map(document.getElementById('map'),
      mapOptions);






        var addresses = [
    "2387, Ware St, Abbotsford, BC,V2S3C6, Canada",
    "2420, Montrose Avenue, Abbotsford BC, V2S3S9, Canada",
    "33914 Essendene Ave. Abbotsford BC Canada V2S2H8",
    "2838 Justice Way Abbotsford BC Canada V2T3P5",
    "20550 Fraser Hwy LangleyBC Canada V3A4G2",
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


        var longLatData = [];

        var callbackcount = 0;
        //Loop through addresses
        for (var i = 0; i < addresses.length; i++) {
            taddress = addresses[i];
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
                           alert(taddress);
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

       

    });
</script>