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
    "5946 12th Avenue Tsawwassen BC Canada V4L1C7"
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
                        //   alert(taddress);
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